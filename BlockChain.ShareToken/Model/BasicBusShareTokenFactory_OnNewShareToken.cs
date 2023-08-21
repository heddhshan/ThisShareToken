
//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/3/6 16:19:54
//
using System;
using System.Data;
using System.Collections.Generic;

namespace BlockChain.ShareToken.Model
{
[Serializable]
public class BasicBusShareTokenFactory_OnNewShareToken
{
    #region 生成该数据实体的SQL语句
    public const string SQL = @"Select Top(1) * From BasicBusShareTokenFactory_OnNewShareToken";
    #endregion

    #region Public Properties

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

    private System.String __sender = System.String.Empty;
    public System.String _sender
    {
        get {return __sender;}
        set {__sender = value;}
    }

    private System.String __shareTokenAddrss = System.String.Empty;
    public System.String _shareTokenAddrss
    {
        get {return __shareTokenAddrss;}
        set {__shareTokenAddrss = value;}
    }

    private System.String _ShareTokenName = System.String.Empty;
    public System.String ShareTokenName
    {
        get {return _ShareTokenName;}
        set {_ShareTokenName = value;}
    }

    private System.Double _ShareTokenCurrentTotalSupply;
    public System.Double ShareTokenCurrentTotalSupply
    {
        get {return _ShareTokenCurrentTotalSupply;}
        set {_ShareTokenCurrentTotalSupply = value;}
    }

    private System.Int32 _ShareTokenDecimals;
    public System.Int32 ShareTokenDecimals
    {
        get {return _ShareTokenDecimals;}
        set {_ShareTokenDecimals = value;}
    }

    private System.String _ShareTokenSymbol = System.String.Empty;
    public System.String ShareTokenSymbol
    {
        get {return _ShareTokenSymbol;}
        set {_ShareTokenSymbol = value;}
    }

    private System.String _ShareTokenIconLocalFileName = System.String.Empty;
    public System.String ShareTokenIconLocalFileName
    {
        get {return _ShareTokenIconLocalFileName;}
        set {_ShareTokenIconLocalFileName = value;}
    }

    private System.String _DivTokenAddress = System.String.Empty;
    public System.String DivTokenAddress
    {
        get {return _DivTokenAddress;}
        set {_DivTokenAddress = value;}
    }

    private System.String _DivTokenSymbol = System.String.Empty;
    public System.String DivTokenSymbol
    {
        get {return _DivTokenSymbol;}
        set {_DivTokenSymbol = value;}
    }

    private System.Double _DivTokenCurrentAmount;
    public System.Double DivTokenCurrentAmount
    {
        get {return _DivTokenCurrentAmount;}
        set {_DivTokenCurrentAmount = value;}
    }

    private System.Int64 _UpdateBlockNumber;
    public System.Int64 UpdateBlockNumber
    {
        get {return _UpdateBlockNumber;}
        set {_UpdateBlockNumber = value;}
    }

    private System.String _DivTokenImagePath = System.String.Empty;
    public System.String DivTokenImagePath
    {
        get {return _DivTokenImagePath;}
        set {_DivTokenImagePath = value;}
    }

    #endregion

    #region Public construct

    public BasicBusShareTokenFactory_OnNewShareToken()
    {
    }

    
    public BasicBusShareTokenFactory_OnNewShareToken(System.String AContractAddress,System.String ATransactionHash)
    {
        _ContractAddress = AContractAddress;
        _TransactionHash = ATransactionHash;
    }

    #endregion

    #region Public DataRow2Object

