
//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/5/17 15:58:19
//
using System;
using System.Data;
using System.Collections.Generic;

namespace BlockChain.ShareToken.Model
{
[Serializable]
public class BasicBusShareToken_DividendsDistributed
{
    #region 生成该数据实体的SQL语句
    public const string SQL = @"Select Top(1) * From BasicBusShareToken_DividendsDistributed";
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

    private System.String _DivToken = System.String.Empty;
    public System.String DivToken
    {
        get {return _DivToken;}
        set {_DivToken = value;}
    }

    private System.Int64 __dividendIndex;
    public System.Int64 _dividendIndex
    {
        get {return __dividendIndex;}
        set {__dividendIndex = value;}
    }

    private System.String __caller = System.String.Empty;
    public System.String _caller
    {
        get {return __caller;}
        set {__caller = value;}
    }

    private System.Double __waitingDivAmount;
    public System.Double _waitingDivAmount
    {
        get {return __waitingDivAmount;}
        set {__waitingDivAmount = value;}
    }

    private System.Double __realDivAmount;
    public System.Double _realDivAmount
    {
        get {return __realDivAmount;}
        set {__realDivAmount = value;}
    }

    private System.Double __currentSupply;
    public System.Double _currentSupply
    {
        get {return __currentSupply;}
        set {__currentSupply = value;}
    }

    private System.Double __divHeight;
    public System.Double _divHeight
    {
        get {return __divHeight;}
        set {__divHeight = value;}
    }

    private System.String __waitingDivAmount_Text = System.String.Empty;
    public System.String _waitingDivAmount_Text
    {
        get {return __waitingDivAmount_Text;}
        set {__waitingDivAmount_Text = value;}
    }

    private System.String __realDivAmount_Text = System.String.Empty;
    public System.String _realDivAmount_Text
    {
        get {return __realDivAmount_Text;}
        set {__realDivAmount_Text = value;}
    }

    private System.String __currentSupply_Text = System.String.Empty;
    public System.String _currentSupply_Text
    {
        get {return __currentSupply_Text;}
        set {__currentSupply_Text = value;}
    }

    private System.String __divHeight_Text = System.String.Empty;
    public System.String _divHeight_Text
    {
        get {return __divHeight_Text;}
        set {__divHeight_Text = value;}
    }

    #endregion

    #region Public construct

    public BasicBusShareToken_DividendsDistributed()
    {
    }

    
    public BasicBusShareToken_DividendsDistributed(System.Int32 AChainId,System.String AContractAddress,System.Int64 A_dividendIndex)
    {
        _ChainId = AChainId;
        _ContractAddress = AContractAddress;
        __dividendIndex = A_dividendIndex;
    }

    #endregion

    #region Public DataRow2Object

    public static BasicBusShareToken_DividendsDistributed DataRow2Object(System.Data.DataRow dr)
    {
        if (dr == null)
        {
            return null;
        }
        BasicBusShareToken_DividendsDistributed Obj = new BasicBusShareToken_DividendsDistributed();
        Obj.ChainId = dr["ChainId"] == DBNull.Value ? 0 : (System.Int32)(dr["ChainId"]);
        Obj.ContractAddress = dr["ContractAddress"] == DBNull.Value ? string.Empty : (System.String)(dr["ContractAddress"]);
        Obj.BlockNumber = dr["BlockNumber"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["BlockNumber"]);
        Obj.TransactionHash = dr["TransactionHash"] == DBNull.Value ? string.Empty : (System.String)(dr["TransactionHash"]);
        Obj.CreateTime = dr["CreateTime"] == DBNull.Value ? System.DateTime.Now : (System.DateTime)(dr["CreateTime"]);
        Obj.DivToken = dr["DivToken"] == DBNull.Value ? string.Empty : (System.String)(dr["DivToken"]);
        Obj._dividendIndex = dr["_dividendIndex"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["_dividendIndex"]);
        Obj._caller = dr["_caller"] == DBNull.Value ? string.Empty : (System.String)(dr["_caller"]);
        Obj._waitingDivAmount = dr["_waitingDivAmount"] == DBNull.Value ? 0 : (System.Double)(dr["_waitingDivAmount"]);
        Obj._realDivAmount = dr["_realDivAmount"] == DBNull.Value ? 0 : (System.Double)(dr["_realDivAmount"]);
        Obj._currentSupply = dr["_currentSupply"] == DBNull.Value ? 0 : (System.Double)(dr["_currentSupply"]);
        Obj._divHeight = dr["_divHeight"] == DBNull.Value ? 0 : (System.Double)(dr["_divHeight"]);
        Obj._waitingDivAmount_Text = dr["_waitingDivAmount_Text"] == DBNull.Value ? string.Empty : (System.String)(dr["_waitingDivAmount_Text"]);
        Obj._realDivAmount_Text = dr["_realDivAmount_Text"] == DBNull.Value ? string.Empty : (System.String)(dr["_realDivAmount_Text"]);
        Obj._currentSupply_Text = dr["_currentSupply_Text"] == DBNull.Value ? string.Empty : (System.String)(dr["_currentSupply_Text"]);
        Obj._divHeight_Text = dr["_divHeight_Text"] == DBNull.Value ? string.Empty : (System.String)(dr["_divHeight_Text"]);
        return Obj;
    }

