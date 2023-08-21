//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/5/17 15:58:50
//
using System;
using System.Data;
using System.Data.SqlClient;


namespace BlockChain.ShareToken.DAL
{
internal class DivShareTokenPair_DividendsDistributed
{
#region 对应的数据库表 DivShareTokenPair_DividendsDistributed
public const string TableName = @"DivShareTokenPair_DividendsDistributed";
#endregion

#region  表 DivShareTokenPair_DividendsDistributed 的Insert操作
public static void Insert(string conStr, Model.DivShareTokenPair_DividendsDistributed model)
{
    string sql = @"insert into DivShareTokenPair_DividendsDistributed (ChainId,ContractAddress,BlockNumber,TransactionHash,CreateTime,DivTokenAddress,_dividendIndex,_from,_divAmount,_currentLiqValue,_shareTokenHeight,_pairHeight,_pairHeight_Text,_shareTokenHeight_Text,_divAmount_Text,_currentLiqValue_Text) values (@ChainId,@ContractAddress,@BlockNumber,@TransactionHash,@CreateTime,@DivTokenAddress,@_dividendIndex,@_from,@_divAmount,@_currentLiqValue,@_shareTokenHeight,@_pairHeight,@_pairHeight_Text,@_shareTokenHeight_Text,@_divAmount_Text,@_currentLiqValue_Text)";
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
    cm.Parameters.Add("@DivTokenAddress", SqlDbType.NVarChar, 43).Value = model.DivTokenAddress;
    cm.Parameters.Add("@_dividendIndex", SqlDbType.BigInt, 8).Value = model._dividendIndex;
    cm.Parameters.Add("@_from", SqlDbType.NVarChar, 43).Value = model._from;
    cm.Parameters.Add("@_divAmount", SqlDbType.Float, 8).Value = model._divAmount;
    cm.Parameters.Add("@_currentLiqValue", SqlDbType.Float, 8).Value = model._currentLiqValue;
    cm.Parameters.Add("@_shareTokenHeight", SqlDbType.Float, 8).Value = model._shareTokenHeight;
    cm.Parameters.Add("@_pairHeight", SqlDbType.Float, 8).Value = model._pairHeight;
    cm.Parameters.Add("@_pairHeight_Text", SqlDbType.NVarChar, 80).Value = model._pairHeight_Text;
    cm.Parameters.Add("@_shareTokenHeight_Text", SqlDbType.NVarChar, 80).Value = model._shareTokenHeight_Text;
    cm.Parameters.Add("@_divAmount_Text", SqlDbType.NVarChar, 80).Value = model._divAmount_Text;
    cm.Parameters.Add("@_currentLiqValue_Text", SqlDbType.NVarChar, 80).Value = model._currentLiqValue_Text;

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

#region  表 DivShareTokenPair_DividendsDistributed 的Delete操作
public static int Delete(string conStr, System.Int32 ChainId,System.String ContractAddress,System.String TransactionHash)
{
    string sql = @"Delete From DivShareTokenPair_DividendsDistributed Where ChainId = @ChainId and ContractAddress = @ContractAddress and TransactionHash = @TransactionHash";
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

#region  表 DivShareTokenPair_DividendsDistributed 的 Update 操作
public static int Update(string conStr, Model.DivShareTokenPair_DividendsDistributed model)
{
    string sql = @"Update DivShareTokenPair_DividendsDistributed Set BlockNumber = @BlockNumber, CreateTime = @CreateTime, DivTokenAddress = @DivTokenAddress, _dividendIndex = @_dividendIndex, _from = @_from, _divAmount = @_divAmount, _currentLiqValue = @_currentLiqValue, _shareTokenHeight = @_shareTokenHeight, _pairHeight = @_pairHeight, _pairHeight_Text = @_pairHeight_Text, _shareTokenHeight_Text = @_shareTokenHeight_Text, _divAmount_Text = @_divAmount_Text, _currentLiqValue_Text = @_currentLiqValue_Text Where ChainId = @ChainId And ContractAddress = @ContractAddress And TransactionHash = @TransactionHash ";
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
    cm.Parameters.Add("@DivTokenAddress", SqlDbType.NVarChar, 43).Value = model.DivTokenAddress;
    cm.Parameters.Add("@_dividendIndex", SqlDbType.BigInt, 8).Value = model._dividendIndex;
    cm.Parameters.Add("@_from", SqlDbType.NVarChar, 43).Value = model._from;
    cm.Parameters.Add("@_divAmount", SqlDbType.Float, 8).Value = model._divAmount;
    cm.Parameters.Add("@_currentLiqValue", SqlDbType.Float, 8).Value = model._currentLiqValue;
    cm.Parameters.Add("@_shareTokenHeight", SqlDbType.Float, 8).Value = model._shareTokenHeight;
    cm.Parameters.Add("@_pairHeight", SqlDbType.Float, 8).Value = model._pairHeight;
    cm.Parameters.Add("@_pairHeight_Text", SqlDbType.NVarChar, 80).Value = model._pairHeight_Text;
    cm.Parameters.Add("@_shareTokenHeight_Text", SqlDbType.NVarChar, 80).Value = model._shareTokenHeight_Text;
    cm.Parameters.Add("@_divAmount_Text", SqlDbType.NVarChar, 80).Value = model._divAmount_Text;
    cm.Parameters.Add("@_currentLiqValue_Text", SqlDbType.NVarChar, 80).Value = model._currentLiqValue_Text;

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

#region  表 DivShareTokenPair_DividendsDistributed 的GetModel操作
public static Model.DivShareTokenPair_DividendsDistributed GetModel(string conStr, System.Int32 ChainId, System.String ContractAddress, System.String TransactionHash)
{
    string sql = @"select * from DivShareTokenPair_DividendsDistributed Where ChainId = @ChainId and ContractAddress = @ContractAddress and TransactionHash = @TransactionHash ";

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
        return Model.DivShareTokenPair_DividendsDistributed.DataRow2Object(ds.Tables[0].Rows[0]);
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

#region  表 DivShareTokenPair_DividendsDistributed 的 Exist 操作 判断
public static bool Exist(string conStr, System.Int32 ChainId, System.String ContractAddress, System.String TransactionHash)
{
    string sql = @"Select Count(*) From DivShareTokenPair_DividendsDistributed Where ChainId = @ChainId and ContractAddress = @ContractAddress and TransactionHash = @TransactionHash ";
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