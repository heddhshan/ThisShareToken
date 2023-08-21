

using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace BlockChain.ShareToken.Model
{
    [Serializable]
    public class DutchAuctionTokenSell : INotifyPropertyChanged
    {
        #region 生成该数据实体的SQL语句
        public const string SQL = @"
SELECT   S.TransactionHash, S._tokenSell, S._tokenBuy, S._sellId, S._sellHash, S.curTokenSellAmount, S.next1Block, S.next1Price, S.next2Block, 
                S.next2Price, S.next3Block, S.next3Price, S.UpdateTime, 
                T1.Name AS TokenSellName, 
                CASE T1.Symbol WHEN NULL THEN S._tokenSell ELSE T1.Symbol END AS TokenSellSymbol,  
                '"" + BasePath + @""\' + T1.ImagePath AS TokenSellImagePath, 
                T2.Name AS TokenBuyName, 
                CASE T2.Symbol WHEN NULL THEN S._tokenBuy ELSE T2.Symbol END AS TokenBuySymbol,  
                '"" + BasePath + @""\' + T2.ImagePath AS TokenBuyImagePath, 
                P.tokenSellAmountBuyMin
FROM      DutchAuction_OnSell AS S 
                LEFT OUTER JOIN Token AS T1 ON S._tokenSell = T1.Address 
                LEFT OUTER JOIN Token AS T2 ON S._tokenBuy = T1.Address
                LEFT OUTER JOIN DutchAuctionParam AS P ON S.ContractAddress = P.ContractAddress 
";
        #endregion

        #region Public Properties


        private System.String _TransactionHash = System.String.Empty;
        public System.String TransactionHash
        {
            get { return _TransactionHash; }
            set { _TransactionHash = value; }
        }


        private System.String __tokenSell = System.String.Empty;
        public System.String _tokenSell
        {
            get { return __tokenSell; }
            set { __tokenSell = value; }
        }

        private System.String __tokenBuy = System.String.Empty;
        public System.String _tokenBuy
        {
            get { return __tokenBuy; }
            set { __tokenBuy = value; }
        }

        private System.Int64 __sellId;
        public System.Int64 _sellId
        {
            get { return __sellId; }
            set { __sellId = value; }
        }

        private System.String __sellHash = System.String.Empty;
        public System.String _sellHash
        {
            get { return __sellHash; }
            set { __sellHash = value; }
        }

        private System.Double _curTokenSellAmount;
        public System.Double curTokenSellAmount
        {
            get { return _curTokenSellAmount; }
            set
            {
                _curTokenSellAmount = value;
                OnPropertyChanged("curTokenSellAmount");
            }
        }

        private System.Int64 _next1Block;
        public System.Int64 next1Block
        {
            get { return _next1Block; }
            set
            {
                _next1Block = value;
                OnPropertyChanged("next1Block");
            }
        }

        private System.Double _next1Price;
        public System.Double next1Price
        {
            get { return _next1Price; }
            set
            {
                _next1Price = value;
                OnPropertyChanged("next1Price");
            }
        }

        private System.Int64 _next2Block;
        public System.Int64 next2Block
        {
            get { return _next2Block; }
            set
            {
                _next2Block = value;
                OnPropertyChanged("next2Block");
            }
        }

        private System.Double _next2Price;
        public System.Double next2Price
        {
            get { return _next2Price; }
            set
            {
                _next2Price = value;
                OnPropertyChanged("next2Price");
            }
        }

        private System.Int64 _next3Block;
        public System.Int64 next3Block
        {
            get { return _next3Block; }
            set
            {
                _next3Block = value;
                OnPropertyChanged("next3Block");
            }
        }

        private System.Double _next3Price;
        public System.Double next3Price
        {
            get { return _next3Price; }
            set
            {
                _next3Price = value;
                OnPropertyChanged("next3Price");
            }
        }

        private System.DateTime _UpdateTime = System.DateTime.Now;
        public System.DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set
            {
                _UpdateTime = value;
                OnPropertyChanged("UpdateTime");
            }
        }

        private System.String _TokenSellName = System.String.Empty;
        public System.String TokenSellName
        {
            get { return _TokenSellName; }
            set { _TokenSellName = value; }
        }

        private System.String _TokenSellSymbol = System.String.Empty;
        public System.String TokenSellSymbol
        {
            get { return _TokenSellSymbol; }
            set { _TokenSellSymbol = value; }
        }

        private System.String _TokenSellImagePath = System.String.Empty;
        public System.String TokenSellImagePath
        {
            get { return _TokenSellImagePath; }
            set { _TokenSellImagePath = value; }
        }

        private System.String _TokenBuyName = System.String.Empty;
        public System.String TokenBuyName
        {
            get { return _TokenBuyName; }
            set { _TokenBuyName = value; }
        }

        private System.String _TokenBuySymbol = System.String.Empty;
        public System.String TokenBuySymbol
        {
            get { return _TokenBuySymbol; }
            set { _TokenBuySymbol = value; }
        }

        private System.String _TokenBuyImagePath = System.String.Empty;
        public System.String TokenBuyImagePath
        {
            get { return _TokenBuyImagePath; }
            set { _TokenBuyImagePath = value; }
        }

        private System.Double _tokenSellAmountBuyMin;
        public System.Double tokenSellAmountBuyMin
        {
            get { return _tokenSellAmountBuyMin; }
            set
            {
                _tokenSellAmountBuyMin = value;
                OnPropertyChanged("tokenSellAmountBuyMin");
            }
        }

        #endregion

        #region Public construct

        public DutchAuctionTokenSell()
        {
        }


        public DutchAuctionTokenSell(System.String ATokenSellImagePath, System.String ATokenBuyImagePath)
        {
            _TokenSellImagePath = ATokenSellImagePath;
            _TokenBuyImagePath = ATokenBuyImagePath;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Public DataRow2Object

        public static DutchAuctionTokenSell? DataRow2Object(System.Data.DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            DutchAuctionTokenSell Obj = new DutchAuctionTokenSell();
            Obj.TransactionHash = dr["TransactionHash"] == DBNull.Value ? string.Empty : (System.String)(dr["TransactionHash"]);
            Obj._tokenSell = dr["_tokenSell"] == DBNull.Value ? string.Empty : (System.String)(dr["_tokenSell"]);
            Obj._tokenBuy = dr["_tokenBuy"] == DBNull.Value ? string.Empty : (System.String)(dr["_tokenBuy"]);
            Obj._sellId = dr["_sellId"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["_sellId"]);
            Obj._sellHash = dr["_sellHash"] == DBNull.Value ? string.Empty : (System.String)(dr["_sellHash"]);
            Obj.curTokenSellAmount = dr["curTokenSellAmount"] == DBNull.Value ? 0 : (System.Double)(dr["curTokenSellAmount"]);
            Obj.next1Block = dr["next1Block"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["next1Block"]);
            Obj.next1Price = dr["next1Price"] == DBNull.Value ? 0 : (System.Double)(dr["next1Price"]);
            Obj.next2Block = dr["next2Block"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["next2Block"]);
            Obj.next2Price = dr["next2Price"] == DBNull.Value ? 0 : (System.Double)(dr["next2Price"]);
            Obj.next3Block = dr["next3Block"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["next3Block"]);
            Obj.next3Price = dr["next3Price"] == DBNull.Value ? 0 : (System.Double)(dr["next3Price"]);
            Obj.UpdateTime = dr["UpdateTime"] == DBNull.Value ? new DateTime(1970, 1, 1) : (System.DateTime)(dr["UpdateTime"]);
            Obj.TokenSellName = dr["TokenSellName"] == DBNull.Value ? string.Empty : (System.String)(dr["TokenSellName"]);
            Obj.TokenSellSymbol = dr["TokenSellSymbol"] == DBNull.Value ? string.Empty : (System.String)(dr["TokenSellSymbol"]);
            Obj.TokenSellImagePath = dr["TokenSellImagePath"] == DBNull.Value ? string.Empty : (System.String)(dr["TokenSellImagePath"]);
            Obj.TokenBuyName = dr["TokenBuyName"] == DBNull.Value ? string.Empty : (System.String)(dr["TokenBuyName"]);
            Obj.TokenBuySymbol = dr["TokenBuySymbol"] == DBNull.Value ? string.Empty : (System.String)(dr["TokenBuySymbol"]);
            Obj.TokenBuyImagePath = dr["TokenBuyImagePath"] == DBNull.Value ? string.Empty : (System.String)(dr["TokenBuyImagePath"]);
            Obj.tokenSellAmountBuyMin = dr["tokenSellAmountBuyMin"] == DBNull.Value ? 0 : (System.Double)(dr["tokenSellAmountBuyMin"]);
            return Obj;
        }



        #endregion

        public static ObservableCollection<DutchAuctionTokenSell> DataTable2List(System.Data.DataTable dt)
        {
            ObservableCollection<DutchAuctionTokenSell> result = new ObservableCollection<DutchAuctionTokenSell>();
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                var obj = DutchAuctionTokenSell.DataRow2Object(dr);
                if (obj != null)
                    result.Add(obj);
            }
            return result;
        }


    }



}