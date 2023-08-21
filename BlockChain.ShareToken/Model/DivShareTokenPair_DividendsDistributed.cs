
//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/5/17 15:58:19
//
using System;
using System.Data;
using System.Collections.Generic;

namespace BlockChain.ShareToken.Model
{
[Serializable]
public class DivShareTokenPair_DividendsDistributed
{
    #region 生成该数据实体的SQL语句
    public const string SQL = @"Select Top(1) * From DivShareTokenPair_DividendsDistributed";
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

    private System.DateTime _CreateTime = System.DateTime.Now;
    public System.DateTime CreateTime
    {
        get {return _CreateTime;}
        set {_CreateTime = value;}
    }

    private System.String _DivTokenAddress = System.String.Empty;
    public System.String DivTokenAddress
    {
        get {return _DivTokenAddress;}
        set {_DivTokenAddress = value;}
    }

    private System.Int64 __dividendIndex;
    public System.Int64 _dividendIndex
    {
        get {return __dividendIndex;}
        set {__dividendIndex = value;}
    }

    private System.String __from = System.String.Empty;
    public System.String _from
    {
        get {return __from;}
        set {__from = value;}
    }

    private System.Double __divAmount;
    public System.Double _divAmount
    {
        get {return __divAmount;}
        set {__divAmount = value;}
    }

    private System.Double __currentLiqValue;
    public System.Double _currentLiqValue
    {
        get {return __currentLiqValue;}
        set {__currentLiqValue = value;}
    }

    private System.Double __shareTokenHeight;
    public System.Double _shareTokenHeight
    {
        get {return __shareTokenHeight;}
        set {__shareTokenHeight = value;}
    }

    private System.Double __pairHeight;
    public System.Double _pairHeight
    {
        get {return __pairHeight;}
        set {__pairHeight = value;}
    }

    private System.String __pairHeight_Text = System.String.Empty;
    public System.String _pairHeight_Text
    {
        get {return __pairHeight_Text;}
        set {__pairHeight_Text = value;}
    }

    private System.String __shareTokenHeight_Text = System.String.Empty;
    public System.String _shareTokenHeight_Text
    {
        get {return __shareTokenHeight_Text;}
        set {__shareTokenHeight_Text = value;}
    }

    private System.String __divAmount_Text = System.String.Empty;
    public System.String _divAmount_Text
    {
        get {return __divAmount_Text;}
        set {__divAmount_Text = value;}
    }

    private System.String __currentLiqValue_Text = System.String.Empty;
    public System.String _currentLiqValue_Text
    {
        get {return __currentLiqValue_Text;}
        set {__currentLiqValue_Text = value;}
    }

    #endregion

    #region Public construct

    public DivShareTokenPair_DividendsDistributed()
    {
    }

    
    public DivShareTokenPair_DividendsDistributed(System.Int32 AChainId,System.String AContractAddress,System.String ATransactionHash)
    {
        _ChainId = AChainId;
        _ContractAddress = AContractAddress;
        _TransactionHash = ATransactionHash;
    }

    #endregion

    #region Public DataRow2Object