    #endregion


        public void ValidateDataLen()
        {
if (this.ContractAddress != null && this.ContractAddress.Length > FL_ContractAddress && FL_ContractAddress > 0) throw new Exception("ContractAddress要求长度小于等于" + FL_ContractAddress.ToString() + "。");
if (this.TransactionHash != null && this.TransactionHash.Length > FL_TransactionHash && FL_TransactionHash > 0) throw new Exception("TransactionHash要求长度小于等于" + FL_TransactionHash.ToString() + "。");
if (this.DivToken != null && this.DivToken.Length > FL_DivToken && FL_DivToken > 0) throw new Exception("DivToken要求长度小于等于" + FL_DivToken.ToString() + "。");
if (this._caller != null && this._caller.Length > FL__caller && FL__caller > 0) throw new Exception("_caller要求长度小于等于" + FL__caller.ToString() + "。");
if (this._waitingDivAmount_Text != null && this._waitingDivAmount_Text.Length > FL__waitingDivAmount_Text && FL__waitingDivAmount_Text > 0) throw new Exception("_waitingDivAmount_Text要求长度小于等于" + FL__waitingDivAmount_Text.ToString() + "。");
if (this._realDivAmount_Text != null && this._realDivAmount_Text.Length > FL__realDivAmount_Text && FL__realDivAmount_Text > 0) throw new Exception("_realDivAmount_Text要求长度小于等于" + FL__realDivAmount_Text.ToString() + "。");
if (this._currentSupply_Text != null && this._currentSupply_Text.Length > FL__currentSupply_Text && FL__currentSupply_Text > 0) throw new Exception("_currentSupply_Text要求长度小于等于" + FL__currentSupply_Text.ToString() + "。");
if (this._divHeight_Text != null && this._divHeight_Text.Length > FL__divHeight_Text && FL__divHeight_Text > 0) throw new Exception("_divHeight_Text要求长度小于等于" + FL__divHeight_Text.ToString() + "。");
}


        public void ValidateNotEmpty()
        {
if (string.IsNullOrEmpty(this.ContractAddress) || string.IsNullOrEmpty(this.ContractAddress.Trim())) throw new Exception("ContractAddress要求不空。");
if (string.IsNullOrEmpty(this.TransactionHash) || string.IsNullOrEmpty(this.TransactionHash.Trim())) throw new Exception("TransactionHash要求不空。");
if (string.IsNullOrEmpty(this.DivToken) || string.IsNullOrEmpty(this.DivToken.Trim())) throw new Exception("DivToken要求不空。");
if (string.IsNullOrEmpty(this._caller) || string.IsNullOrEmpty(this._caller.Trim())) throw new Exception("_caller要求不空。");
if (string.IsNullOrEmpty(this._waitingDivAmount_Text) || string.IsNullOrEmpty(this._waitingDivAmount_Text.Trim())) throw new Exception("_waitingDivAmount_Text要求不空。");
if (string.IsNullOrEmpty(this._realDivAmount_Text) || string.IsNullOrEmpty(this._realDivAmount_Text.Trim())) throw new Exception("_realDivAmount_Text要求不空。");
if (string.IsNullOrEmpty(this._currentSupply_Text) || string.IsNullOrEmpty(this._currentSupply_Text.Trim())) throw new Exception("_currentSupply_Text要求不空。");
if (string.IsNullOrEmpty(this._divHeight_Text) || string.IsNullOrEmpty(this._divHeight_Text.Trim())) throw new Exception("_divHeight_Text要求不空。");
}



