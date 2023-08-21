
//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/5/17 15:44:11
//
using System;
using System.Data;
using System.Collections.Generic;

namespace BlockChain.ShareToken.Model
{
[Serializable]
public class DutchAuction_OnSell
{
    #region 生成该数据实体的SQL语句
    public const string SQL = @"Select Top(1) * From DutchAuction_OnSell";
    #endregion

    #region Public Properties

    private System.Int32 _ChainId;
    public System.Int32 ChainId
    {
        get {return _ChainId;}
        set {_ChainId = value;}
    }

    private System.String _ContractAddress = System.String.Empty;
    public System.String ContractAddress
    {
        get {return _ContractAddress;}
        set {_ContractAddress = value;}
    }

    private System.Int64 _BlockNumber;
    public System.Int64 BlockNumber
    {
        get {return _BlockNumber;}
        set {_BlockNumber = value;}
    }

    private System.String _TransactionHash = System.String.Empty;
    public System.String TransactionHash
    {
        get {return _TransactionHash;}
        set {_TransactionHash = value;}
    }

    private System.String __seller = System.String.Empty;
    public System.String _seller
    {
        get {return __seller;}
        set {__seller = value;}
    }

    private System.String __tokenSell = System.String.Empty;
    public System.String _tokenSell
    {
        get {return __tokenSell;}
        set {__tokenSell = value;}
    }

    private System.Double __tokenSellAmount;
    public System.Double _tokenSellAmount
    {
        get {return __tokenSellAmount;}
        set {__tokenSellAmount = value;}
    }

    private System.String __tokenBuy = System.String.Empty;
    public System.String _tokenBuy
    {
        get {return __tokenBuy;}
        set {__tokenBuy = value;}
    }

    private System.Double __buyHighestAmount;
    public System.Double _buyHighestAmount
    {
        get {return __buyHighestAmount;}
        set {__buyHighestAmount = value;}
    }

    private System.Int64 __sellId;
    public System.Int64 _sellId
    {
        get {return __sellId;}
        set {__sellId = value;}
    }

    private System.String __sellHash = System.String.Empty;
    public System.String _sellHash
    {
        get {return __sellHash;}
        set {__sellHash = value;}
    }

    private System.Double _curTokenSellAmount;
    public System.Double curTokenSellAmount
    {
        get {return _curTokenSellAmount;}
        set {_curTokenSellAmount = value;}
    }

    private System.Int64 _next1Block;
    public System.Int64 next1Block
    {
        get {return _next1Block;}
        set {_next1Block = value;}
    }

    private System.Double _next1Price;
    public System.Double next1Price
    {
        get {return _next1Price;}
        set {_next1Price = value;}
    }

    private System.Int64 _next2Block;
    public System.Int64 next2Block
    {
        get {return _next2Block;}
        set {_next2Block = value;}
    }

    private System.Double _next2Price;
    public System.Double next2Price
    {
        get {return _next2Price;}
        set {_next2Price = value;}
    }

    private System.Int64 _next3Block;
    public System.Int64 next3Block
    {
        get {return _next3Block;}
        set {_next3Block = value;}
    }

    private System.Double _next3Price;
    public System.Double next3Price
    {
        get {return _next3Price;}
        set {_next3Price = value;}
    }

    private System.String __tokenSellAmount_Text = System.String.Empty;
    public System.String _tokenSellAmount_Text
    {
        get {return __tokenSellAmount_Text;}
        set {__tokenSellAmount_Text = value;}
    }

    private System.String __buyHighestAmount_Text = System.String.Empty;
    public System.String _buyHighestAmount_Text
    {
        get {return __buyHighestAmount_Text;}
        set {__buyHighestAmount_Text = value;}
    }

    private System.String _curTokenSellAmount_Text = System.String.Empty;
    public System.String curTokenSellAmount_Text
    {
        get {return _curTokenSellAmount_Text;}
        set {_curTokenSellAmount_Text = value;}
    }

    private System.DateTime _CreateTime = System.DateTime.Now;
    public System.DateTime CreateTime
    {
        get {return _CreateTime;}
        set {_CreateTime = value;}
    }

    private System.DateTime _UpdateTime = System.DateTime.Now;
    public System.DateTime UpdateTime
    {
        get {return _UpdateTime;}
        set {_UpdateTime = value;}
    }

