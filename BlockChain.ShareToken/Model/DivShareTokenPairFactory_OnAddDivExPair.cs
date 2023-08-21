
//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/5/17 15:58:19
//
using System;
using System.Data;
using System.Collections.Generic;

namespace BlockChain.ShareToken.Model
{
[Serializable]
public class DivShareTokenPairFactory_OnAddDivExPair
{
    #region 生成该数据实体的SQL语句
    public const string SQL = @"Select Top(1) * From DivShareTokenPairFactory_OnAddDivExPair";
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

    private System.String __sender = System.String.Empty;
    public System.String _sender
    {
        get {return __sender;}
        set {__sender = value;}
    }

    private System.String __shareToken = System.String.Empty;
    public System.String _shareToken
    {
        get {return __shareToken;}
        set {__shareToken = value;}
    }

    private System.String __oldPair = System.String.Empty;
    public System.String _oldPair
    {
        get {return __oldPair;}
        set {__oldPair = value;}
    }

    private System.String __newPair = System.String.Empty;
    public System.String _newPair
    {
        get {return __newPair;}
        set {__newPair = value;}
    }

    private System.Int32 __powerM;
    public System.Int32 _powerM
    {
        get {return __powerM;}
        set {__powerM = value;}
    }

    private System.Boolean _IsPaused;
    public System.Boolean IsPaused
    {
        get {return _IsPaused;}
        set {_IsPaused = value;}
    }

    private System.String _ShareTokenName = System.String.Empty;
    public System.String ShareTokenName
    {
        get {return _ShareTokenName;}
        set {_ShareTokenName = value;}
    }

