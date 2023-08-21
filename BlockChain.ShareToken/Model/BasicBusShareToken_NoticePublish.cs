
//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/4/6 17:12:12
//
using System;
using System.Data;
using System.Collections.Generic;

namespace BlockChain.ShareToken.Model
{
[Serializable]
public class BasicBusShareToken_NoticePublish
{
    #region 生成该数据实体的SQL语句
    public const string SQL = @"Select Top(1) * From BasicBusShareToken_NoticePublish";
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

    private System.Int64 __noticeId;
    public System.Int64 _noticeId
    {
        get {return __noticeId;}
        set {__noticeId = value;}
    }

    private System.String __notice = System.String.Empty;
    public System.String _notice
    {
        get {return __notice;}
        set {__notice = value;}
    }

    #endregion

    #region Public construct

    public BasicBusShareToken_NoticePublish()
    {
    }

    
    public BasicBusShareToken_NoticePublish(System.Int32 AChainId,System.String AContractAddress,System.Int64 A_noticeId)
    {
        _ChainId = AChainId;
        _ContractAddress = AContractAddress;
        __noticeId = A_noticeId;
    }

    #endregion

    #region Public DataRow2Object

    public static BasicBusShareToken_NoticePublish DataRow2Object(System.Data.DataRow dr)
    {
        if (dr == null)
        {
            return null;
        }
        BasicBusShareToken_NoticePublish Obj = new BasicBusShareToken_NoticePublish();
        Obj.ChainId = dr["ChainId"] == DBNull.Value ? 0 : (System.Int32)(dr["ChainId"]);
        Obj.ContractAddress = dr["ContractAddress"] == DBNull.Value ? string.Empty : (System.String)(dr["ContractAddress"]);
        Obj.BlockNumber = dr["BlockNumber"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["BlockNumber"]);
        Obj.TransactionHash = dr["TransactionHash"] == DBNull.Value ? string.Empty : (System.String)(dr["TransactionHash"]);
        Obj.CreateTime = dr["CreateTime"] == DBNull.Value ? System.DateTime.Now : (System.DateTime)(dr["CreateTime"]);
        Obj._sender = dr["_sender"] == DBNull.Value ? string.Empty : (System.String)(dr["_sender"]);
        Obj._noticeId = dr["_noticeId"] == DBNull.Value ? Convert.ToInt64(0) : (System.Int64)(dr["_noticeId"]);
        Obj._notice = dr["_notice"] == DBNull.Value ? string.Empty : (System.String)(dr["_notice"]);
        return Obj;
    }

    #endregion


        public void ValidateDataLen()
        {
if (this.ContractAddress != null && this.ContractAddress.Length > FL_ContractAddress && FL_ContractAddress > 0) throw new Exception("ContractAddress要求长度小于等于" + FL_ContractAddress.ToString() + "。");
if (this.TransactionHash != null && this.TransactionHash.Length > FL_TransactionHash && FL_TransactionHash > 0) throw new Exception("TransactionHash要求长度小于等于" + FL_TransactionHash.ToString() + "。");
if (this._sender != null && this._sender.Length > FL__sender && FL__sender > 0) throw new Exception("_sender要求长度小于等于" + FL__sender.ToString() + "。");
if (this._notice != null && this._notice.Length > FL__notice && FL__notice > 0) throw new Exception("_notice要求长度小于等于" + FL__notice.ToString() + "。");
}


        public void ValidateNotEmpty()
        {
if (string.IsNullOrEmpty(this.ContractAddress) || string.IsNullOrEmpty(this.ContractAddress.Trim())) throw new Exception("ContractAddress要求不空。");
if (string.IsNullOrEmpty(this.TransactionHash) || string.IsNullOrEmpty(this.TransactionHash.Trim())) throw new Exception("TransactionHash要求不空。");
if (string.IsNullOrEmpty(this._sender) || string.IsNullOrEmpty(this._sender.Trim())) throw new Exception("_sender要求不空。");
if (string.IsNullOrEmpty(this._notice) || string.IsNullOrEmpty(this._notice.Trim())) throw new Exception("_notice要求不空。");
}



        public void ValidateEmptyAndLen()
        {
            this.ValidateDataLen();
            this.ValidateNotEmpty();
        }


public BasicBusShareToken_NoticePublish Copy()
{
    BasicBusShareToken_NoticePublish obj = new BasicBusShareToken_NoticePublish();
    obj.ChainId = this.ChainId;
    obj.ContractAddress = this.ContractAddress;
    obj.BlockNumber = this.BlockNumber;
    obj.TransactionHash = this.TransactionHash;
    obj.CreateTime = this.CreateTime;
    obj._sender = this._sender;
    obj._noticeId = this._noticeId;
    obj._notice = this._notice;
    return obj;
}



        public static List<BasicBusShareToken_NoticePublish> DataTable2List(System.Data.DataTable dt)
        {
            List<BasicBusShareToken_NoticePublish> result = new List<BasicBusShareToken_NoticePublish>();
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                result.Add(BasicBusShareToken_NoticePublish.DataRow2Object(dr));
            }
            return result;
        }



        private static BasicBusShareToken_NoticePublish _NullObject = null;

        public static  BasicBusShareToken_NoticePublish NullObject
        {
            get
            {
                if (_NullObject == null)
                {
                    _NullObject = new BasicBusShareToken_NoticePublish();
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
        /// 字段 _noticeId 的长度——8
        /// </summary>
        public const int FL__noticeId = 8;


        /// <summary>
        /// 字段 _notice 的长度——0
        /// </summary>
        public const int FL__notice = 0;


        #endregion
}



}