
//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/5/17 15:44:11
//
using System;
using System.Data;
using System.Collections.Generic;

namespace BlockChain.ShareToken.Model
{
[Serializable]
public class DutchAuction_OnBuy
{
    #region 生成该数据实体的SQL语句
    public const string SQL = @"Select Top(1) * From DutchAuction_OnBuy";
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

    private System.String __buyer = System.String.Empty;
    public System.String _buyer
    {
        get {return __buyer;}
        set {__buyer = value;}
    }

    private System.String __seller = System.String.Empty;
    public System.String _seller
    {
        get {return __seller;}
        set {__seller = value;}
    }

    private System.String __sellHash = System.String.Empty;
    public System.String _sellHash
    {
        get {return __sellHash;}
        set {__sellHash = value;}
    }

    private System.Double __sellTokenAmountOut;
    public System.Double _sellTokenAmountOut
    {
        get {return __sellTokenAmountOut;}
        set {__sellTokenAmountOut = value;}
    }

    private System.Double __buyTokenAmountIn;
    public System.Double _buyTokenAmountIn
    {
        get {return __buyTokenAmountIn;}
        set {__buyTokenAmountIn = value;}
    }

    private System.String __sellTokenAmountOut_Text = System.String.Empty;
    public System.String _sellTokenAmountOut_Text
    {
        get {return __sellTokenAmountOut_Text;}
        set {__sellTokenAmountOut_Text = value;}
    }

    private System.String __buyTokenAmountIn_Text = System.String.Empty;
    public System.String _buyTokenAmountIn_Text
    {
        get {return __buyTokenAmountIn_Text;}
        set {__buyTokenAmountIn_Text = value;}
    }

    #endregion

    #region Public construct

    public DutchAuction_OnBuy()
    {
    }

    
    public DutchAuction_OnBuy(System.Int32 AChainId,System.String AContractAddress,System.String A_sellHash)
    {
        _ChainId = AChainId;
        _ContractAddress = AContractAddress;
        __sellHash = A_sellHash;
    }

    #endregion

    #region Public DataRow2Object

    public static DutchAuction_OnBuy DataRow2Object(System.Data.DataRow dr)
    {
        if (dr == null)
        {
            return null;
        }
        DutchAuction_OnBuy Obj = new DutchAuction_OnBuy();
        Obj.ChainId = dr["ChainId"] == DBNull.Value ? 0 : (System.Int32)(dr["ChainId"]);
        Obj.ContractAddress = dr["ContractAddress"] == DBNull.Value ? string.Empty : (System.String)(dr["ContractAddress"]);
        Obj.BlockNumber = dr["BlockNumber"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["BlockNumber"]);
        Obj.TransactionHash = dr["TransactionHash"] == DBNull.Value ? string.Empty : (System.String)(dr["TransactionHash"]);
        Obj._buyer = dr["_buyer"] == DBNull.Value ? string.Empty : (System.String)(dr["_buyer"]);
        Obj._seller = dr["_seller"] == DBNull.Value ? string.Empty : (System.String)(dr["_seller"]);
        Obj._sellHash = dr["_sellHash"] == DBNull.Value ? string.Empty : (System.String)(dr["_sellHash"]);
        Obj._sellTokenAmountOut = dr["_sellTokenAmountOut"] == DBNull.Value ? 0 : (System.Double)(dr["_sellTokenAmountOut"]);
        Obj._buyTokenAmountIn = dr["_buyTokenAmountIn"] == DBNull.Value ? 0 : (System.Double)(dr["_buyTokenAmountIn"]);
        Obj._sellTokenAmountOut_Text = dr["_sellTokenAmountOut_Text"] == DBNull.Value ? string.Empty : (System.String)(dr["_sellTokenAmountOut_Text"]);
        Obj._buyTokenAmountIn_Text = dr["_buyTokenAmountIn_Text"] == DBNull.Value ? string.Empty : (System.String)(dr["_buyTokenAmountIn_Text"]);
        return Obj;
    }

    #endregion