    private System.Boolean _IsDone;
    public System.Boolean IsDone
    {
        get {return _IsDone;}
        set {_IsDone = value;}
    }

    #endregion

    #region Public construct

    public DutchAuction_OnSell()
    {
    }

    
    public DutchAuction_OnSell(System.Int32 AChainId,System.String AContractAddress,System.Int64 A_sellId)
    {
        _ChainId = AChainId;
        _ContractAddress = AContractAddress;
        __sellId = A_sellId;
    }

    #endregion

    #region Public DataRow2Object

    public static DutchAuction_OnSell DataRow2Object(System.Data.DataRow dr)
    {
        if (dr == null)
        {
            return null;
        }
        DutchAuction_OnSell Obj = new DutchAuction_OnSell();
        Obj.ChainId = dr["ChainId"] == DBNull.Value ? 0 : (System.Int32)(dr["ChainId"]);
        Obj.ContractAddress = dr["ContractAddress"] == DBNull.Value ? string.Empty : (System.String)(dr["ContractAddress"]);
        Obj.BlockNumber = dr["BlockNumber"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["BlockNumber"]);
        Obj.TransactionHash = dr["TransactionHash"] == DBNull.Value ? string.Empty : (System.String)(dr["TransactionHash"]);
        Obj._seller = dr["_seller"] == DBNull.Value ? string.Empty : (System.String)(dr["_seller"]);
        Obj._tokenSell = dr["_tokenSell"] == DBNull.Value ? string.Empty : (System.String)(dr["_tokenSell"]);
        Obj._tokenSellAmount = dr["_tokenSellAmount"] == DBNull.Value ? 0 : (System.Double)(dr["_tokenSellAmount"]);
        Obj._tokenBuy = dr["_tokenBuy"] == DBNull.Value ? string.Empty : (System.String)(dr["_tokenBuy"]);
        Obj._buyHighestAmount = dr["_buyHighestAmount"] == DBNull.Value ? 0 : (System.Double)(dr["_buyHighestAmount"]);
        Obj._sellId = dr["_sellId"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["_sellId"]);
        Obj._sellHash = dr["_sellHash"] == DBNull.Value ? string.Empty : (System.String)(dr["_sellHash"]);
        Obj.curTokenSellAmount = dr["curTokenSellAmount"] == DBNull.Value ? 0 : (System.Double)(dr["curTokenSellAmount"]);
        Obj.next1Block = dr["next1Block"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["next1Block"]);
        Obj.next1Price = dr["next1Price"] == DBNull.Value ? 0 : (System.Double)(dr["next1Price"]);
        Obj.next2Block = dr["next2Block"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["next2Block"]);
        Obj.next2Price = dr["next2Price"] == DBNull.Value ? 0 : (System.Double)(dr["next2Price"]);
        Obj.next3Block = dr["next3Block"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["next3Block"]);
        Obj.next3Price = dr["next3Price"] == DBNull.Value ? 0 : (System.Double)(dr["next3Price"]);
        Obj._tokenSellAmount_Text = dr["_tokenSellAmount_Text"] == DBNull.Value ? string.Empty : (System.String)(dr["_tokenSellAmount_Text"]);
        Obj._buyHighestAmount_Text = dr["_buyHighestAmount_Text"] == DBNull.Value ? string.Empty : (System.String)(dr["_buyHighestAmount_Text"]);
        Obj.curTokenSellAmount_Text = dr["curTokenSellAmount_Text"] == DBNull.Value ? string.Empty : (System.String)(dr["curTokenSellAmount_Text"]);
        Obj.CreateTime = dr["CreateTime"] == DBNull.Value ? System.DateTime.Now : (System.DateTime)(dr["CreateTime"]);
        Obj.UpdateTime = dr["UpdateTime"] == DBNull.Value ? System.DateTime.Now : (System.DateTime)(dr["UpdateTime"]);
        Obj.IsDone = dr["IsDone"] == DBNull.Value ? false : (System.Boolean)(dr["IsDone"]);
        return Obj;
    }

    #endregion


