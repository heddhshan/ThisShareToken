//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/4/6 17:11:23
//
using System;
using System.Data;
using System.Data.SqlClient;


namespace BlockChain.ShareToken.DAL
{
internal class BasicBusShareToken_IconImage
{
#region 对应的数据库表 BasicBusShareToken_IconImage
public const string TableName = @"BasicBusShareToken_IconImage";
#endregion

#region  表 BasicBusShareToken_IconImage 的Insert操作
public static void Insert(string conStr, Model.BasicBusShareToken_IconImage model)
{
    string sql = @"insert into BasicBusShareToken_IconImage (ChainId,ContractAddress,BlockNumber,TransactionHash,CreateTime,_sender,_fileName,_data,LocalFileName) values (@ChainId,@ContractAddress,@BlockNumber,@TransactionHash,@CreateTime,@_sender,@_fileName,@_data,@LocalFileName)";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = model.ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = model.ContractAddress;
    cm.Parameters.Add("@BlockNumber", SqlDbType.BigInt, 8).Value = model.BlockNumber;
    cm.Parameters.Add("@TransactionHash", SqlDbType.NVarChar, 66).Value = model.TransactionHash;
    cm.Parameters.Add("@CreateTime", SqlDbType.DateTime, 8).Value = model.CreateTime;
    cm.Parameters.Add("@_sender", SqlDbType.NVarChar, 43).Value = model._sender;
    cm.Parameters.Add("@_fileName", SqlDbType.NVarChar, 128).Value = model._fileName;
    cm.Parameters.Add("@_data", SqlDbType.VarBinary).Value = model._data;
    cm.Parameters.Add("@LocalFileName", SqlDbType.NVarChar, 2048).Value = model.LocalFileName;

    cn.Open();
    try
    {
        cm.ExecuteNonQuery();
    }
    finally
    {
        cn.Close();
    }
}
#endregion

#region  表 BasicBusShareToken_IconImage 的Delete操作
public static int Delete(string conStr, System.Int32 ChainId,System.String ContractAddress,System.String TransactionHash)
{
    string sql = @"Delete From BasicBusShareToken_IconImage Where ChainId = @ChainId and ContractAddress = @ContractAddress and TransactionHash = @TransactionHash";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;
    cm.Parameters.Add("@TransactionHash", SqlDbType.NVarChar, 66).Value = TransactionHash;
    int RecordAffected = -1;
    cn.Open();
    try
    {
        RecordAffected = cm.ExecuteNonQuery();
    }
    finally
    {
        cn.Close();
    }
    return RecordAffected;
}
#endregion

#region  表 BasicBusShareToken_IconImage 的 Update 操作
public static int Update(string conStr, Model.BasicBusShareToken_IconImage model)
{
    string sql = @"Update BasicBusShareToken_IconImage Set BlockNumber = @BlockNumber, CreateTime = @CreateTime, _sender = @_sender, _fileName = @_fileName, _data = @_data, LocalFileName = @LocalFileName Where ChainId = @ChainId And ContractAddress = @ContractAddress And TransactionHash = @TransactionHash ";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = model.ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = model.ContractAddress;
    cm.Parameters.Add("@BlockNumber", SqlDbType.BigInt, 8).Value = model.BlockNumber;
    cm.Parameters.Add("@TransactionHash", SqlDbType.NVarChar, 66).Value = model.TransactionHash;
    cm.Parameters.Add("@CreateTime", SqlDbType.DateTime, 8).Value = model.CreateTime;
    cm.Parameters.Add("@_sender", SqlDbType.NVarChar, 43).Value = model._sender;
    cm.Parameters.Add("@_fileName", SqlDbType.NVarChar, 128).Value = model._fileName;
    cm.Parameters.Add("@_data", SqlDbType.VarBinary).Value = model._data;
    cm.Parameters.Add("@LocalFileName", SqlDbType.NVarChar, 2048).Value = model.LocalFileName;

    int RecordAffected = -1;
    cn.Open();
    try
    {
    RecordAffected = cm.ExecuteNonQuery();
    }
    finally
    {
        cn.Close();
    }
    return RecordAffected;
}
#endregion

#region  表 BasicBusShareToken_IconImage 的GetModel操作
public static Model.BasicBusShareToken_IconImage GetModel(string conStr, System.Int32 ChainId, System.String ContractAddress, System.String TransactionHash)
{
    string sql = @"select * from BasicBusShareToken_IconImage Where ChainId = @ChainId and ContractAddress = @ContractAddress and TransactionHash = @TransactionHash ";

    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;
    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;
    cm.Parameters.Add("@TransactionHash", SqlDbType.NVarChar, 66).Value = TransactionHash;

    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = cm;
    System.Data.DataSet ds = new System.Data.DataSet();
    da.Fill(ds);
    if (ds.Tables[0].Rows.Count == 1)
    {
        return Model.BasicBusShareToken_IconImage.DataRow2Object(ds.Tables[0].Rows[0]);
    }
    else if (ds.Tables[0].Rows.Count > 1)
    {
        throw new Exception("数据错误，对应多条记录！");
    }
    else
    {
        return null;
    }
}


#endregion

#region  表 BasicBusShareToken_IconImage 的 Exist 操作 判断
public static bool Exist(string conStr, System.Int32 ChainId, System.String ContractAddress, System.String TransactionHash)
{
    string sql = @"Select Count(*) From BasicBusShareToken_IconImage Where ChainId = @ChainId and ContractAddress = @ContractAddress and TransactionHash = @TransactionHash ";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;
    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;
    cm.Parameters.Add("@TransactionHash", SqlDbType.NVarChar, 66).Value = TransactionHash;

            cn.Open();
            try
            {
                return Convert.ToInt32(cm.ExecuteScalar()) > 0;
            }
            finally
            {
                cn.Close();
            }   
}

#endregion

}


}