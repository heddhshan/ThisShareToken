using BlockChain.Share;
using Nethereum.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BlockChain.ShareToken
{
    /// <summary>
    /// WindowDutchAuctionBuy.xaml 的交互逻辑
    /// </summary>
    public partial class WindowDutchAuctionBuy : Window
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        private Model.DutchAuctionTokenSell ThisSellModel;


        public WindowDutchAuctionBuy()
        {
            InitializeComponent();
            this.Title = LanguageHelper.GetTranslationText(this.Title);

            //from 地址
            var dv = new Share.BLL.Address().GetAllTxAddress();
            ComboBoxAddress.SelectedValuePath = "Address";
            ComboBoxAddress.ItemsSource = dv;

            log.Info(this.GetType().ToString() + ", Width=" + this.Width.ToString() + "; Height=" + this.Height.ToString());
        }

        private async void DoDutchAuctionBuy(object sender, RoutedEventArgs e)
        {
            if (ComboBoxAddress.SelectedValue == null) return;

            this.Cursor = Cursors.Wait;
            ((IMainWindow)App.Current.MainWindow).ShowProcessing();
            try
            {
                var chainid = (int)Share.ShareParam.GetChainId();
                var m = DAL.DutchAuction_OnSell.GetModel(Share.ShareParam.DbConStr, chainid, ShareTokenParam.AddressDutchAuction, ThisSellModel._sellId);
                var account = new Share.BLL.Address().GetAccount(ComboBoxAddress.SelectedValue.ToString(), PasswordBox1.Password);
                if (account == null)
                {
                    return;
                }

                decimal _GetTokenSellAmount = decimal.Parse(TextBoxGetTokenSellAmount.Text);
                //decimal _PayMaxTokenBuyAmount = decimal.Parse(TextBoxPayTokenBuyAmount.Text);
                //BigInteger Big_TokenBuyAmount = (BigInteger)TextBoxPayTokenBuyAmount.Tag;   // + 1 ;
                BigInteger Big_TokenBuyAmount = (BigInteger)TextBoxPayTokenBuyAmount.Tag + 1 ;

                //var Big_GetTokenSellAmount = (BigInteger)((double)_GetTokenSellAmount * Math.Pow(10, Share.BLL.Token.GetTokenDecimals(m._tokenSell)));
                var Big_GetTokenSellAmount = Common.SolidityHelper.GetTokenBigIntAmount(_GetTokenSellAmount, Share.BLL.Token.GetTokenDecimals(m._tokenSell));

                //var Big_PayMaxTokenBuyAmount = (BigInteger)((double)_PayMaxTokenBuyAmount * Math.Pow(10, Share.BLL.Token.GetTokenDecimals(m._tokenBuy)));

                //approve !
                if (!ShareParam.IsAnEmptyAddress(m._tokenBuy))
                {
                    bool IsOkApprove1 = await ((IMainWindow)App.Current.MainWindow).GetHelper().UiErc20TokenApprove(this, account, m._tokenBuy, ShareTokenParam.AddressDutchAuction, Big_TokenBuyAmount);
                    if (!IsOkApprove1)
                    {
                        MessageBox.Show(this, "Erc20 Token Approve Failed!");
                        return;
                    }
                }

                //  function buy(address _seller, address _tokenSell, uint _tokenSellAmount,  address _tokenBuy, uint _buyHighestAmount, uint _sellId, uint _getTokenSellAmount, uint _payMaxTokenBuyAmount) external payable WhenNotDelegateCall lock
                
                Nethereum.Web3.Web3 web3 = ShareParam.GetWeb3(account);
                Contract.DutchAuction.DutchAuctionService service = new Contract.DutchAuction.DutchAuctionService(web3, ShareTokenParam.AddressDutchAuction);
                Contract.DutchAuction.ContractDefinition.BuyFunction param = new Contract.DutchAuction.ContractDefinition.BuyFunction()
                {
                    Seller = m._seller,
                    TokenSell = m._tokenSell,
                    TokenSellAmount = BigInteger.Parse(m._tokenSellAmount_Text),
                    TokenBuy = m._tokenBuy,
                    BuyHighestAmount = BigInteger.Parse(m._buyHighestAmount_Text),
                    SellId = m._sellId,
                    GetTokenSellAmount = Big_GetTokenSellAmount,
                    PayMaxTokenBuyAmount = Big_TokenBuyAmount           // Big_PayMaxTokenBuyAmount
                };
                if (ShareParam.IsAnEmptyAddress(m._tokenBuy))
                {
                    param.AmountToSend = param.PayMaxTokenBuyAmount;
                }

                var txid = await service.BuyRequestAsync(param);
                var remark = "DutchAuction,Buy Token:" + m._tokenSell + ", Amount:" + _GetTokenSellAmount.ToString() + "。";
                Share.BLL.TransactionReceipt.LogTx(account.Address, txid, "DutchAuction_Buy", remark);

                if (MessageBox.Show(this, LanguageHelper.GetTranslationText("已经提交事务，希望查看事务的执行状态请点击‘OK’，否则点击‘Cancel’。"), "Message", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    System.Diagnostics.Process.Start("explorer.exe", ShareParam.GetTxUrl(txid));
                }

                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                ((IMainWindow)App.Current.MainWindow).ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }


        private void OnComboBoxAddressSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowUserInfo();
        }

        private void ShowUserInfo()
        {
            if (ComboBoxAddress.SelectedValue != null)
            {
                Nethereum.Web3.Web3 web3 = ShareParam.GetWeb3();
                string UserAddress = ComboBoxAddress.SelectedValue.ToString();
                var UserTokenBuyBalance = Share.ShareParam.GetRealBalance(UserAddress, ThisSellModel._tokenBuy);
                LabelTokenBuyBalance.Content = UserTokenBuyBalance.ToString();
            }
        }


        private void TokenSellAmountSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxGetTokenSellAmount.Text =  LabelTokenAmount.Content.ToString();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshPrice();
        }

        private void BuyTokenAmountOnLostFocus(object sender, RoutedEventArgs e)
        {
            RefreshPrice();
        }

        private void RefreshPrice()
        {
            decimal _GetTokenSellAmount;
            if (!decimal.TryParse(TextBoxGetTokenSellAmount.Text, out _GetTokenSellAmount))
            {
                return;
            }

            this.Cursor = Cursors.Wait;
            ((IMainWindow)App.Current.MainWindow).ShowProcessing();
            try
            {
                var chainid = (int)Share.ShareParam.GetChainId();
                var m = DAL.DutchAuction_OnSell.GetModel(Share.ShareParam.DbConStr, chainid, ShareTokenParam.AddressDutchAuction, ThisSellModel._sellId);
                //decimal _GetTokenSellAmount = decimal.Parse(TextBoxGetTokenSellAmount.Text);

                Nethereum.Web3.Web3 web3 = ShareParam.GetWeb3();
                Contract.DutchAuction.DutchAuctionService service = new Contract.DutchAuction.DutchAuctionService(web3, ShareTokenParam.AddressDutchAuction);
                //    function calPayTokenBuyAmount(uint _blockNum, address _seller, address _tokenSell, uint _tokenSellAmount, address _tokenBuy, uint _buyHighestAmount, uint _sellId,       uint _getTokenSellAmount) external view override returns(uint _payTokenBuyAmount)
                Contract.DutchAuction.ContractDefinition.CalPayTokenBuyAmountFunction param = new Contract.DutchAuction.ContractDefinition.CalPayTokenBuyAmountFunction()
                {
                    BlockNum = Common.Web3Helper.GetNowBlockNuber(ShareParam.Web3Url) + 1,
                    Seller = m._seller,
                    TokenSell = m._tokenSell,
                    TokenBuy = m._tokenBuy,
                    TokenSellAmount = BigInteger.Parse(m._tokenSellAmount_Text),
                    BuyHighestAmount = BigInteger.Parse(m._buyHighestAmount_Text),
                    SellId = m._sellId,
                    //GetTokenSellAmount = (BigInteger)((double)_GetTokenSellAmount * Math.Pow(10, Share.BLL.Token.GetTokenDecimals(m._tokenSell)))
                    GetTokenSellAmount = Common.SolidityHelper.GetTokenBigIntAmount(_GetTokenSellAmount, Share.BLL.Token.GetTokenDecimals(m._tokenSell))

                };

                BigInteger Big_TokenBuyAmount = service.CalPayTokenBuyAmountQueryAsync(param).Result;
                var TokenBuyAmount = (decimal)Big_TokenBuyAmount / (decimal)ShareParam.getPowerValue(Share.BLL.Token.GetTokenDecimals(m._tokenBuy));

                TextBoxPayTokenBuyAmount.Text = TokenBuyAmount.ToString();                          // 因为舍入原因，这个数据有时候会失真，会比真实数据少一点，导致交易无法完成！
                TextBoxPayTokenBuyAmount.Tag = Big_TokenBuyAmount;                                  // 使用这个值就可以避免数据失真！
                LabelPrice.Content = (TokenBuyAmount / _GetTokenSellAmount).ToString();             // 更新价格！
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show("获取最新价格失败，请重新录入购买金额。");
            }
            finally
            {
                ((IMainWindow)App.Current.MainWindow).ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }


        /// <summary>
        /// 外部调用
        /// </summary>
        /// <param name="sellModel"></param>
        /// <param name="_owner"></param>
        /// <returns></returns>
        public static bool Buy(Model.DutchAuctionTokenSell sellModel, Window _owner)
        {
            WindowDutchAuctionBuy w = new WindowDutchAuctionBuy();
            w.Owner = _owner;
            w.ThisSellModel = sellModel;
            w.LabelTokenSell.Content = Share.BLL.Token.GetModel(sellModel._tokenSell).Symbol;
            w.LabelTokenAmount.Content = sellModel.curTokenSellAmount.ToString();
            w.LabelTokenBuy.Content = Share.BLL.Token.GetModel(sellModel._tokenBuy).Symbol;
            w.LabelPrice.Content = sellModel.next1Price.ToString();                                     // 需要更新价格！

            bool result = w.ShowDialog() == true;
            return result;
        }

        
    }

}