    public static DivShareTokenPair_DividendsDistributed DataRow2Object(System.Data.DataRow dr)
    {
        if (dr == null)
        {
            return null;
        }
        DivShareTokenPair_DividendsDistributed Obj = new DivShareTokenPair_DividendsDistributed();
        Obj.ChainId = dr["ChainId"] == DBNull.Value ? 0 : (System.Int32)(dr["ChainId"]);
        Obj.ContractAddress = dr["ContractAddress"] == DBNull.Value ? string.Empty : (System.String)(dr["ContractAddress"]);
        Obj.BlockNumber = dr["BlockNumber"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["BlockNumber"]);
        Obj.TransactionHash = dr["TransactionHash"] == DBNull.Value ? string.Empty : (System.String)(dr["TransactionHash"]);
        Obj.CreateTime = dr["CreateTime"] == DBNull.Value ? System.DateTime.Now : (System.DateTime)(dr["CreateTime"]);
        Obj.DivTokenAddress = dr["DivTokenAddress"] == DBNull.Value ? string.Empty : (System.String)(dr["DivTokenAddress"]);
        Obj._dividendIndex = dr["_dividendIndex"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["_dividendIndex"]);
        Obj._from = dr["_from"] == DBNull.Value ? string.Empty : (System.String)(dr["_from"]);
        Obj._divAmount = dr["_divAmount"] == DBNull.Value ? 0 : (System.Double)(dr["_divAmount"]);
        Obj._currentLiqValue = dr["_currentLiqValue"] == DBNull.Value ? 0 : (System.Double)(dr["_currentLiqValue"]);
        Obj._shareTokenHeight = dr["_shareTokenHeight"] == DBNull.Value ? 0 : (System.Double)(dr["_shareTokenHeight"]);
        Obj._pairHeight = dr["_pairHeight"] == DBNull.Value ? 0 : (System.Double)(dr["_pairHeight"]);
        Obj._pairHeight_Text = dr["_pairHeight_Text"] == DBNull.Value ? string.Empty : (System.String)(dr["_pairHeight_Text"]);
        Obj._shareTokenHeight_Text = dr["_shareTokenHeight_Text"] == DBNull.Value ? string.Empty : (System.String)(dr["_shareTokenHeight_Text"]);
        Obj._divAmount_Text = dr["_divAmount_Text"] == DBNull.Value ? string.Empty : (System.String)(dr["_divAmount_Text"]);
        Obj._currentLiqValue_Text = dr["_currentLiqValue_Text"] == DBNull.Value ? string.Empty : (System.String)(dr["_currentLiqValue_Text"]);
        return Obj;
    }

    #endregion


        public void ValidateDataLen()
        {
if (this.ContractAddress != null && this.ContractAddress.Length > FL_ContractAddress && FL_ContractAddress > 0) throw new Exception("ContractAddress要求长度小于等于" + FL_ContractAddress.ToString() + "。");
if (this.TransactionHash != null && this.TransactionHash.Length > FL_TransactionHash && FL_TransactionHash > 0) throw new Exception("TransactionHash要求长度小于等于" + FL_TransactionHash.ToString() + "。");
if (this.DivTokenAddress != null && this.DivTokenAddress.Length > FL_DivTokenAddress && FL_DivTokenAddress > 0) throw new Exception("DivTokenAddress要求长度小于等于" + FL_DivTokenAddress.ToString() + "。");
if (this._from != null && this._from.Length > FL__from && FL__from > 0) throw new Exception("_from要求长度小于等于" + FL__from.ToString() + "。");
if (this._pairHeight_Text != null && this._pairHeight_Text.Length > FL__pairHeight_Text && FL__pairHeight_Text > 0) throw new Exception("_pairHeight_Text要求长度小于等于" + FL__pairHeight_Text.ToString() + "。");
if (this._shareTokenHeight_Text != null && this._shareTokenHeight_Text.Length > FL__shareTokenHeight_Text && FL__shareTokenHeight_Text > 0) throw new Exception("_shareTokenHeight_Text要求长度小于等于" + FL__shareTokenHeight_Text.ToString() + "。");
if (this._divAmount_Text != null && this._divAmount_Text.Length > FL__divAmount_Text && FL__divAmount_Text > 0) throw new Exception("_divAmount_Text要求长度小于等于" + FL__divAmount_Text.ToString() + "。");
if (this._currentLiqValue_Text != null && this._currentLiqValue_Text.Length > FL__currentLiqValue_Text && FL__currentLiqValue_Text > 0) throw new Exception("_currentLiqValue_Text要求长度小于等于" + FL__currentLiqValue_Text.ToString() + "。");
}


        public void ValidateNotEmpty()
        {
if (string.IsNullOrEmpty(this.ContractAddress) || string.IsNullOrEmpty(this.ContractAddress.Trim())) throw new Exception("ContractAddress要求不空。");
if (string.IsNullOrEmpty(this.TransactionHash) || string.IsNullOrEmpty(this.TransactionHash.Trim())) throw new Exception("TransactionHash要求不空。");
if (string.IsNullOrEmpty(this.DivTokenAddress) || string.IsNullOrEmpty(this.DivTokenAddress.Trim())) throw new Exception("DivTokenAddress要求不空。");
if (string.IsNullOrEmpty(this._from) || string.IsNullOrEmpty(this._from.Trim())) throw new Exception("_from要求不空。");
if (string.IsNullOrEmpty(this._pairHeight_Text) || string.IsNullOrEmpty(this._pairHeight_Text.Trim())) throw new Exception("_pairHeight_Text要求不空。");
if (string.IsNullOrEmpty(this._shareTokenHeight_Text) || string.IsNullOrEmpty(this._shareTokenHeight_Text.Trim())) throw new Exception("_shareTokenHeight_Text要求不空。");
if (string.IsNullOrEmpty(this._divAmount_Text) || string.IsNullOrEmpty(this._divAmount_Text.Trim())) throw new Exception("_divAmount_Text要求不空。");
if (string.IsNullOrEmpty(this._currentLiqValue_Text) || string.IsNullOrEmpty(this._currentLiqValue_Text.Trim())) throw new Exception("_currentLiqValue_Text要求不空。");
}