        public void ValidateEmptyAndLen()
        {
            this.ValidateDataLen();
            this.ValidateNotEmpty();
        }


public BasicBusShareToken_DividendsDistributed Copy()
{
    BasicBusShareToken_DividendsDistributed obj = new BasicBusShareToken_DividendsDistributed();
    obj.ChainId = this.ChainId;
    obj.ContractAddress = this.ContractAddress;
    obj.BlockNumber = this.BlockNumber;
    obj.TransactionHash = this.TransactionHash;
    obj.CreateTime = this.CreateTime;
    obj.DivToken = this.DivToken;
    obj._dividendIndex = this._dividendIndex;
    obj._caller = this._caller;
    obj._waitingDivAmount = this._waitingDivAmount;
    obj._realDivAmount = this._realDivAmount;
    obj._currentSupply = this._currentSupply;
    obj._divHeight = this._divHeight;
    obj._waitingDivAmount_Text = this._waitingDivAmount_Text;
    obj._realDivAmount_Text = this._realDivAmount_Text;
    obj._currentSupply_Text = this._currentSupply_Text;
    obj._divHeight_Text = this._divHeight_Text;
    return obj;
}



        public static List<BasicBusShareToken_DividendsDistributed> DataTable2List(System.Data.DataTable dt)
        {
            List<BasicBusShareToken_DividendsDistributed> result = new List<BasicBusShareToken_DividendsDistributed>();
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                result.Add(BasicBusShareToken_DividendsDistributed.DataRow2Object(dr));
            }
            return result;
        }



        private static BasicBusShareToken_DividendsDistributed _NullObject = null;

        public static  BasicBusShareToken_DividendsDistributed NullObject
        {
            get
            {
                if (_NullObject == null)
                {
                    _NullObject = new BasicBusShareToken_DividendsDistributed();
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
        /// 字段 DivToken 的长度——43
        /// </summary>
        public const int FL_DivToken = 43;


        /// <summary>
        /// 字段 _dividendIndex 的长度——8
        /// </summary>
        public const int FL__dividendIndex = 8;


        /// <summary>
        /// 字段 _caller 的长度——43
        /// </summary>
        public const int FL__caller = 43;


        /// <summary>
        /// 字段 _waitingDivAmount 的长度——8
        /// </summary>
        public const int FL__waitingDivAmount = 8;


        /// <summary>
        /// 字段 _realDivAmount 的长度——8
        /// </summary>
        public const int FL__realDivAmount = 8;


        /// <summary>
        /// 字段 _currentSupply 的长度——8
        /// </summary>
        public const int FL__currentSupply = 8;


        /// <summary>
        /// 字段 _divHeight 的长度——8
        /// </summary>
        public const int FL__divHeight = 8;


        /// <summary>
        /// 字段 _waitingDivAmount_Text 的长度——80
        /// </summary>
        public const int FL__waitingDivAmount_Text = 80;


        /// <summary>
        /// 字段 _realDivAmount_Text 的长度——80
        /// </summary>
        public const int FL__realDivAmount_Text = 80;


        /// <summary>
        /// 字段 _currentSupply_Text 的长度——80
        /// </summary>
        public const int FL__currentSupply_Text = 80;


        /// <summary>
        /// 字段 _divHeight_Text 的长度——80
        /// </summary>
        public const int FL__divHeight_Text = 80;


        #endregion
}



}