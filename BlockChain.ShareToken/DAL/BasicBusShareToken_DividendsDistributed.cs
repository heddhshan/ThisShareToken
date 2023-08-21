//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/5/17 15:58:50
//
using System;
using System.Data;
using System.Data.SqlClient;


namespace BlockChain.ShareToken.DAL
{
internal class BasicBusShareToken_DividendsDistributed
{
#region 对应的数据库表 BasicBusShareToken_DividendsDistributed
public const string TableName = @"BasicBusShareToken_DividendsDistributed";
#endregion

#region  表 BasicBusShareToken_DividendsDistributed 的Insert操作
public static void Insert(string conStr, Model.BasicBusShareToken_DividendsDistributed model)
{
    string sql = @"insert into BasicBusShareToken_DividendsDistributed (ChainId,ContractAddress,BlockNumber,TransactionHash,CreateTime,DivToken,_dividendIndex,_caller,_waitingDivAmount,_realDivAmount,_currentSupply,_divHeight,_waitingDivAmount_Text,_realDivAmount_Text,_currentSupply_Text,_divHeight_Text) values (@ChainId,@ContractAddress,@BlockNumber,@TransactionHash,@CreateTime,@DivToken,@_dividendIndex,@_caller,@_waitingDivAmount,@_realDivAmount,@_currentSupply,@_divHeight,@_waitingDivAmount_Text,@_realDivAmount_Text,@_currentSupply_Text,@_divHeight_Text)";
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
    cm.Parameters.Add("@DivToken", SqlDbType.NVarChar, 43).Value = model.DivToken;
    cm.Parameters.Add("@_dividendIndex", SqlDbType.BigInt, 8).Value = model._dividendIndex;
    cm.Parameters.Add("@_caller", SqlDbType.NVarChar, 43).Value = model._caller;
    cm.Parameters.Add("@_waitingDivAmount", SqlDbType.Float, 8).Value = model._waitingDivAmount;
    cm.Parameters.Add("@_realDivAmount", SqlDbType.Float, 8).Value = model._realDivAmount;
    cm.Parameters.Add("@_currentSupply", SqlDbType.Float, 8).Value = model._currentSupply;
    cm.Parameters.Add("@_divHeight", SqlDbType.Float, 8).Value = model._divHeight;
    cm.Parameters.Add("@_waitingDivAmount_Text", SqlDbType.NVarChar, 80).Value = model._waitingDivAmount_Text;
    cm.Parameters.Add("@_realDivAmount_Text", SqlDbType.NVarChar, 80).Value = model._realDivAmount_Text;
    cm.Parameters.Add("@_currentSupply_Text", SqlDbType.NVarChar, 80).Value = model._currentSupply_Text;
    cm.Parameters.Add("@_divHeight_Text", SqlDbType.NVarChar, 80).Value = model._divHeight_Text;

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

#region  表 BasicBusShareToken_DividendsDistributed 的Delete操作
public static int Delete(string conStr, System.Int32 ChainId,System.String ContractAddress,System.Int64 _dividendIndex)
{
    string sql = @"Delete From BasicBusShareToken_DividendsDistributed Where ChainId = @ChainId and ContractAddress = @ContractAddress and _dividendIndex = @_dividendIndex";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;
    cm.Parameters.Add("@_dividendIndex", SqlDbType.BigInt, 8).Value = _dividendIndex;
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

#region  表 BasicBusShareToken_DividendsDistributed 的 Update 操作
public static int Update(string conStr, Model.BasicBusShareToken_DividendsDistributed model)
{
    string sql = @"Update BasicBusShareToken_DividendsDistributed Set BlockNumber = @BlockNumber, TransactionHash = @TransactionHash, CreateTime = @CreateTime, DivToken = @DivToken, _caller = @_caller, _waitingDivAmount = @_waitingDivAmount, _realDivAmount = @_realDivAmount, _currentSupply = @_currentSupply, _divHeight = @_divHeight, _waitingDivAmount_Text = @_waitingDivAmount_Text, _realDivAmount_Text = @_realDivAmount_Text, _currentSupply_Text = @_currentSupply_Text, _divHeight_Text = @_divHeight_Text Where ChainId = @ChainId And ContractAddress = @ContractAddress And _dividendIndex = @_dividendIndex ";
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
    cm.Parameters.Add("@DivToken", SqlDbType.NVarChar, 43).Value = model.DivToken;
    cm.Parameters.Add("@_dividendIndex", SqlDbType.BigInt, 8).Value = model._dividendIndex;
    cm.Parameters.Add("@_caller", SqlDbType.NVarChar, 43).Value = model._caller;
    cm.Parameters.Add("@_waitingDivAmount", SqlDbType.Float, 8).Value = model._waitingDivAmount;
    cm.Parameters.Add("@_realDivAmount", SqlDbType.Float, 8).Value = model._realDivAmount;
    cm.Parameters.Add("@_currentSupply", SqlDbType.Float, 8).Value = model._currentSupply;
    cm.Parameters.Add("@_divHeight", SqlDbType.Float, 8).Value = model._divHeight;
    cm.Parameters.Add("@_waitingDivAmount_Text", SqlDbType.NVarChar, 80).Value = model._waitingDivAmount_Text;
    cm.Parameters.Add("@_realDivAmount_Text", SqlDbType.NVarChar, 80).Value = model._realDivAmount_Text;
    cm.Parameters.Add("@_currentSupply_Text", SqlDbType.NVarChar, 80).Value = model._currentSupply_Text;
    cm.Parameters.Add("@_divHeight_Text", SqlDbType.NVarChar, 80).Value = model._divHeight_Text;

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

#region  表 BasicBusShareToken_DividendsDistributed 的GetModel操作
public static Model.BasicBusShareToken_DividendsDistributed GetModel(string conStr, System.Int32 ChainId, System.String ContractAddress, System.Int64 _dividendIndex)
{
    string sql = @"select * from BasicBusShareToken_DividendsDistributed Where ChainId = @ChainId and ContractAddress = @ContractAddress and _dividendIndex = @_dividendIndex ";

    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;
    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;
    cm.Parameters.Add("@_dividendIndex", SqlDbType.BigInt, 8).Value = _dividendIndex;

    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = cm;
    System.Data.DataSet ds = new System.Data.DataSet();
    da.Fill(ds);
    if (ds.Tables[0].Rows.Count == 1)
    {
        return Model.BasicBusShareToken_DividendsDistributed.DataRow2Object(ds.Tables[0].Rows[0]);
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

#region  表 BasicBusShareToken_DividendsDistributed 的 Exist 操作 判断
public static bool Exist(string conStr, System.Int32 ChainId, System.String ContractAddress, System.Int64 _dividendIndex)
{
    string sql = @"Select Count(*) From BasicBusShareToken_DividendsDistributed Where ChainId = @ChainId and ContractAddress = @ContractAddress and _dividendIndex = @_dividendIndex ";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;
    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;
    cm.Parameters.Add("@_dividendIndex", SqlDbType.BigInt, 8).Value = _dividendIndex;

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