        public void ValidateEmptyAndLen()
        {
            this.ValidateDataLen();
            this.ValidateNotEmpty();
        }


public DivShareTokenPair_DividendsDistributed Copy()
{
    DivShareTokenPair_DividendsDistributed obj = new DivShareTokenPair_DividendsDistributed();
    obj.ChainId = this.ChainId;
    obj.ContractAddress = this.ContractAddress;
    obj.BlockNumber = this.BlockNumber;
    obj.TransactionHash = this.TransactionHash;
    obj.CreateTime = this.CreateTime;
    obj.DivTokenAddress = this.DivTokenAddress;
    obj._dividendIndex = this._dividendIndex;
    obj._from = this._from;
    obj._divAmount = this._divAmount;
    obj._currentLiqValue = this._currentLiqValue;
    obj._shareTokenHeight = this._shareTokenHeight;
    obj._pairHeight = this._pairHeight;
    obj._pairHeight_Text = this._pairHeight_Text;
    obj._shareTokenHeight_Text = this._shareTokenHeight_Text;
    obj._divAmount_Text = this._divAmount_Text;
    obj._currentLiqValue_Text = this._currentLiqValue_Text;
    return obj;
}



        public static List<DivShareTokenPair_DividendsDistributed> DataTable2List(System.Data.DataTable dt)
        {
            List<DivShareTokenPair_DividendsDistributed> result = new List<DivShareTokenPair_DividendsDistributed>();
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                result.Add(DivShareTokenPair_DividendsDistributed.DataRow2Object(dr));
            }
            return result;
        }



        private static DivShareTokenPair_DividendsDistributed _NullObject = null;

        public static  DivShareTokenPair_DividendsDistributed NullObject
        {
            get
            {
                if (_NullObject == null)
                {
                    _NullObject = new DivShareTokenPair_DividendsDistributed();
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
        /// 字段 CreateTime 的长度——8
        /// </summary>
        public const int FL_CreateTime = 8;


        /// <summary>
        /// 字段 DivTokenAddress 的长度——43
        /// </summary>
        public const int FL_DivTokenAddress = 43;


        /// <summary>
        /// 字段 _dividendIndex 的长度——8
        /// </summary>
        public const int FL__dividendIndex = 8;


        /// <summary>
        /// 字段 _from 的长度——43
        /// </summary>
        public const int FL__from = 43;


        /// <summary>
        /// 字段 _divAmount 的长度——8
        /// </summary>
        public const int FL__divAmount = 8;


        /// <summary>
        /// 字段 _currentLiqValue 的长度——8
        /// </summary>
        public const int FL__currentLiqValue = 8;


        /// <summary>
        /// 字段 _shareTokenHeight 的长度——8
        /// </summary>
        public const int FL__shareTokenHeight = 8;


        /// <summary>
        /// 字段 _pairHeight 的长度——8
        /// </summary>
        public const int FL__pairHeight = 8;


        /// <summary>
        /// 字段 _pairHeight_Text 的长度——80
        /// </summary>
        public const int FL__pairHeight_Text = 80;


        /// <summary>
        /// 字段 _shareTokenHeight_Text 的长度——80
        /// </summary>
        public const int FL__shareTokenHeight_Text = 80;


        /// <summary>
        /// 字段 _divAmount_Text 的长度——80
        /// </summary>
        public const int FL__divAmount_Text = 80;


        /// <summary>
        /// 字段 _currentLiqValue_Text 的长度——80
        /// </summary>
        public const int FL__currentLiqValue_Text = 80;


        #endregion
}



}