        public void ValidateDataLen()
        {
if (this.ContractAddress != null && this.ContractAddress.Length > FL_ContractAddress && FL_ContractAddress > 0) throw new Exception("ContractAddress要求长度小于等于" + FL_ContractAddress.ToString() + "。");
if (this.TransactionHash != null && this.TransactionHash.Length > FL_TransactionHash && FL_TransactionHash > 0) throw new Exception("TransactionHash要求长度小于等于" + FL_TransactionHash.ToString() + "。");
if (this._seller != null && this._seller.Length > FL__seller && FL__seller > 0) throw new Exception("_seller要求长度小于等于" + FL__seller.ToString() + "。");
if (this._tokenSell != null && this._tokenSell.Length > FL__tokenSell && FL__tokenSell > 0) throw new Exception("_tokenSell要求长度小于等于" + FL__tokenSell.ToString() + "。");
if (this._tokenBuy != null && this._tokenBuy.Length > FL__tokenBuy && FL__tokenBuy > 0) throw new Exception("_tokenBuy要求长度小于等于" + FL__tokenBuy.ToString() + "。");
if (this._sellHash != null && this._sellHash.Length > FL__sellHash && FL__sellHash > 0) throw new Exception("_sellHash要求长度小于等于" + FL__sellHash.ToString() + "。");
if (this._tokenSellAmount_Text != null && this._tokenSellAmount_Text.Length > FL__tokenSellAmount_Text && FL__tokenSellAmount_Text > 0) throw new Exception("_tokenSellAmount_Text要求长度小于等于" + FL__tokenSellAmount_Text.ToString() + "。");
if (this._buyHighestAmount_Text != null && this._buyHighestAmount_Text.Length > FL__buyHighestAmount_Text && FL__buyHighestAmount_Text > 0) throw new Exception("_buyHighestAmount_Text要求长度小于等于" + FL__buyHighestAmount_Text.ToString() + "。");
if (this.curTokenSellAmount_Text != null && this.curTokenSellAmount_Text.Length > FL_curTokenSellAmount_Text && FL_curTokenSellAmount_Text > 0) throw new Exception("curTokenSellAmount_Text要求长度小于等于" + FL_curTokenSellAmount_Text.ToString() + "。");
}


        public void ValidateNotEmpty()
        {
if (string.IsNullOrEmpty(this.ContractAddress) || string.IsNullOrEmpty(this.ContractAddress.Trim())) throw new Exception("ContractAddress要求不空。");
if (string.IsNullOrEmpty(this.TransactionHash) || string.IsNullOrEmpty(this.TransactionHash.Trim())) throw new Exception("TransactionHash要求不空。");
if (string.IsNullOrEmpty(this._seller) || string.IsNullOrEmpty(this._seller.Trim())) throw new Exception("_seller要求不空。");
if (string.IsNullOrEmpty(this._tokenSell) || string.IsNullOrEmpty(this._tokenSell.Trim())) throw new Exception("_tokenSell要求不空。");
if (string.IsNullOrEmpty(this._tokenBuy) || string.IsNullOrEmpty(this._tokenBuy.Trim())) throw new Exception("_tokenBuy要求不空。");
if (string.IsNullOrEmpty(this._sellHash) || string.IsNullOrEmpty(this._sellHash.Trim())) throw new Exception("_sellHash要求不空。");
if (string.IsNullOrEmpty(this._tokenSellAmount_Text) || string.IsNullOrEmpty(this._tokenSellAmount_Text.Trim())) throw new Exception("_tokenSellAmount_Text要求不空。");
if (string.IsNullOrEmpty(this._buyHighestAmount_Text) || string.IsNullOrEmpty(this._buyHighestAmount_Text.Trim())) throw new Exception("_buyHighestAmount_Text要求不空。");
}



        public void ValidateEmptyAndLen()
        {
            this.ValidateDataLen();
            this.ValidateNotEmpty();
        }


public DutchAuction_OnSell Copy()
{
    DutchAuction_OnSell obj = new DutchAuction_OnSell();
    obj.ChainId = this.ChainId;
    obj.ContractAddress = this.ContractAddress;
    obj.BlockNumber = this.BlockNumber;
    obj.TransactionHash = this.TransactionHash;
    obj._seller = this._seller;
    obj._tokenSell = this._tokenSell;
    obj._tokenSellAmount = this._tokenSellAmount;
    obj._tokenBuy = this._tokenBuy;
    obj._buyHighestAmount = this._buyHighestAmount;
    obj._sellId = this._sellId;
    obj._sellHash = this._sellHash;
    obj.curTokenSellAmount = this.curTokenSellAmount;
    obj.next1Block = this.next1Block;
    obj.next1Price = this.next1Price;
    obj.next2Block = this.next2Block;
    obj.next2Price = this.next2Price;
    obj.next3Block = this.next3Block;
    obj.next3Price = this.next3Price;
    obj._tokenSellAmount_Text = this._tokenSellAmount_Text;
    obj._buyHighestAmount_Text = this._buyHighestAmount_Text;
    obj.curTokenSellAmount_Text = this.curTokenSellAmount_Text;
    obj.CreateTime = this.CreateTime;
    obj.UpdateTime = this.UpdateTime;
    obj.IsDone = this.IsDone;
    return obj;
}



