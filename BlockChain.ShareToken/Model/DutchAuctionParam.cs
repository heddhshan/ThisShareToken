
//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/5/17 15:44:11
//
using System;
using System.Data;
using System.Collections.Generic;

namespace BlockChain.ShareToken.Model
{
[Serializable]
public class DutchAuctionParam
{
    #region 生成该数据实体的SQL语句
    public const string SQL = @"Select Top(1) * From DutchAuctionParam";
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

    private System.String _tokenSell = System.String.Empty;
    public System.String tokenSell
    {
        get {return _tokenSell;}
        set {_tokenSell = value;}
    }

    private System.Double _tokenSellAmountSellMin;
    public System.Double tokenSellAmountSellMin
    {
        get {return _tokenSellAmountSellMin;}
        set {_tokenSellAmountSellMin = value;}
    }

    private System.Double _tokenSellAmountBuyMin;
    public System.Double tokenSellAmountBuyMin
    {
        get {return _tokenSellAmountBuyMin;}
        set {_tokenSellAmountBuyMin = value;}
    }

    private System.DateTime _UpdateTime = System.DateTime.Now;
    public System.DateTime UpdateTime
    {
        get {return _UpdateTime;}
        set {_UpdateTime = value;}
    }

    private System.String _tokenSellAmountSellMin_Text = System.String.Empty;
    public System.String tokenSellAmountSellMin_Text
    {
        get {return _tokenSellAmountSellMin_Text;}
        set {_tokenSellAmountSellMin_Text = value;}
    }

    private System.String _tokenSellAmountBuyMin_Text = System.String.Empty;
    public System.String tokenSellAmountBuyMin_Text
    {
        get {return _tokenSellAmountBuyMin_Text;}
        set {_tokenSellAmountBuyMin_Text = value;}
    }

    #endregion

    #region Public construct

    public DutchAuctionParam()
    {
    }

    
    public DutchAuctionParam(System.Int32 AChainId,System.String AContractAddress,System.String AtokenSell)
    {
        _ChainId = AChainId;
        _ContractAddress = AContractAddress;
        _tokenSell = AtokenSell;
    }

    #endregion

    #region Public DataRow2Object

    public static DutchAuctionParam DataRow2Object(System.Data.DataRow dr)
    {
        if (dr == null)
        {
            return null;
        }
        DutchAuctionParam Obj = new DutchAuctionParam();
        Obj.ChainId = dr["ChainId"] == DBNull.Value ? 0 : (System.Int32)(dr["ChainId"]);
        Obj.ContractAddress = dr["ContractAddress"] == DBNull.Value ? string.Empty : (System.String)(dr["ContractAddress"]);
        Obj.tokenSell = dr["tokenSell"] == DBNull.Value ? string.Empty : (System.String)(dr["tokenSell"]);
        Obj.tokenSellAmountSellMin = dr["tokenSellAmountSellMin"] == DBNull.Value ? 0 : (System.Double)(dr["tokenSellAmountSellMin"]);
        Obj.tokenSellAmountBuyMin = dr["tokenSellAmountBuyMin"] == DBNull.Value ? 0 : (System.Double)(dr["tokenSellAmountBuyMin"]);
        Obj.UpdateTime = dr["UpdateTime"] == DBNull.Value ? System.DateTime.Now : (System.DateTime)(dr["UpdateTime"]);
        Obj.tokenSellAmountSellMin_Text = dr["tokenSellAmountSellMin_Text"] == DBNull.Value ? string.Empty : (System.String)(dr["tokenSellAmountSellMin_Text"]);
        Obj.tokenSellAmountBuyMin_Text = dr["tokenSellAmountBuyMin_Text"] == DBNull.Value ? string.Empty : (System.String)(dr["tokenSellAmountBuyMin_Text"]);
        return Obj;
    }

    #endregion