    private System.Double _ShareTokenCurrentLiqAmount;
    public System.Double ShareTokenCurrentLiqAmount
    {
        get {return _ShareTokenCurrentLiqAmount;}
        set {_ShareTokenCurrentLiqAmount = value;}
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

    private System.Double _DivTokenCurrentLiqAmount;
    public System.Double DivTokenCurrentLiqAmount
    {
        get {return _DivTokenCurrentLiqAmount;}
        set {_DivTokenCurrentLiqAmount = value;}
    }

    private System.Int64 _UpdateBlockNumber;
    public System.Int64 UpdateBlockNumber
    {
        get {return _UpdateBlockNumber;}
        set {_UpdateBlockNumber = value;}
    }

    private System.String _Price0 = System.String.Empty;
    public System.String Price0
    {
        get {return _Price0;}
        set {_Price0 = value;}
    }

    private System.String _Price1 = System.String.Empty;
    public System.String Price1
    {
        get {return _Price1;}
        set {_Price1 = value;}
    }

    private System.String _DivTokenImagePath = System.String.Empty;
    public System.String DivTokenImagePath
    {
        get {return _DivTokenImagePath;}
        set {_DivTokenImagePath = value;}
    }

    private System.String _ShareTokenIconLocalFileName = System.String.Empty;
    public System.String ShareTokenIconLocalFileName
    {
        get {return _ShareTokenIconLocalFileName;}
        set {_ShareTokenIconLocalFileName = value;}
    }

    #endregion

    #region Public construct

    public DivShareTokenPairFactory_OnAddDivExPair()
    {
    }

    
    public DivShareTokenPairFactory_OnAddDivExPair(System.Int32 AChainId,System.String AContractAddress,System.String ATransactionHash)
    {
        _ChainId = AChainId;
        _ContractAddress = AContractAddress;
        _TransactionHash = ATransactionHash;
    }

    #endregion

    #region Public DataRow2Object

    public static DivShareTokenPairFactory_OnAddDivExPair DataRow2Object(System.Data.DataRow dr)
    {
        if (dr == null)
        {
            return null;
        }
        DivShareTokenPairFactory_OnAddDivExPair Obj = new DivShareTokenPairFactory_OnAddDivExPair();
        Obj.ChainId = dr["ChainId"] == DBNull.Value ? 0 : (System.Int32)(dr["ChainId"]);
        Obj.ContractAddress = dr["ContractAddress"] == DBNull.Value ? string.Empty : (System.String)(dr["ContractAddress"]);
        Obj.BlockNumber = dr["BlockNumber"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["BlockNumber"]);
        Obj.TransactionHash = dr["TransactionHash"] == DBNull.Value ? string.Empty : (System.String)(dr["TransactionHash"]);
        Obj.CreateTime = dr["CreateTime"] == DBNull.Value ? System.DateTime.Now : (System.DateTime)(dr["CreateTime"]);
        Obj._sender = dr["_sender"] == DBNull.Value ? string.Empty : (System.String)(dr["_sender"]);
        Obj._shareToken = dr["_shareToken"] == DBNull.Value ? string.Empty : (System.String)(dr["_shareToken"]);
        Obj._oldPair = dr["_oldPair"] == DBNull.Value ? string.Empty : (System.String)(dr["_oldPair"]);
        Obj._newPair = dr["_newPair"] == DBNull.Value ? string.Empty : (System.String)(dr["_newPair"]);
        Obj._powerM = dr["_powerM"] == DBNull.Value ? 0 : (System.Int32)(dr["_powerM"]);
        Obj.IsPaused = dr["IsPaused"] == DBNull.Value ? false : (System.Boolean)(dr["IsPaused"]);
        Obj.ShareTokenName = dr["ShareTokenName"] == DBNull.Value ? string.Empty : (System.String)(dr["ShareTokenName"]);
        Obj.ShareTokenCurrentLiqAmount = dr["ShareTokenCurrentLiqAmount"] == DBNull.Value ? 0 : (System.Double)(dr["ShareTokenCurrentLiqAmount"]);
        Obj.ShareTokenDecimals = dr["ShareTokenDecimals"] == DBNull.Value ? 0 : (System.Int32)(dr["ShareTokenDecimals"]);
        Obj.ShareTokenSymbol = dr["ShareTokenSymbol"] == DBNull.Value ? string.Empty : (System.String)(dr["ShareTokenSymbol"]);
        Obj.DivTokenAddress = dr["DivTokenAddress"] == DBNull.Value ? string.Empty : (System.String)(dr["DivTokenAddress"]);
        Obj.DivTokenSymbol = dr["DivTokenSymbol"] == DBNull.Value ? string.Empty : (System.String)(dr["DivTokenSymbol"]);
        Obj.DivTokenCurrentLiqAmount = dr["DivTokenCurrentLiqAmount"] == DBNull.Value ? 0 : (System.Double)(dr["DivTokenCurrentLiqAmount"]);
        Obj.UpdateBlockNumber = dr["UpdateBlockNumber"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["UpdateBlockNumber"]);
        Obj.Price0 = dr["Price0"] == DBNull.Value ? string.Empty : (System.String)(dr["Price0"]);
        Obj.Price1 = dr["Price1"] == DBNull.Value ? string.Empty : (System.String)(dr["Price1"]);
        Obj.DivTokenImagePath = dr["DivTokenImagePath"] == DBNull.Value ? string.Empty : (System.String)(dr["DivTokenImagePath"]);
        Obj.ShareTokenIconLocalFileName = dr["ShareTokenIconLocalFileName"] == DBNull.Value ? string.Empty : (System.String)(dr["ShareTokenIconLocalFileName"]);
        return Obj;
    }

    #endregion


        public void ValidateDataLen()
        {
if (this.ContractAddress != null && this.ContractAddress.Length > FL_ContractAddress && FL_ContractAddress > 0) throw new Exception("ContractAddress要求长度小于等于" + FL_ContractAddress.ToString() + "。");
if (this.TransactionHash != null && this.TransactionHash.Length > FL_TransactionHash && FL_TransactionHash > 0) throw new Exception("TransactionHash要求长度小于等于" + FL_TransactionHash.ToString() + "。");
if (this._sender != null && this._sender.Length > FL__sender && FL__sender > 0) throw new Exception("_sender要求长度小于等于" + FL__sender.ToString() + "。");
if (this._shareToken != null && this._shareToken.Length > FL__shareToken && FL__shareToken > 0) throw new Exception("_shareToken要求长度小于等于" + FL__shareToken.ToString() + "。");
if (this._oldPair != null && this._oldPair.Length > FL__oldPair && FL__oldPair > 0) throw new Exception("_oldPair要求长度小于等于" + FL__oldPair.ToString() + "。");
if (this._newPair != null && this._newPair.Length > FL__newPair && FL__newPair > 0) throw new Exception("_newPair要求长度小于等于" + FL__newPair.ToString() + "。");
if (this.ShareTokenName != null && this.ShareTokenName.Length > FL_ShareTokenName && FL_ShareTokenName > 0) throw new Exception("ShareTokenName要求长度小于等于" + FL_ShareTokenName.ToString() + "。");
if (this.ShareTokenSymbol != null && this.ShareTokenSymbol.Length > FL_ShareTokenSymbol && FL_ShareTokenSymbol > 0) throw new Exception("ShareTokenSymbol要求长度小于等于" + FL_ShareTokenSymbol.ToString() + "。");
if (this.DivTokenAddress != null && this.DivTokenAddress.Length > FL_DivTokenAddress && FL_DivTokenAddress > 0) throw new Exception("DivTokenAddress要求长度小于等于" + FL_DivTokenAddress.ToString() + "。");
if (this.DivTokenSymbol != null && this.DivTokenSymbol.Length > FL_DivTokenSymbol && FL_DivTokenSymbol > 0) throw new Exception("DivTokenSymbol要求长度小于等于" + FL_DivTokenSymbol.ToString() + "。");
if (this.Price0 != null && this.Price0.Length > FL_Price0 && FL_Price0 > 0) throw new Exception("Price0要求长度小于等于" + FL_Price0.ToString() + "。");
if (this.Price1 != null && this.Price1.Length > FL_Price1 && FL_Price1 > 0) throw new Exception("Price1要求长度小于等于" + FL_Price1.ToString() + "。");
if (this.DivTokenImagePath != null && this.DivTokenImagePath.Length > FL_DivTokenImagePath && FL_DivTokenImagePath > 0) throw new Exception("DivTokenImagePath要求长度小于等于" + FL_DivTokenImagePath.ToString() + "。");
if (this.ShareTokenIconLocalFileName != null && this.ShareTokenIconLocalFileName.Length > FL_ShareTokenIconLocalFileName && FL_ShareTokenIconLocalFileName > 0) throw new Exception("ShareTokenIconLocalFileName要求长度小于等于" + FL_ShareTokenIconLocalFileName.ToString() + "。");
}


        public void ValidateNotEmpty()
        {
if (string.IsNullOrEmpty(this.ContractAddress) || string.IsNullOrEmpty(this.ContractAddress.Trim())) throw new Exception("ContractAddress要求不空。");
if (string.IsNullOrEmpty(this.TransactionHash) || string.IsNullOrEmpty(this.TransactionHash.Trim())) throw new Exception("TransactionHash要求不空。");
if (string.IsNullOrEmpty(this._sender) || string.IsNullOrEmpty(this._sender.Trim())) throw new Exception("_sender要求不空。");
if (string.IsNullOrEmpty(this._shareToken) || string.IsNullOrEmpty(this._shareToken.Trim())) throw new Exception("_shareToken要求不空。");
if (string.IsNullOrEmpty(this._oldPair) || string.IsNullOrEmpty(this._oldPair.Trim())) throw new Exception("_oldPair要求不空。");
if (string.IsNullOrEmpty(this._newPair) || string.IsNullOrEmpty(this._newPair.Trim())) throw new Exception("_newPair要求不空。");
}



        public void ValidateEmptyAndLen()
        {
            this.ValidateDataLen();
            this.ValidateNotEmpty();
        }


public DivShareTokenPairFactory_OnAddDivExPair Copy()
{
    DivShareTokenPairFactory_OnAddDivExPair obj = new DivShareTokenPairFactory_OnAddDivExPair();
    obj.ChainId = this.ChainId;
    obj.ContractAddress = this.ContractAddress;
    obj.BlockNumber = this.BlockNumber;
    obj.TransactionHash = this.TransactionHash;
    obj.CreateTime = this.CreateTime;
    obj._sender = this._sender;
    obj._shareToken = this._shareToken;
    obj._oldPair = this._oldPair;
    obj._newPair = this._newPair;
    obj._powerM = this._powerM;
    obj.IsPaused = this.IsPaused;
    obj.ShareTokenName = this.ShareTokenName;
    obj.ShareTokenCurrentLiqAmount = this.ShareTokenCurrentLiqAmount;
    obj.ShareTokenDecimals = this.ShareTokenDecimals;
    obj.ShareTokenSymbol = this.ShareTokenSymbol;
    obj.DivTokenAddress = this.DivTokenAddress;
    obj.DivTokenSymbol = this.DivTokenSymbol;
    obj.DivTokenCurrentLiqAmount = this.DivTokenCurrentLiqAmount;
    obj.UpdateBlockNumber = this.UpdateBlockNumber;
    obj.Price0 = this.Price0;
    obj.Price1 = this.Price1;
    obj.DivTokenImagePath = this.DivTokenImagePath;
    obj.ShareTokenIconLocalFileName = this.ShareTokenIconLocalFileName;
    return obj;
}



        public static List<DivShareTokenPairFactory_OnAddDivExPair> DataTable2List(System.Data.DataTable dt)
        {
            List<DivShareTokenPairFactory_OnAddDivExPair> result = new List<DivShareTokenPairFactory_OnAddDivExPair>();
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                result.Add(DivShareTokenPairFactory_OnAddDivExPair.DataRow2Object(dr));
            }
            return result;
        }