        public static List<DutchAuction_OnSell> DataTable2List(System.Data.DataTable dt)
        {
            List<DutchAuction_OnSell> result = new List<DutchAuction_OnSell>();
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                result.Add(DutchAuction_OnSell.DataRow2Object(dr));
            }
            return result;
        }



        private static DutchAuction_OnSell _NullObject = null;

        public static  DutchAuction_OnSell NullObject
        {
            get
            {
                if (_NullObject == null)
                {
                    _NullObject = new DutchAuction_OnSell();
                }
                return _NullObject;
            }
        }


        #region 字段长度

        /// <summary>
        /// 字段 ChainId 的长度——4
        /// </summary>
        public const int FL_ChainId = 4;


        /// <summary>
        /// 字段 ContractAddress 的长度——43
        /// </summary>
        public const int FL_ContractAddress = 43;


        /// <summary>
        /// 字段 BlockNumber 的长度——8
        /// </summary>
        public const int FL_BlockNumber = 8;


        /// <summary>
        /// 字段 TransactionHash 的长度——66
        /// </summary>
        public const int FL_TransactionHash = 66;


        /// <summary>
        /// 字段 _seller 的长度——43
        /// </summary>
        public const int FL__seller = 43;


        /// <summary>
        /// 字段 _tokenSell 的长度——43
        /// </summary>
        public const int FL__tokenSell = 43;


        /// <summary>
        /// 字段 _tokenSellAmount 的长度——8
        /// </summary>
        public const int FL__tokenSellAmount = 8;


        /// <summary>
        /// 字段 _tokenBuy 的长度——43
        /// </summary>
        public const int FL__tokenBuy = 43;


        /// <summary>
        /// 字段 _buyHighestAmount 的长度——8
        /// </summary>
        public const int FL__buyHighestAmount = 8;


        /// <summary>
        /// 字段 _sellId 的长度——8
        /// </summary>
        public const int FL__sellId = 8;


        /// <summary>
        /// 字段 _sellHash 的长度——66
        /// </summary>
        public const int FL__sellHash = 66;


        /// <summary>
        /// 字段 curTokenSellAmount 的长度——8
        /// </summary>
        public const int FL_curTokenSellAmount = 8;


        /// <summary>
        /// 字段 next1Block 的长度——8
        /// </summary>
        public const int FL_next1Block = 8;


        /// <summary>
        /// 字段 next1Price 的长度——8
        /// </summary>
        public const int FL_next1Price = 8;


        /// <summary>
        /// 字段 next2Block 的长度——8
        /// </summary>
        public const int FL_next2Block = 8;


        /// <summary>
        /// 字段 next2Price 的长度——8
        /// </summary>
        public const int FL_next2Price = 8;


        /// <summary>
        /// 字段 next3Block 的长度——8
        /// </summary>
        public const int FL_next3Block = 8;


        /// <summary>
        /// 字段 next3Price 的长度——8
        /// </summary>
        public const int FL_next3Price = 8;


        /// <summary>
        /// 字段 _tokenSellAmount_Text 的长度——80
        /// </summary>
        public const int FL__tokenSellAmount_Text = 80;


        /// <summary>
        /// 字段 _buyHighestAmount_Text 的长度——80
        /// </summary>
        public const int FL__buyHighestAmount_Text = 80;


        /// <summary>
        /// 字段 curTokenSellAmount_Text 的长度——80
        /// </summary>
        public const int FL_curTokenSellAmount_Text = 80;


        /// <summary>
        /// 字段 CreateTime 的长度——8
        /// </summary>
        public const int FL_CreateTime = 8;


        /// <summary>
        /// 字段 UpdateTime 的长度——8
        /// </summary>
        public const int FL_UpdateTime = 8;


        /// <summary>
        /// 字段 IsDone 的长度——1
        /// </summary>
        public const int FL_IsDone = 1;


        #endregion
}



}