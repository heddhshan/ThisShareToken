//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/5/17 15:58:50
//
using System;
using System.Data;
using System.Data.SqlClient;


namespace BlockChain.ShareToken.DAL
{
internal class DivShareTokenPairFactory_OnAddDivExPair
{
#region 对应的数据库表 DivShareTokenPairFactory_OnAddDivExPair
public const string TableName = @"DivShareTokenPairFactory_OnAddDivExPair";
#endregion

#region  表 DivShareTokenPairFactory_OnAddDivExPair 的Insert操作
public static void Insert(string conStr, Model.DivShareTokenPairFactory_OnAddDivExPair model)
{
    string sql = @"insert into DivShareTokenPairFactory_OnAddDivExPair (ChainId,ContractAddress,BlockNumber,TransactionHash,CreateTime,_sender,_shareToken,_oldPair,_newPair,_powerM,IsPaused,ShareTokenName,ShareTokenCurrentLiqAmount,ShareTokenDecimals,ShareTokenSymbol,DivTokenAddress,DivTokenSymbol,DivTokenCurrentLiqAmount,UpdateBlockNumber,Price0,Price1,DivTokenImagePath,ShareTokenIconLocalFileName) values (@ChainId,@ContractAddress,@BlockNumber,@TransactionHash,@CreateTime,@_sender,@_shareToken,@_oldPair,@_newPair,@_powerM,@IsPaused,@ShareTokenName,@ShareTokenCurrentLiqAmount,@ShareTokenDecimals,@ShareTokenSymbol,@DivTokenAddress,@DivTokenSymbol,@DivTokenCurrentLiqAmount,@UpdateBlockNumber,@Price0,@Price1,@DivTokenImagePath,@ShareTokenIconLocalFileName)";
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
    cm.Parameters.Add("@_shareToken", SqlDbType.NVarChar, 43).Value = model._shareToken;
    cm.Parameters.Add("@_oldPair", SqlDbType.NVarChar, 43).Value = model._oldPair;
    cm.Parameters.Add("@_newPair", SqlDbType.NVarChar, 43).Value = model._newPair;
    cm.Parameters.Add("@_powerM", SqlDbType.Int, 4).Value = model._powerM;
    cm.Parameters.Add("@IsPaused", SqlDbType.Bit, 1).Value = model.IsPaused;
    cm.Parameters.Add("@ShareTokenName", SqlDbType.NVarChar, 128).Value = model.ShareTokenName;
    cm.Parameters.Add("@ShareTokenCurrentLiqAmount", SqlDbType.Float, 8).Value = model.ShareTokenCurrentLiqAmount;
    cm.Parameters.Add("@ShareTokenDecimals", SqlDbType.Int, 4).Value = model.ShareTokenDecimals;
    cm.Parameters.Add("@ShareTokenSymbol", SqlDbType.NVarChar, 64).Value = model.ShareTokenSymbol;
    cm.Parameters.Add("@DivTokenAddress", SqlDbType.NVarChar, 43).Value = model.DivTokenAddress;
    cm.Parameters.Add("@DivTokenSymbol", SqlDbType.NVarChar, 64).Value = model.DivTokenSymbol;
    cm.Parameters.Add("@DivTokenCurrentLiqAmount", SqlDbType.Float, 8).Value = model.DivTokenCurrentLiqAmount;
    cm.Parameters.Add("@UpdateBlockNumber", SqlDbType.BigInt, 8).Value = model.UpdateBlockNumber;
    cm.Parameters.Add("@Price0", SqlDbType.NVarChar, 36).Value = model.Price0;
    cm.Parameters.Add("@Price1", SqlDbType.NVarChar, 36).Value = model.Price1;
    cm.Parameters.Add("@DivTokenImagePath", SqlDbType.NVarChar, 2048).Value = model.DivTokenImagePath;
    cm.Parameters.Add("@ShareTokenIconLocalFileName", SqlDbType.NVarChar, 2048).Value = model.ShareTokenIconLocalFileName;

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

#region  表 DivShareTokenPairFactory_OnAddDivExPair 的Delete操作
public static int Delete(string conStr, System.Int32 ChainId,System.String ContractAddress,System.String TransactionHash)
{
    string sql = @"Delete From DivShareTokenPairFactory_OnAddDivExPair Where ChainId = @ChainId and ContractAddress = @ContractAddress and TransactionHash = @TransactionHash";
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

#region  表 DivShareTokenPairFactory_OnAddDivExPair 的 Update 操作
public static int Update(string conStr, Model.DivShareTokenPairFactory_OnAddDivExPair model)
{
    string sql = @"Update DivShareTokenPairFactory_OnAddDivExPair Set BlockNumber = @BlockNumber, CreateTime = @CreateTime, _sender = @_sender, _shareToken = @_shareToken, _oldPair = @_oldPair, _newPair = @_newPair, _powerM = @_powerM, IsPaused = @IsPaused, ShareTokenName = @ShareTokenName, ShareTokenCurrentLiqAmount = @ShareTokenCurrentLiqAmount, ShareTokenDecimals = @ShareTokenDecimals, ShareTokenSymbol = @ShareTokenSymbol, DivTokenAddress = @DivTokenAddress, DivTokenSymbol = @DivTokenSymbol, DivTokenCurrentLiqAmount = @DivTokenCurrentLiqAmount, UpdateBlockNumber = @UpdateBlockNumber, Price0 = @Price0, Price1 = @Price1, DivTokenImagePath = @DivTokenImagePath, ShareTokenIconLocalFileName = @ShareTokenIconLocalFileName Where ChainId = @ChainId And ContractAddress = @ContractAddress And TransactionHash = @TransactionHash ";
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
    cm.Parameters.Add("@_shareToken", SqlDbType.NVarChar, 43).Value = model._shareToken;
    cm.Parameters.Add("@_oldPair", SqlDbType.NVarChar, 43).Value = model._oldPair;
    cm.Parameters.Add("@_newPair", SqlDbType.NVarChar, 43).Value = model._newPair;
    cm.Parameters.Add("@_powerM", SqlDbType.Int, 4).Value = model._powerM;
    cm.Parameters.Add("@IsPaused", SqlDbType.Bit, 1).Value = model.IsPaused;
    cm.Parameters.Add("@ShareTokenName", SqlDbType.NVarChar, 128).Value = model.ShareTokenName;
    cm.Parameters.Add("@ShareTokenCurrentLiqAmount", SqlDbType.Float, 8).Value = model.ShareTokenCurrentLiqAmount;
    cm.Parameters.Add("@ShareTokenDecimals", SqlDbType.Int, 4).Value = model.ShareTokenDecimals;
    cm.Parameters.Add("@ShareTokenSymbol", SqlDbType.NVarChar, 64).Value = model.ShareTokenSymbol;
    cm.Parameters.Add("@DivTokenAddress", SqlDbType.NVarChar, 43).Value = model.DivTokenAddress;
    cm.Parameters.Add("@DivTokenSymbol", SqlDbType.NVarChar, 64).Value = model.DivTokenSymbol;
    cm.Parameters.Add("@DivTokenCurrentLiqAmount", SqlDbType.Float, 8).Value = model.DivTokenCurrentLiqAmount;
    cm.Parameters.Add("@UpdateBlockNumber", SqlDbType.BigInt, 8).Value = model.UpdateBlockNumber;
    cm.Parameters.Add("@Price0", SqlDbType.NVarChar, 36).Value = model.Price0;
    cm.Parameters.Add("@Price1", SqlDbType.NVarChar, 36).Value = model.Price1;
    cm.Parameters.Add("@DivTokenImagePath", SqlDbType.NVarChar, 2048).Value = model.DivTokenImagePath;
    cm.Parameters.Add("@ShareTokenIconLocalFileName", SqlDbType.NVarChar, 2048).Value = model.ShareTokenIconLocalFileName;

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

#region  表 DivShareTokenPairFactory_OnAddDivExPair 的GetModel操作
public static Model.DivShareTokenPairFactory_OnAddDivExPair GetModel(string conStr, System.Int32 ChainId, System.String ContractAddress, System.String TransactionHash)
{
    string sql = @"select * from DivShareTokenPairFactory_OnAddDivExPair Where ChainId = @ChainId and ContractAddress = @ContractAddress and TransactionHash = @TransactionHash ";

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
        return Model.DivShareTokenPairFactory_OnAddDivExPair.DataRow2Object(ds.Tables[0].Rows[0]);
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

#region  表 DivShareTokenPairFactory_OnAddDivExPair 的 Exist 操作 判断
public static bool Exist(string conStr, System.Int32 ChainId, System.String ContractAddress, System.String TransactionHash)
{
    string sql = @"Select Count(*) From DivShareTokenPairFactory_OnAddDivExPair Where ChainId = @ChainId and ContractAddress = @ContractAddress and TransactionHash = @TransactionHash ";
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