// SPDX-License-Identifier: BUSL-1.1

//不设置取消功能，没有手续费，理论上需要允许其他任何人来拍卖，而不仅仅是ShareToken。

pragma solidity ^0.8.0;

// refrence https://github.com/OpenZeppelin/openzeppelin-contracts

import "./openzeppelin/Address.sol";
import "./openzeppelin/SafeERC20.sol";
import "./openzeppelin/ERC20.sol";
import "./NoDelegateCall.sol";
import "./20IDutchAuction.sol";
import "./Administrator.sol";
import "./20IShareTokenFactory.sol";


// https://medium.com/coinmonks/math-in-solidity-part-5-exponent-and-logarithm-9aef8515136e
// https://github.com/abdk-consulting/abdk-libraries-solidity
// Dr. Mikhail Vladimirov 只抄了一部分代码（他的代码太长，功能太多）
library ABDKMath64x64 {
    /*
   * Minimum value signed 64.64-bit fixed point number may have. 
   */
  int128 private constant MIN_64x64 = -0x80000000000000000000000000000000;

  /*
   * Maximum value signed 64.64-bit fixed point number may have. 
   */
  int128 private constant MAX_64x64 = 0x7FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF;

  /**
   * Calculate x^y assuming 0^0 is 1, where x is signed 64.64 fixed point number
   * and y is unsigned 256-bit integer number.  Revert on overflow.
   *
   * @param x signed 64.64-bit fixed point number
   * @param y uint256 value
   * @return signed 64.64-bit fixed point number
   */
  function pow (int128 x, uint256 y) internal pure returns (int128) {
    unchecked {
      bool negative = x < 0 && y & 1 == 1;

      uint256 absX = uint128 (x < 0 ? -x : x);
      uint256 absResult;
      absResult = 0x100000000000000000000000000000000;

      if (absX <= 0x10000000000000000) {
        absX <<= 63;
        while (y != 0) {
          if (y & 0x1 != 0) {
            absResult = absResult * absX >> 127;
          }
          absX = absX * absX >> 127;

          if (y & 0x2 != 0) {
            absResult = absResult * absX >> 127;
          }
          absX = absX * absX >> 127;

          if (y & 0x4 != 0) {
            absResult = absResult * absX >> 127;
          }
          absX = absX * absX >> 127;

          if (y & 0x8 != 0) {
            absResult = absResult * absX >> 127;
          }
          absX = absX * absX >> 127;

          y >>= 4;
        }

        absResult >>= 64;
      } else {
        uint256 absXShift = 63;
        if (absX < 0x1000000000000000000000000) { absX <<= 32; absXShift -= 32; }
        if (absX < 0x10000000000000000000000000000) { absX <<= 16; absXShift -= 16; }
        if (absX < 0x1000000000000000000000000000000) { absX <<= 8; absXShift -= 8; }
        if (absX < 0x10000000000000000000000000000000) { absX <<= 4; absXShift -= 4; }
        if (absX < 0x40000000000000000000000000000000) { absX <<= 2; absXShift -= 2; }
        if (absX < 0x80000000000000000000000000000000) { absX <<= 1; absXShift -= 1; }

        uint256 resultShift = 0;
        while (y != 0) {
          require (absXShift < 64);

          if (y & 0x1 != 0) {
            absResult = absResult * absX >> 127;
            resultShift += absXShift;
            if (absResult > 0x100000000000000000000000000000000) {
              absResult >>= 1;
              resultShift += 1;
            }
          }
          absX = absX * absX >> 127;
          absXShift <<= 1;
          if (absX >= 0x100000000000000000000000000000000) {
              absX >>= 1;
              absXShift += 1;
          }

          y >>= 1;
        }

        require (resultShift < 64);
        absResult >>= 64 - resultShift;
      }
      int256 result = negative ? -int256 (absResult) : int256 (absResult);
      require (result >= MIN_64x64 && result <= MAX_64x64);
      return int128 (result);
    }
  }
}