    public static BasicBusShareTokenFactory_OnNewShareToken DataRow2Object(System.Data.DataRow dr)
    {
        if (dr == null)
        {
            return null;
        }
        BasicBusShareTokenFactory_OnNewShareToken Obj = new BasicBusShareTokenFactory_OnNewShareToken();
        Obj.ContractAddress = dr["ContractAddress"] == DBNull.Value ? string.Empty : (System.String)(dr["ContractAddress"]);
        Obj.BlockNumber = dr["BlockNumber"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["BlockNumber"]);
        Obj.TransactionHash = dr["TransactionHash"] == DBNull.Value ? string.Empty : (System.String)(dr["TransactionHash"]);
        Obj.CreateTime = dr["CreateTime"] == DBNull.Value ? System.DateTime.Now : (System.DateTime)(dr["CreateTime"]);
        Obj._sender = dr["_sender"] == DBNull.Value ? string.Empty : (System.String)(dr["_sender"]);
        Obj._shareTokenAddrss = dr["_shareTokenAddrss"] == DBNull.Value ? string.Empty : (System.String)(dr["_shareTokenAddrss"]);
        Obj.ShareTokenName = dr["ShareTokenName"] == DBNull.Value ? string.Empty : (System.String)(dr["ShareTokenName"]);
        Obj.ShareTokenCurrentTotalSupply = dr["ShareTokenCurrentTotalSupply"] == DBNull.Value ? 0 : (System.Double)(dr["ShareTokenCurrentTotalSupply"]);
        Obj.ShareTokenDecimals = dr["ShareTokenDecimals"] == DBNull.Value ? 0 : (System.Int32)(dr["ShareTokenDecimals"]);
        Obj.ShareTokenSymbol = dr["ShareTokenSymbol"] == DBNull.Value ? string.Empty : (System.String)(dr["ShareTokenSymbol"]);
        Obj.ShareTokenIconLocalFileName = dr["ShareTokenIconLocalFileName"] == DBNull.Value ? string.Empty : (System.String)(dr["ShareTokenIconLocalFileName"]);
        Obj.DivTokenAddress = dr["DivTokenAddress"] == DBNull.Value ? string.Empty : (System.String)(dr["DivTokenAddress"]);
        Obj.DivTokenSymbol = dr["DivTokenSymbol"] == DBNull.Value ? string.Empty : (System.String)(dr["DivTokenSymbol"]);
        Obj.DivTokenCurrentAmount = dr["DivTokenCurrentAmount"] == DBNull.Value ? 0 : (System.Double)(dr["DivTokenCurrentAmount"]);
        Obj.UpdateBlockNumber = dr["UpdateBlockNumber"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["UpdateBlockNumber"]);
        Obj.DivTokenImagePath = dr["DivTokenImagePath"] == DBNull.Value ? string.Empty : (System.String)(dr["DivTokenImagePath"]);
        return Obj;
    }

    #endregion


        public void ValidateDataLen()
        {
if (this.ContractAddress != null && this.ContractAddress.Length > FL_ContractAddress && FL_ContractAddress > 0) throw new Exception("ContractAddress要求长度小于等于" + FL_ContractAddress.ToString() + "。");
if (this.TransactionHash != null && this.TransactionHash.Length > FL_TransactionHash && FL_TransactionHash > 0) throw new Exception("TransactionHash要求长度小于等于" + FL_TransactionHash.ToString() + "。");
if (this._sender != null && this._sender.Length > FL__sender && FL__sender > 0) throw new Exception("_sender要求长度小于等于" + FL__sender.ToString() + "。");
if (this._shareTokenAddrss != null && this._shareTokenAddrss.Length > FL__shareTokenAddrss && FL__shareTokenAddrss > 0) throw new Exception("_shareTokenAddrss要求长度小于等于" + FL__shareTokenAddrss.ToString() + "。");
if (this.ShareTokenName != null && this.ShareTokenName.Length > FL_ShareTokenName && FL_ShareTokenName > 0) throw new Exception("ShareTokenName要求长度小于等于" + FL_ShareTokenName.ToString() + "。");
if (this.ShareTokenSymbol != null && this.ShareTokenSymbol.Length > FL_ShareTokenSymbol && FL_ShareTokenSymbol > 0) throw new Exception("ShareTokenSymbol要求长度小于等于" + FL_ShareTokenSymbol.ToString() + "。");
if (this.ShareTokenIconLocalFileName != null && this.ShareTokenIconLocalFileName.Length > FL_ShareTokenIconLocalFileName && FL_ShareTokenIconLocalFileName > 0) throw new Exception("ShareTokenIconLocalFileName要求长度小于等于" + FL_ShareTokenIconLocalFileName.ToString() + "。");
if (this.DivTokenAddress != null && this.DivTokenAddress.Length > FL_DivTokenAddress && FL_DivTokenAddress > 0) throw new Exception("DivTokenAddress要求长度小于等于" + FL_DivTokenAddress.ToString() + "。");
if (this.DivTokenSymbol != null && this.DivTokenSymbol.Length > FL_DivTokenSymbol && FL_DivTokenSymbol > 0) throw new Exception("DivTokenSymbol要求长度小于等于" + FL_DivTokenSymbol.ToString() + "。");
if (this.DivTokenImagePath != null && this.DivTokenImagePath.Length > FL_DivTokenImagePath && FL_DivTokenImagePath > 0) throw new Exception("DivTokenImagePath要求长度小于等于" + FL_DivTokenImagePath.ToString() + "。");
}


