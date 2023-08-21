
//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/4/6 17:12:12
//
using System;
using System.Data;
using System.Collections.Generic;

namespace BlockChain.ShareToken.Model
{
[Serializable]
public class BasicBusShareToken_IconImage
{
    #region 生成该数据实体的SQL语句
    public const string SQL = @"Select Top(1) * From BasicBusShareToken_IconImage";
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

    private System.String __fileName = System.String.Empty;
    public System.String _fileName
    {
        get {return __fileName;}
        set {__fileName = value;}
    }

    private System.Byte[] __data;
    public System.Byte[] _data
    {
        get {return __data;}
        set {__data = value;}
    }

    private System.String _LocalFileName = System.String.Empty;
    public System.String LocalFileName
    {
        get {return _LocalFileName;}
        set {_LocalFileName = value;}
    }

    #endregion

    #region Public construct

    public BasicBusShareToken_IconImage()
    {
    }

    
    public BasicBusShareToken_IconImage(System.Int32 AChainId,System.String AContractAddress,System.String ATransactionHash)
    {
        _ChainId = AChainId;
        _ContractAddress = AContractAddress;
        _TransactionHash = ATransactionHash;
    }

    #endregion

    #region Public DataRow2Object

    public static BasicBusShareToken_IconImage DataRow2Object(System.Data.DataRow dr)
    {
        if (dr == null)
        {
            return null;
        }
        BasicBusShareToken_IconImage Obj = new BasicBusShareToken_IconImage();
        Obj.ChainId = dr["ChainId"] == DBNull.Value ? 0 : (System.Int32)(dr["ChainId"]);
        Obj.ContractAddress = dr["ContractAddress"] == DBNull.Value ? string.Empty : (System.String)(dr["ContractAddress"]);
        Obj.BlockNumber = dr["BlockNumber"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["BlockNumber"]);
        Obj.TransactionHash = dr["TransactionHash"] == DBNull.Value ? string.Empty : (System.String)(dr["TransactionHash"]);
        Obj.CreateTime = dr["CreateTime"] == DBNull.Value ? System.DateTime.Now : (System.DateTime)(dr["CreateTime"]);
        Obj._sender = dr["_sender"] == DBNull.Value ? string.Empty : (System.String)(dr["_sender"]);
        Obj._fileName = dr["_fileName"] == DBNull.Value ? string.Empty : (System.String)(dr["_fileName"]);
        Obj._data = dr["_data"] == DBNull.Value ? null : (System.Byte[])(dr["_data"]);
        Obj.LocalFileName = dr["LocalFileName"] == DBNull.Value ? string.Empty : (System.String)(dr["LocalFileName"]);
        return Obj;
    }

    #endregion


        public void ValidateDataLen()
        {
if (this.ContractAddress != null && this.ContractAddress.Length > FL_ContractAddress && FL_ContractAddress > 0) throw new Exception("ContractAddress要求长度小于等于" + FL_ContractAddress.ToString() + "。");
if (this.TransactionHash != null && this.TransactionHash.Length > FL_TransactionHash && FL_TransactionHash > 0) throw new Exception("TransactionHash要求长度小于等于" + FL_TransactionHash.ToString() + "。");
if (this._sender != null && this._sender.Length > FL__sender && FL__sender > 0) throw new Exception("_sender要求长度小于等于" + FL__sender.ToString() + "。");
if (this._fileName != null && this._fileName.Length > FL__fileName && FL__fileName > 0) throw new Exception("_fileName要求长度小于等于" + FL__fileName.ToString() + "。");
if (this.LocalFileName != null && this.LocalFileName.Length > FL_LocalFileName && FL_LocalFileName > 0) throw new Exception("LocalFileName要求长度小于等于" + FL_LocalFileName.ToString() + "。");
}


        public void ValidateNotEmpty()
        {
if (string.IsNullOrEmpty(this.ContractAddress) || string.IsNullOrEmpty(this.ContractAddress.Trim())) throw new Exception("ContractAddress要求不空。");
if (string.IsNullOrEmpty(this.TransactionHash) || string.IsNullOrEmpty(this.TransactionHash.Trim())) throw new Exception("TransactionHash要求不空。");
if (string.IsNullOrEmpty(this._sender) || string.IsNullOrEmpty(this._sender.Trim())) throw new Exception("_sender要求不空。");
if (string.IsNullOrEmpty(this._fileName) || string.IsNullOrEmpty(this._fileName.Trim())) throw new Exception("_fileName要求不空。");
if (string.IsNullOrEmpty(this.LocalFileName) || string.IsNullOrEmpty(this.LocalFileName.Trim())) throw new Exception("LocalFileName要求不空。");
}



        public void ValidateEmptyAndLen()
        {
            this.ValidateDataLen();
            this.ValidateNotEmpty();
        }


public BasicBusShareToken_IconImage Copy()
{
    BasicBusShareToken_IconImage obj = new BasicBusShareToken_IconImage();
    obj.ChainId = this.ChainId;
    obj.ContractAddress = this.ContractAddress;
    obj.BlockNumber = this.BlockNumber;
    obj.TransactionHash = this.TransactionHash;
    obj.CreateTime = this.CreateTime;
    obj._sender = this._sender;
    obj._fileName = this._fileName;
    obj._data = this._data;
    obj.LocalFileName = this.LocalFileName;
    return obj;
}



        public static List<BasicBusShareToken_IconImage> DataTable2List(System.Data.DataTable dt)
        {
            List<BasicBusShareToken_IconImage> result = new List<BasicBusShareToken_IconImage>();
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                result.Add(BasicBusShareToken_IconImage.DataRow2Object(dr));
            }
            return result;
        }



        private static BasicBusShareToken_IconImage _NullObject = null;

        public static  BasicBusShareToken_IconImage NullObject
        {
            get
            {
                if (_NullObject == null)
                {
                    _NullObject = new BasicBusShareToken_IconImage();
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
        /// 字段 _fileName 的长度——128
        /// </summary>
        public const int FL__fileName = 128;


        /// <summary>
        /// 字段 _data 的长度——-1
        /// </summary>
        public const int FL__data = -1;


        /// <summary>
        /// 字段 LocalFileName 的长度——2048
        /// </summary>
        public const int FL_LocalFileName = 2048;


        #endregion
}



}