        private static DivShareTokenPairFactory_OnAddDivExPair _NullObject = null;

        public static  DivShareTokenPairFactory_OnAddDivExPair NullObject
        {
            get
            {
                if (_NullObject == null)
                {
                    _NullObject = new DivShareTokenPairFactory_OnAddDivExPair();
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
        /// 字段 _sender 的长度——43
        /// </summary>
        public const int FL__sender = 43;


        /// <summary>
        /// 字段 _shareToken 的长度——43
        /// </summary>
        public const int FL__shareToken = 43;


        /// <summary>
        /// 字段 _oldPair 的长度——43
        /// </summary>
        public const int FL__oldPair = 43;


        /// <summary>
        /// 字段 _newPair 的长度——43
        /// </summary>
        public const int FL__newPair = 43;


        /// <summary>
        /// 字段 _powerM 的长度——4
        /// </summary>
        public const int FL__powerM = 4;


        /// <summary>
        /// 字段 IsPaused 的长度——1
        /// </summary>
        public const int FL_IsPaused = 1;


        /// <summary>
        /// 字段 ShareTokenName 的长度——128
        /// </summary>
        public const int FL_ShareTokenName = 128;


        /// <summary>
        /// 字段 ShareTokenCurrentLiqAmount 的长度——8
        /// </summary>
        public const int FL_ShareTokenCurrentLiqAmount = 8;


        /// <summary>
        /// 字段 ShareTokenDecimals 的长度——4
        /// </summary>
        public const int FL_ShareTokenDecimals = 4;


        /// <summary>
        /// 字段 ShareTokenSymbol 的长度——64
        /// </summary>
        public const int FL_ShareTokenSymbol = 64;


        /// <summary>
        /// 字段 DivTokenAddress 的长度——43
        /// </summary>
        public const int FL_DivTokenAddress = 43;


        /// <summary>
        /// 字段 DivTokenSymbol 的长度——64
        /// </summary>
        public const int FL_DivTokenSymbol = 64;


        /// <summary>
        /// 字段 DivTokenCurrentLiqAmount 的长度——8
        /// </summary>
        public const int FL_DivTokenCurrentLiqAmount = 8;


        /// <summary>
        /// 字段 UpdateBlockNumber 的长度——8
        /// </summary>
        public const int FL_UpdateBlockNumber = 8;


        /// <summary>
        /// 字段 Price0 的长度——36
        /// </summary>
        public const int FL_Price0 = 36;


        /// <summary>
        /// 字段 Price1 的长度——36
        /// </summary>
        public const int FL_Price1 = 36;


        /// <summary>
        /// 字段 DivTokenImagePath 的长度——2048
        /// </summary>
        public const int FL_DivTokenImagePath = 2048;


        /// <summary>
        /// 字段 ShareTokenIconLocalFileName 的长度——2048
        /// </summary>
        public const int FL_ShareTokenIconLocalFileName = 2048;


        #endregion
}



}