//Erc20 的 荷兰拍卖，逐步降价的拍卖。
contract DutchAuction is NoDelegateCall, IDutchAuction, Administrator {
    using SafeERC20 for IERC20;
    // using Address for address;
  
    // //允许来自 ShareTokenFactory 的拍卖请求！！！ 一个拍卖合约绑定一个 ShareTokenFactory 
    address public ShareTokenFactory = address(0);              

    function setShareTokenFactory(address _fac) external onlyAdmin {
        require(ShareTokenFactory == address(0), "1");          //只能设置一次！       todo: 先注销掉，方便测试！
        ShareTokenFactory = _fac;
    }

    function isFromShareToken() private view WhenNotDelegateCall returns (bool) {
        return IShareTokenFactory(ShareTokenFactory).hasShareToken(msg.sender);
    }      
        
    constructor(address admin_, address superAdmin_) Administrator (admin_, superAdmin_) NoDelegateCall() {
        // 管理员只有两个作用： 设置ShareToken的类工厂，设置最小拍卖数量！  
    }  
    
    bool private unlocked = true;               //避免重入。有调用外部合约的时候，可以谨慎使用！
    modifier lock() {
        require(unlocked == true, 'L');
        unlocked = false;
        _;
        unlocked = true;
    }

    address public  constant ETH = address(0);                              // 使用 0x0 代表 ETH Token。 

    //每隔多少区块降价一次， 6个区块（是安全的），6 * 12 = 72秒      不同的链，设置不同区块数  最多五分钟就足够了  
    //以太坊12秒一个区块，每天产生 24*60*60/72=1200 次价格递减！ 这个递减速度非常高效：
    //  每次递减千分之三，每天会递减到最初价格的百分之二点七（约三十六分之一）！
    //  三天递减到五万分之一！一般来说三天之内肯定搞定！  //4天2百万         //两天内递减1360分之一。 // 所以客户端调用设置 1000 和 百万 是可以的。
    uint constant public waitBlocks = 6;

    uint public constant lessPerBlocks1000 = 3;                             //每次递减，固定为 千分之三，和Uniswap的手续费一样
  
    mapping (address => uint256) public tokenMinSellOf;                     //某种token的最低出售数量，也是拍卖的token白名单, 管理员必须设置后才可以拍卖！

    function setTokenMinSell(address _token, uint256 _minAmount) public onlyAdmin lock {    //加 lock 防范 admin 同时调用 sel 或者 buy 
        // require(_token != address(0), "M1");
        require(_minAmount == 0 || _minAmount >= 1000, "A");                //为0（禁用，或者大于1000）
        tokenMinSellOf[_token] = _minAmount;                                //_minAmount 为 0 就是不允许出售了！
    }

    function getTokenSellMinSell(address _token) external override view returns (uint) {
        return tokenMinSellOf[_token];
    }

    function getTokenSellMinBuy(address _tokenSell) public view override returns (uint _minAmount) {
        return  tokenMinSellOf[_tokenSell] / 10;                            //某种token的最低购买数量 不需要单独设置， 使用最小出售的十分之一就好！
    } 

    mapping (bytes32 => uint) public ordersBlocksOf;   // orderid => sell blocknumber  挂单的blocknumber  ordersSecondsOf
    mapping (bytes32 => uint) public orderAmountOf;    // orderid => current amount    挂单的当前金额，逐步减少

    // 得到出售订单的当前金额
    function getOrderAmount(address _seller, address _tokenSell, uint _tokenSellAmount,  address _tokenBuy, uint _buyHighestAmount,  uint _sellId) 
        external view returns (uint) 
    {
        bytes32 sellHash =  getSellHash( _seller, _tokenSell,  _tokenSellAmount,   _tokenBuy,  _buyHighestAmount,  _sellId);
        return orderAmountOf[sellHash];       
    }

    // 得到出售订单的当前金额 (扩展方法)
    function getOrderAmountEx(bytes32 _sellHash) external view returns (uint) 
    {
        return orderAmountOf[_sellHash];
    }

    function getSellHash(address _seller, address _tokenSell, uint _tokenSellAmount,  address _tokenBuy, uint _buyHighestAmount,  uint _sellId)  
        public view returns (bytes32 _result)  
    {
        //参数可以不要 seller， 增加这个数主要是为了保持hash值唯一，便于客户端显示。
        _result =  keccak256(abi.encode(_seller, _tokenSell,  _tokenSellAmount, _tokenBuy,  _buyHighestAmount, address(this), _sellId));
    }

    // 得到允许挂单的最低价格，必须高于上个出价! 主要是防止手抖错误输入！
    function getMin_BuyHighestAmount(address _tokenSell, uint _tokenSellAmount,  address _tokenBuy) public view returns (uint) {
        TokenPrice storage te = TokenPriceOf[_tokenSell][_tokenBuy];                
        if (0 < te.time && 0 < te.tokenBuyAmount && 0 < te.tokenSellAmount) {
            uint Min_BuyHighestAmount = _tokenSellAmount * te.tokenBuyAmount / te.tokenSellAmount;
            return Min_BuyHighestAmount;
        }
        return 0;
    }

    uint256 public SellId = 0;                  //订单ID，出售ID，自动递增，和 _sellHash 一一对应，但在合约中不需要记录这个对应关系！

    event OnSell(address indexed _seller, address indexed _tokenSell, uint _tokenSellAmount,  address _tokenBuy, uint _buyHighestAmount, uint _sellId, bytes32 _sellHash);
    event OnBuy (address indexed _seller, bytes32 indexed _sellHash, address indexed _buyer, uint _sellTokenAmountOut,  uint _buyTokenAmountIn);

    //出售Token，得到eth。这里挂单可以是 用户账号，或者 合约账号
    //调用前，token 要先 aprove ！ 
    function sell(address _tokenSell, uint _tokenSellAmount,  address _tokenBuy, uint _buyHighestAmount) 
        external payable override WhenNotDelegateCall lock returns (bytes32 sellHash_)
    {
        //只允许 ShareToken 或者 外部访问账号（EOA 账号）调用！ 不允许外部合约调用！
        //是没有手续费的, 外部账号的挂单容易被自己刷单，但这种刷单不影响拍卖。对外部账号发布的拍卖收取手续费，但是又收给谁呢？ 所以暂时不处理！
        //必须要有交易，分红合约才能调用 sell ， 因为 分红合约在调用前要得到历史价格，没有历史价格就无法定价！
        require(msg.sender == tx.origin || isFromShareToken(), "SC");               

        require(_tokenSell != _tokenBuy, "S0");
        require(tokenMinSellOf[_tokenSell] > 0, "S1");                              //Token白名单，最小金额大于0的Token才能拍卖
        require(_tokenSellAmount >= 1000 
            && _tokenSellAmount >= tokenMinSellOf[_tokenSell], "S2");               //必须大于最小金额 和 1000
        require(_buyHighestAmount > 0, "S3");    

        // TokenPriceOf 判断，必须高于上个出价! 主要是防止手抖错误输入！
        // TokenPrice storage te = TokenPriceOf[_tokenSell][_tokenBuy];                
        // if (0 < te.time && 0 < te.tokenBuyAmount && 0 < te.tokenSellAmount) {
        //     require(_buyHighestAmount / _tokenSellAmount >= te.tokenBuyAmount / te.tokenSellAmount, "SP");
        // }
        require(getMin_BuyHighestAmount(_tokenSell, _tokenSellAmount, _tokenBuy) <= _buyHighestAmount, "SP");
                        
        SellId++;
        uint sid = SellId;

        //1, 生成hash
        bytes32 sellHash = getSellHash(msg.sender, _tokenSell, _tokenSellAmount, _tokenBuy, _buyHighestAmount, sid);
        require(orderAmountOf[sellHash] == 0, "S4");    //有 sellHash ，不重复。多这个判断更保险，以免出现hash碰撞！ 按理不可能的，否则整个区块链都崩了。
        
        //2, 转账过来，得到Token(或ETH)。     
        _transferTokenFrom(_tokenSell, msg.sender, _tokenSellAmount); 
       
        //3，记录拍卖的起始时间和金额（还有多少可以拍卖）
        orderAmountOf[sellHash] = _tokenSellAmount;                    
        ordersBlocksOf[sellHash] = block.number;              
      
        emit OnSell(msg.sender, _tokenSell, _tokenSellAmount,  _tokenBuy, _buyHighestAmount, sid, sellHash);
        return sellHash;
    }
  
    // 得到价格
    function getPrice(uint _blockNum, address _seller,address _tokenSell, uint _tokenSellAmount,  address _tokenBuy, uint _buyHighestAmount,  uint _sellId) 
        public view returns (uint _curSellTokenAmount, uint _curBuyTokenAmount) 
    {
        _curBuyTokenAmount = 0;

        bytes32 sellHash = getSellHash(_seller, _tokenSell,  _tokenSellAmount,   _tokenBuy,  _buyHighestAmount,   _sellId);
        _curSellTokenAmount = orderAmountOf[sellHash]; 
        if (_curSellTokenAmount > 0                                 //有Token出售
                && ordersBlocksOf[sellHash] > 0)                    //冗余判断条件，正常来说使用 orderAmountOf[_seller][sellHash]  判断就可以了
        {
            (_curSellTokenAmount, _curBuyTokenAmount) = getPriceEx(_blockNum, sellHash,  _tokenSellAmount, _buyHighestAmount);
        }       
    }

    uint private constant Max64 = 2**64;                            //64 位最大值  约 1.8 * 10**19

    // 得到价格的扩展方法 通过 Hash 直接读取    //注意： _curtokenBuyAmount = 1 是特殊情况，就是
    function getPriceEx(uint _blockNum, bytes32 _sellHash,  uint _tokenSellAmount, uint _buyHighestAmount) 
        public view returns (uint _curtokenSellAmount, uint _curtokenBuyAmount) 
    {
        _curtokenBuyAmount = 0;
        _curtokenSellAmount = orderAmountOf[_sellHash]; 
        require(_curtokenSellAmount > 0, "P0");                     //有Token出售

        uint MaxTokenBuyAmount = _buyHighestAmount * _curtokenSellAmount / _tokenSellAmount;    //得到最多需要多少 tokenBuy.
        require(0 <= MaxTokenBuyAmount, "P1");    

        require(ordersBlocksOf[_sellHash] > 0, "P2");               //冗余判断条件，正常来说使用 orderAmountOf[_seller][sellHash]  判断就可以了

        // 计算
        // uint PassBlocks = block.number - ordersBlocksOf[_sellHash]; // 把 block.number 改为 参数，就可以计算任意区块的价格了 不处理，客户端自己可以搞的
        require(ordersBlocksOf[_sellHash] < _blockNum, "PB");
        uint PassBlocks = _blockNum - ordersBlocksOf[_sellHash];    // 可以计算任意区块的价格
        //底数, Base; exponent,指数;  Denominator,分母;  numerator，分子
        uint exp  =  PassBlocks / waitBlocks;                       //每6个区块(72秒)减少一次，一天减少次数是1200次,每次0.3#，一天后价格降低到原来的2.7%。    
        uint den = 1000 - lessPerBlocks1000;
        uint num = 1000;
        int128 base = int128(int (den * Max64 / num) );
        int128 result = ABDKMath64x64.pow(base, exp);        
        //说明： result 次小是 1， uint128(result) / Max64 次小值 是 1/2**64 = 5*10**（-20），
        //      只要 _buyHighestAmount 值设定小于当前价格对应数量的 2**64 约等于 2 * 10**19 就可以了(这是相当大的数，一般设定10**6就足够了)。
        _curtokenBuyAmount = MaxTokenBuyAmount *  uint128(result) / Max64;     

        require(_curtokenBuyAmount <= MaxTokenBuyAmount, "P3");     //必须小于等于出售的， 是必然的，还是写上验证一下。

        //如果为0，返回1.   这是有可能的，例如拍卖毫无价值的Token没人购买导致溢出。
        if (_curtokenBuyAmount == 0 ) {           
            _curtokenBuyAmount = 1;         //无论购买多少 tokenSell， 只需要支付 1 tokenBuy 既可以购买！
        }
    }

    // 记录 tokenSell => tokenBuy 最近最高成交价格.  使用两个数记录，比使用价格一个数记录会全面点。
    struct TokenPrice {
        uint256 tokenSellAmount;              
        uint256 tokenBuyAmount;       
        uint256 time;       
    } 
 
    mapping(address => mapping(address => TokenPrice)) public TokenPriceOf;           // tokenSell => tokenBuy => TokenPrice(成交的token和eth的累加数量)

    function getTokenHisPrice(address _tokenSell, address _tokenBuy) external view override 
        returns (uint256 _tokenSellAmount, uint256 _tokenBuyAmount, uint256 _time) 
    {
        TokenPrice storage te = TokenPriceOf[_tokenSell][_tokenBuy];
        return (te.tokenSellAmount, te.tokenBuyAmount, te.time);
    }

    // 记录 Token 的当前最高价格    tokenA => TokenB 其实只需要一个记录，本合约不处理，还是记录两笔价格！
    function _updateTokenPrice(address _tokenSell, address _tokenBuy, uint _tokenSellAmount, uint _tokenBuyAmount) private {
        TokenPrice storage te = TokenPriceOf[_tokenSell][_tokenBuy];
        te.time = block.timestamp;
        te.tokenBuyAmount = _tokenBuyAmount;
        te.tokenSellAmount = _tokenSellAmount;
    }

    //计算需要支付多少 tokenBuy 购买 特定数量的 tokenSell   
    // 需要注意：客户端调用，是当前已产生区块；但链上调用是当前正在产生的区块！所以在价格区间的最后一个区块上，客户端调用会得到老价格，再链上执行的时候价格就下降了，不影响成交！
    function calPayTokenBuyAmount(uint _blockNum, address _seller, address _tokenSell, uint _tokenSellAmount,  address _tokenBuy, uint _buyHighestAmount,  uint _sellId, 
        uint  _getTokenSellAmount) external view override returns (uint _payTokenBuyAmount) 
    {
        _payTokenBuyAmount = 0;
        bytes32 sellHash =  getSellHash(_seller, _tokenSell, _tokenSellAmount,  _tokenBuy,  _buyHighestAmount, _sellId);
        require(orderAmountOf[sellHash]  >= _getTokenSellAmount, "C1");
        uint minbuy = getTokenSellMinBuy(_tokenSell);
        require(_getTokenSellAmount >= minbuy, "C2");   

        (uint _curtokenSellAmount, uint _curtokenBuyAmount) = getPriceEx(_blockNum, sellHash,  _tokenSellAmount, _buyHighestAmount);
        _payTokenBuyAmount = _curtokenBuyAmount * _getTokenSellAmount / _curtokenSellAmount;     
        // return _payTokenBuyAmount;
    }
       
    function buy(address _seller, address _tokenSell, uint _tokenSellAmount,  address _tokenBuy, uint _buyHighestAmount, uint _sellId, 
        uint _getTokenSellAmount, uint _payMaxTokenBuyAmount) external payable WhenNotDelegateCall lock
    {
        require(_getTokenSellAmount > 0, "B1");
        require(_payMaxTokenBuyAmount > 0, "B2");            //todo: 这个条件可以不需要？
        // require(_seller != address(0), "B4");
        
        bytes32 sellHash = getSellHash(_seller, _tokenSell, _tokenSellAmount,  _tokenBuy,  _buyHighestAmount, _sellId);
        require(orderAmountOf[sellHash]  >= _getTokenSellAmount, "B3");
        //最小金额限制：要求购买金额大于等于最小金额，或者剩余金额小于最小金额！
        uint minbuy = getTokenSellMinBuy(_tokenSell);
        require(_getTokenSellAmount >= minbuy, "B4");         

        //0， 收钱！！！ eth 或 token 
            //todo: 这里可以做成支持闪电贷，不需要从 msg.sender 转账过来，而是最后检测金额是否够数(lock?)。Uniswap就是这么做的。我们这里暂时不这么处理。
        _transferTokenFrom(_tokenBuy, msg.sender, _payMaxTokenBuyAmount);
                
        (uint _curtokenSellAmount, uint _curtokenBuyAmount) = getPriceEx(block.number, sellHash,  _tokenSellAmount, _buyHighestAmount);   // 用hash，可以节约gas。 得到可出售金额和可买金额
        require(_curtokenSellAmount >= _getTokenSellAmount, "B5");          //_curTokenAmount == orderAmountOf[_seller][sellHash]   这个判断重复 前面 B5 有判断！！！

        uint thisTokenBuyAmount = _curtokenBuyAmount * _getTokenSellAmount / _curtokenSellAmount;       //需要支付的金额 ， 要和 calPayTokenBuyAmount 一模一样 
        require(thisTokenBuyAmount <= _payMaxTokenBuyAmount, "B6");         //要求购买支付的数量，要小于等于实际支付的金额  注意: 客户端计算因为舍入原因，有时候这里会出错(_payMaxTokenBuyAmount)，这里暂时不处理。

        //更新拍卖token数量
        orderAmountOf[sellHash] = orderAmountOf[sellHash] - _getTokenSellAmount;    //orderid => current amount；更新

        //1， 处理买家
        _transferTokenTo(_tokenSell, msg.sender, _getTokenSellAmount);      //买家 得到 tokenSell
        if (thisTokenBuyAmount <  _payMaxTokenBuyAmount)                    //有剩余款tokenBuy，退回去  购买前使用 calPayTokenBuyAmount 计算！
        {
            uint ToBuyer = _payMaxTokenBuyAmount - thisTokenBuyAmount;     
            _transferTokenTo(_tokenBuy, msg.sender, ToBuyer);
        }

        //2， 处理卖家 
        _transferTokenTo(_tokenBuy, _seller, thisTokenBuyAmount);           //token或eth是直接给卖家打款过去的！所以合约需要能够接受这个资产,使用推的方式！
        emit OnBuy (_seller, sellHash, msg.sender, _getTokenSellAmount, thisTokenBuyAmount);
        if(orderAmountOf[sellHash] == 0) {
            //2.1, 处理卖完了
            ordersBlocksOf[sellHash] = 0;
        }
        else {
            //2.2, 如果剩余的token数量太少，自动退回给卖家。
            _doMinBuy(_tokenSell,  _seller, sellHash);
        }

        //3, 记录第一笔成交价格！ 
        if(_tokenSellAmount < _curtokenSellAmount + minbuy) {   // OK
        // if(_tokenSellAmount == _curtokenSellAmount) {        // 2023-08-08: 因为舍入原因，这个条件不一定成立！！！  一定要注意，逻辑上相等的数据，如果存在计算过程，有可能不等！！！
            _updateTokenPrice( _tokenSell,  _tokenBuy,  _getTokenSellAmount,  thisTokenBuyAmount);
        }
    }

    function _doMinBuy(address _tokenSell,  address _seller, bytes32 _sellHash) private {
        uint minBuy = getTokenSellMinBuy(_tokenSell);
        if (0 < orderAmountOf[_sellHash] && orderAmountOf[_sellHash] <  minBuy) {
            uint amount = orderAmountOf[_sellHash];
            orderAmountOf[_sellHash] = 0;
            ordersBlocksOf[_sellHash] = 0;                              
            _transferTokenTo(_tokenSell, _seller, amount);    
        }
    }

    function _transferTokenTo(address _token, address _to, uint256 _amount) private {
        if (_amount == 0) return;
        if (_token == ETH)     {
            Address.sendValue(payable(_to), _amount);                      
        }
        else {
            IERC20(_token).safeTransfer(_to, _amount);               
        }
    }
    
    function _transferTokenFrom(address _token, address _from, uint256 _amount) private {
        if (_amount == 0) return;
        if (_token != ETH) {
            uint ta1 = IERC20(_token).balanceOf(address(this));
            IERC20(_token).safeTransferFrom(_from, address(this), _amount);         //call aprove bfore
            uint ta2 =  IERC20(_token).balanceOf(address(this));
            require(ta1 + _amount == ta2, "F1");                                    //防止恶意token (例如转账一次减少10%的token)
        }
        else if (_token == ETH) {
            require(_amount == msg.value, "F2");
        }
    }
  
  
    ///////////////////////////////////////////////////////////////////////////

    // event OnReceive(address _user, uint _amount, address _to);  //主要是方便测试，也方便记录数据

    // receive() external payable lock {
    //     if (msg.value > 0){
    //         emit OnReceive(msg.sender, msg.value, Admin);
    //         payable(Admin).transfer(msg.value);                          //接收到的eth，全部转给admin。 就是不允许直接转账，必须调用 buytoken 购买。
    //     }
    // }

    // fallback() external {
    // }
   

}