        public void ValidateDataLen()
        {
if (this.ContractAddress != null && this.ContractAddress.Length > FL_ContractAddress && FL_ContractAddress > 0) throw new Exception("ContractAddress要求长度小于等于" + FL_ContractAddress.ToString() + "。");
if (this.tokenSell != null && this.tokenSell.Length > FL_tokenSell && FL_tokenSell > 0) throw new Exception("tokenSell要求长度小于等于" + FL_tokenSell.ToString() + "。");
if (this.tokenSellAmountSellMin_Text != null && this.tokenSellAmountSellMin_Text.Length > FL_tokenSellAmountSellMin_Text && FL_tokenSellAmountSellMin_Text > 0) throw new Exception("tokenSellAmountSellMin_Text要求长度小于等于" + FL_tokenSellAmountSellMin_Text.ToString() + "。");
if (this.tokenSellAmountBuyMin_Text != null && this.tokenSellAmountBuyMin_Text.Length > FL_tokenSellAmountBuyMin_Text && FL_tokenSellAmountBuyMin_Text > 0) throw new Exception("tokenSellAmountBuyMin_Text要求长度小于等于" + FL_tokenSellAmountBuyMin_Text.ToString() + "。");
}


        public void ValidateNotEmpty()
        {
if (string.IsNullOrEmpty(this.ContractAddress) || string.IsNullOrEmpty(this.ContractAddress.Trim())) throw new Exception("ContractAddress要求不空。");
if (string.IsNullOrEmpty(this.tokenSell) || string.IsNullOrEmpty(this.tokenSell.Trim())) throw new Exception("tokenSell要求不空。");
if (string.IsNullOrEmpty(this.tokenSellAmountSellMin_Text) || string.IsNullOrEmpty(this.tokenSellAmountSellMin_Text.Trim())) throw new Exception("tokenSellAmountSellMin_Text要求不空。");
if (string.IsNullOrEmpty(this.tokenSellAmountBuyMin_Text) || string.IsNullOrEmpty(this.tokenSellAmountBuyMin_Text.Trim())) throw new Exception("tokenSellAmountBuyMin_Text要求不空。");
}



        public void ValidateEmptyAndLen()
        {
            this.ValidateDataLen();
            this.ValidateNotEmpty();
        }


public DutchAuctionParam Copy()
{
    DutchAuctionParam obj = new DutchAuctionParam();
    obj.ChainId = this.ChainId;
    obj.ContractAddress = this.ContractAddress;
    obj.tokenSell = this.tokenSell;
    obj.tokenSellAmountSellMin = this.tokenSellAmountSellMin;
    obj.tokenSellAmountBuyMin = this.tokenSellAmountBuyMin;
    obj.UpdateTime = this.UpdateTime;
    obj.tokenSellAmountSellMin_Text = this.tokenSellAmountSellMin_Text;
    obj.tokenSellAmountBuyMin_Text = this.tokenSellAmountBuyMin_Text;
    return obj;
}



        public static List<DutchAuctionParam> DataTable2List(System.Data.DataTable dt)
        {
            List<DutchAuctionParam> result = new List<DutchAuctionParam>();
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                result.Add(DutchAuctionParam.DataRow2Object(dr));
            }
            return result;
        }



        private static DutchAuctionParam _NullObject = null;

        public static  DutchAuctionParam NullObject
        {
            get
            {
                if (_NullObject == null)
                {
                    _NullObject = new DutchAuctionParam();
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
        /// 字段 tokenSell 的长度——43
        /// </summary>
        public const int FL_tokenSell = 43;


        /// <summary>
        /// 字段 tokenSellAmountSellMin 的长度——8
        /// </summary>
        public const int FL_tokenSellAmountSellMin = 8;


        /// <summary>
        /// 字段 tokenSellAmountBuyMin 的长度——8
        /// </summary>
        public const int FL_tokenSellAmountBuyMin = 8;


        /// <summary>
        /// 字段 UpdateTime 的长度——8
        /// </summary>
        public const int FL_UpdateTime = 8;


        /// <summary>
        /// 字段 tokenSellAmountSellMin_Text 的长度——80
        /// </summary>
        public const int FL_tokenSellAmountSellMin_Text = 80;


        /// <summary>
        /// 字段 tokenSellAmountBuyMin_Text 的长度——80
        /// </summary>
        public const int FL_tokenSellAmountBuyMin_Text = 80;


        #endregion
}



}