        public void ValidateNotEmpty()
        {
if (string.IsNullOrEmpty(this.ContractAddress) || string.IsNullOrEmpty(this.ContractAddress.Trim())) throw new Exception("ContractAddress要求不空。");
if (string.IsNullOrEmpty(this.TransactionHash) || string.IsNullOrEmpty(this.TransactionHash.Trim())) throw new Exception("TransactionHash要求不空。");
if (string.IsNullOrEmpty(this._sender) || string.IsNullOrEmpty(this._sender.Trim())) throw new Exception("_sender要求不空。");
if (string.IsNullOrEmpty(this._shareTokenAddrss) || string.IsNullOrEmpty(this._shareTokenAddrss.Trim())) throw new Exception("_shareTokenAddrss要求不空。");
}



        public void ValidateEmptyAndLen()
        {
            this.ValidateDataLen();
            this.ValidateNotEmpty();
        }


public BasicBusShareTokenFactory_OnNewShareToken Copy()
{
    BasicBusShareTokenFactory_OnNewShareToken obj = new BasicBusShareTokenFactory_OnNewShareToken();
    obj.ContractAddress = this.ContractAddress;
    obj.BlockNumber = this.BlockNumber;
    obj.TransactionHash = this.TransactionHash;
    obj.CreateTime = this.CreateTime;
    obj._sender = this._sender;
    obj._shareTokenAddrss = this._shareTokenAddrss;
    obj.ShareTokenName = this.ShareTokenName;
    obj.ShareTokenCurrentTotalSupply = this.ShareTokenCurrentTotalSupply;
    obj.ShareTokenDecimals = this.ShareTokenDecimals;
    obj.ShareTokenSymbol = this.ShareTokenSymbol;
    obj.ShareTokenIconLocalFileName = this.ShareTokenIconLocalFileName;
    obj.DivTokenAddress = this.DivTokenAddress;
    obj.DivTokenSymbol = this.DivTokenSymbol;
    obj.DivTokenCurrentAmount = this.DivTokenCurrentAmount;
    obj.UpdateBlockNumber = this.UpdateBlockNumber;
    obj.DivTokenImagePath = this.DivTokenImagePath;
    return obj;
}



        public static List<BasicBusShareTokenFactory_OnNewShareToken> DataTable2List(System.Data.DataTable dt)
        {
            List<BasicBusShareTokenFactory_OnNewShareToken> result = new List<BasicBusShareTokenFactory_OnNewShareToken>();
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                result.Add(BasicBusShareTokenFactory_OnNewShareToken.DataRow2Object(dr));
            }
            return result;
        }



        private static BasicBusShareTokenFactory_OnNewShareToken _NullObject = null;

        public static  BasicBusShareTokenFactory_OnNewShareToken NullObject
        {
            get
            {
                if (_NullObject == null)
                {
                    _NullObject = new BasicBusShareTokenFactory_OnNewShareToken();
                }
                return _NullObject;
            }
        }


        #region 字段长度

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
        /// 字段 _sender 的长度——43
        /// </summary>
        public const int FL__sender = 43;


        /// <summary>
        /// 字段 _shareTokenAddrss 的长度——43
        /// </summary>
        public const int FL__shareTokenAddrss = 43;


        /// <summary>
        /// 字段 ShareTokenName 的长度——128
        /// </summary>
        public const int FL_ShareTokenName = 128;


        /// <summary>
        /// 字段 ShareTokenCurrentTotalSupply 的长度——8
        /// </summary>
        public const int FL_ShareTokenCurrentTotalSupply = 8;


        /// <summary>
        /// 字段 ShareTokenDecimals 的长度——4
        /// </summary>
        public const int FL_ShareTokenDecimals = 4;


        /// <summary>
        /// 字段 ShareTokenSymbol 的长度——64
        /// </summary>
        public const int FL_ShareTokenSymbol = 64;


        /// <summary>
        /// 字段 ShareTokenIconLocalFileName 的长度——2048
        /// </summary>
        public const int FL_ShareTokenIconLocalFileName = 2048;


        /// <summary>
        /// 字段 DivTokenAddress 的长度——43
        /// </summary>
        public const int FL_DivTokenAddress = 43;


        /// <summary>
        /// 字段 DivTokenSymbol 的长度——64
        /// </summary>
        public const int FL_DivTokenSymbol = 64;


        /// <summary>
        /// 字段 DivTokenCurrentAmount 的长度——8
        /// </summary>
        public const int FL_DivTokenCurrentAmount = 8;


        /// <summary>
        /// 字段 UpdateBlockNumber 的长度——8
        /// </summary>
        public const int FL_UpdateBlockNumber = 8;


        /// <summary>
        /// 字段 DivTokenImagePath 的长度——2048
        /// </summary>
        public const int FL_DivTokenImagePath = 2048;


        #endregion
}



}