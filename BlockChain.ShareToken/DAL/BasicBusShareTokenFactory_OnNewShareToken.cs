//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/3/6 16:19:55
//
using System;
using System.Data;
using System.Data.SqlClient;


namespace BlockChain.ShareToken.DAL
{
internal class BasicBusShareTokenFactory_OnNewShareToken
{
#region 对应的数据库表 BasicBusShareTokenFactory_OnNewShareToken
public const string TableName = @"BasicBusShareTokenFactory_OnNewShareToken";
#endregion

#region  表 BasicBusShareTokenFactory_OnNewShareToken 的Insert操作
public static void Insert(string conStr, Model.BasicBusShareTokenFactory_OnNewShareToken model)
{
    string sql = @"insert into BasicBusShareTokenFactory_OnNewShareToken (ContractAddress,BlockNumber,TransactionHash,CreateTime,_sender,_shareTokenAddrss,ShareTokenName,ShareTokenCurrentTotalSupply,ShareTokenDecimals,ShareTokenSymbol,ShareTokenIconLocalFileName,DivTokenAddress,DivTokenSymbol,DivTokenCurrentAmount,UpdateBlockNumber,DivTokenImagePath) values (@ContractAddress,@BlockNumber,@TransactionHash,@CreateTime,@_sender,@_shareTokenAddrss,@ShareTokenName,@ShareTokenCurrentTotalSupply,@ShareTokenDecimals,@ShareTokenSymbol,@ShareTokenIconLocalFileName,@DivTokenAddress,@DivTokenSymbol,@DivTokenCurrentAmount,@UpdateBlockNumber,@DivTokenImagePath)";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = model.ContractAddress;
    cm.Parameters.Add("@BlockNumber", SqlDbType.BigInt, 8).Value = model.BlockNumber;
    cm.Parameters.Add("@TransactionHash", SqlDbType.NVarChar, 66).Value = model.TransactionHash;
    cm.Parameters.Add("@CreateTime", SqlDbType.DateTime, 8).Value = model.CreateTime;
    cm.Parameters.Add("@_sender", SqlDbType.NVarChar, 43).Value = model._sender;
    cm.Parameters.Add("@_shareTokenAddrss", SqlDbType.NVarChar, 43).Value = model._shareTokenAddrss;
    cm.Parameters.Add("@ShareTokenName", SqlDbType.NVarChar, 128).Value = model.ShareTokenName;
    cm.Parameters.Add("@ShareTokenCurrentTotalSupply", SqlDbType.Float, 8).Value = model.ShareTokenCurrentTotalSupply;
    cm.Parameters.Add("@ShareTokenDecimals", SqlDbType.Int, 4).Value = model.ShareTokenDecimals;
    cm.Parameters.Add("@ShareTokenSymbol", SqlDbType.NVarChar, 64).Value = model.ShareTokenSymbol;
    cm.Parameters.Add("@ShareTokenIconLocalFileName", SqlDbType.NVarChar, 2048).Value = model.ShareTokenIconLocalFileName;
    cm.Parameters.Add("@DivTokenAddress", SqlDbType.NVarChar, 43).Value = model.DivTokenAddress;
    cm.Parameters.Add("@DivTokenSymbol", SqlDbType.NVarChar, 64).Value = model.DivTokenSymbol;
    cm.Parameters.Add("@DivTokenCurrentAmount", SqlDbType.Float, 8).Value = model.DivTokenCurrentAmount;
    cm.Parameters.Add("@UpdateBlockNumber", SqlDbType.BigInt, 8).Value = model.UpdateBlockNumber;
    cm.Parameters.Add("@DivTokenImagePath", SqlDbType.NVarChar, 2048).Value = model.DivTokenImagePath;

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

#region  表 BasicBusShareTokenFactory_OnNewShareToken 的Delete操作
public static int Delete(string conStr, System.String ContractAddress,System.String TransactionHash)
{
    string sql = @"Delete From BasicBusShareTokenFactory_OnNewShareToken Where ContractAddress = @ContractAddress and TransactionHash = @TransactionHash";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

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

#region  表 BasicBusShareTokenFactory_OnNewShareToken 的 Update 操作
public static int Update(string conStr, Model.BasicBusShareTokenFactory_OnNewShareToken model)
{
    string sql = @"Update BasicBusShareTokenFactory_OnNewShareToken Set BlockNumber = @BlockNumber, CreateTime = @CreateTime, _sender = @_sender, _shareTokenAddrss = @_shareTokenAddrss, ShareTokenName = @ShareTokenName, ShareTokenCurrentTotalSupply = @ShareTokenCurrentTotalSupply, ShareTokenDecimals = @ShareTokenDecimals, ShareTokenSymbol = @ShareTokenSymbol, ShareTokenIconLocalFileName = @ShareTokenIconLocalFileName, DivTokenAddress = @DivTokenAddress, DivTokenSymbol = @DivTokenSymbol, DivTokenCurrentAmount = @DivTokenCurrentAmount, UpdateBlockNumber = @UpdateBlockNumber, DivTokenImagePath = @DivTokenImagePath Where ContractAddress = @ContractAddress And TransactionHash = @TransactionHash ";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = model.ContractAddress;
    cm.Parameters.Add("@BlockNumber", SqlDbType.BigInt, 8).Value = model.BlockNumber;
    cm.Parameters.Add("@TransactionHash", SqlDbType.NVarChar, 66).Value = model.TransactionHash;
    cm.Parameters.Add("@CreateTime", SqlDbType.DateTime, 8).Value = model.CreateTime;
    cm.Parameters.Add("@_sender", SqlDbType.NVarChar, 43).Value = model._sender;
    cm.Parameters.Add("@_shareTokenAddrss", SqlDbType.NVarChar, 43).Value = model._shareTokenAddrss;
    cm.Parameters.Add("@ShareTokenName", SqlDbType.NVarChar, 128).Value = model.ShareTokenName;
    cm.Parameters.Add("@ShareTokenCurrentTotalSupply", SqlDbType.Float, 8).Value = model.ShareTokenCurrentTotalSupply;
    cm.Parameters.Add("@ShareTokenDecimals", SqlDbType.Int, 4).Value = model.ShareTokenDecimals;
    cm.Parameters.Add("@ShareTokenSymbol", SqlDbType.NVarChar, 64).Value = model.ShareTokenSymbol;
    cm.Parameters.Add("@ShareTokenIconLocalFileName", SqlDbType.NVarChar, 2048).Value = model.ShareTokenIconLocalFileName;
    cm.Parameters.Add("@DivTokenAddress", SqlDbType.NVarChar, 43).Value = model.DivTokenAddress;
    cm.Parameters.Add("@DivTokenSymbol", SqlDbType.NVarChar, 64).Value = model.DivTokenSymbol;
    cm.Parameters.Add("@DivTokenCurrentAmount", SqlDbType.Float, 8).Value = model.DivTokenCurrentAmount;
    cm.Parameters.Add("@UpdateBlockNumber", SqlDbType.BigInt, 8).Value = model.UpdateBlockNumber;
    cm.Parameters.Add("@DivTokenImagePath", SqlDbType.NVarChar, 2048).Value = model.DivTokenImagePath;

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

#region  表 BasicBusShareTokenFactory_OnNewShareToken 的GetModel操作
public static Model.BasicBusShareTokenFactory_OnNewShareToken GetModel(string conStr, System.String ContractAddress, System.String TransactionHash)
{
    string sql = @"select * from BasicBusShareTokenFactory_OnNewShareToken Where ContractAddress = @ContractAddress and TransactionHash = @TransactionHash ";

    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;
    cm.Parameters.Add("@TransactionHash", SqlDbType.NVarChar, 66).Value = TransactionHash;

    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = cm;
    System.Data.DataSet ds = new System.Data.DataSet();
    da.Fill(ds);
    if (ds.Tables[0].Rows.Count == 1)
    {
        return Model.BasicBusShareTokenFactory_OnNewShareToken.DataRow2Object(ds.Tables[0].Rows[0]);
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

#region  表 BasicBusShareTokenFactory_OnNewShareToken 的 Exist 操作 判断
public static bool Exist(string conStr, System.String ContractAddress, System.String TransactionHash)
{
    string sql = @"Select Count(*) From BasicBusShareTokenFactory_OnNewShareToken Where ContractAddress = @ContractAddress and TransactionHash = @TransactionHash ";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;
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