        public void ValidateDataLen()
        {
if (this.ContractAddress != null && this.ContractAddress.Length > FL_ContractAddress && FL_ContractAddress > 0) throw new Exception("ContractAddress要求长度小于等于" + FL_ContractAddress.ToString() + "。");
if (this.TransactionHash != null && this.TransactionHash.Length > FL_TransactionHash && FL_TransactionHash > 0) throw new Exception("TransactionHash要求长度小于等于" + FL_TransactionHash.ToString() + "。");
if (this._buyer != null && this._buyer.Length > FL__buyer && FL__buyer > 0) throw new Exception("_buyer要求长度小于等于" + FL__buyer.ToString() + "。");
if (this._seller != null && this._seller.Length > FL__seller && FL__seller > 0) throw new Exception("_seller要求长度小于等于" + FL__seller.ToString() + "。");
if (this._sellHash != null && this._sellHash.Length > FL__sellHash && FL__sellHash > 0) throw new Exception("_sellHash要求长度小于等于" + FL__sellHash.ToString() + "。");
if (this._sellTokenAmountOut_Text != null && this._sellTokenAmountOut_Text.Length > FL__sellTokenAmountOut_Text && FL__sellTokenAmountOut_Text > 0) throw new Exception("_sellTokenAmountOut_Text要求长度小于等于" + FL__sellTokenAmountOut_Text.ToString() + "。");
if (this._buyTokenAmountIn_Text != null && this._buyTokenAmountIn_Text.Length > FL__buyTokenAmountIn_Text && FL__buyTokenAmountIn_Text > 0) throw new Exception("_buyTokenAmountIn_Text要求长度小于等于" + FL__buyTokenAmountIn_Text.ToString() + "。");
}


        public void ValidateNotEmpty()
        {
if (string.IsNullOrEmpty(this.ContractAddress) || string.IsNullOrEmpty(this.ContractAddress.Trim())) throw new Exception("ContractAddress要求不空。");
if (string.IsNullOrEmpty(this.TransactionHash) || string.IsNullOrEmpty(this.TransactionHash.Trim())) throw new Exception("TransactionHash要求不空。");
if (string.IsNullOrEmpty(this._buyer) || string.IsNullOrEmpty(this._buyer.Trim())) throw new Exception("_buyer要求不空。");
if (string.IsNullOrEmpty(this._seller) || string.IsNullOrEmpty(this._seller.Trim())) throw new Exception("_seller要求不空。");
if (string.IsNullOrEmpty(this._sellHash) || string.IsNullOrEmpty(this._sellHash.Trim())) throw new Exception("_sellHash要求不空。");
if (string.IsNullOrEmpty(this._sellTokenAmountOut_Text) || string.IsNullOrEmpty(this._sellTokenAmountOut_Text.Trim())) throw new Exception("_sellTokenAmountOut_Text要求不空。");
if (string.IsNullOrEmpty(this._buyTokenAmountIn_Text) || string.IsNullOrEmpty(this._buyTokenAmountIn_Text.Trim())) throw new Exception("_buyTokenAmountIn_Text要求不空。");
}



        public void ValidateEmptyAndLen()
        {
            this.ValidateDataLen();
            this.ValidateNotEmpty();
        }


public DutchAuction_OnBuy Copy()
{
    DutchAuction_OnBuy obj = new DutchAuction_OnBuy();
    obj.ChainId = this.ChainId;
    obj.ContractAddress = this.ContractAddress;
    obj.BlockNumber = this.BlockNumber;
    obj.TransactionHash = this.TransactionHash;
    obj._buyer = this._buyer;
    obj._seller = this._seller;
    obj._sellHash = this._sellHash;
    obj._sellTokenAmountOut = this._sellTokenAmountOut;
    obj._buyTokenAmountIn = this._buyTokenAmountIn;
    obj._sellTokenAmountOut_Text = this._sellTokenAmountOut_Text;
    obj._buyTokenAmountIn_Text = this._buyTokenAmountIn_Text;
    return obj;
}



        public static List<DutchAuction_OnBuy> DataTable2List(System.Data.DataTable dt)
        {
            List<DutchAuction_OnBuy> result = new List<DutchAuction_OnBuy>();
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                result.Add(DutchAuction_OnBuy.DataRow2Object(dr));
            }
            return result;
        }



        private static DutchAuction_OnBuy _NullObject = null;

        public static  DutchAuction_OnBuy NullObject
        {
            get
            {
                if (_NullObject == null)
                {
                    _NullObject = new DutchAuction_OnBuy();
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
        /// 字段 _buyer 的长度——43
        /// </summary>
        public const int FL__buyer = 43;


        /// <summary>
        /// 字段 _seller 的长度——43
        /// </summary>
        public const int FL__seller = 43;


        /// <summary>
        /// 字段 _sellHash 的长度——66
        /// </summary>
        public const int FL__sellHash = 66;


        /// <summary>
        /// 字段 _sellTokenAmountOut 的长度——8
        /// </summary>
        public const int FL__sellTokenAmountOut = 8;


        /// <summary>
        /// 字段 _buyTokenAmountIn 的长度——8
        /// </summary>
        public const int FL__buyTokenAmountIn = 8;


        /// <summary>
        /// 字段 _sellTokenAmountOut_Text 的长度——80
        /// </summary>
        public const int FL__sellTokenAmountOut_Text = 80;


        /// <summary>
        /// 字段 _buyTokenAmountIn_Text 的长度——80
        /// </summary>
        public const int FL__buyTokenAmountIn_Text = 80;


        #endregion
}



}