//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/5/17 15:44:09
//
using System;
using System.Data;
using System.Data.SqlClient;


namespace BlockChain.ShareToken.DAL
{
internal class DutchAuctionParam
{
#region 对应的数据库表 DutchAuctionParam
public const string TableName = @"DutchAuctionParam";
#endregion

#region  表 DutchAuctionParam 的Insert操作
public static void Insert(string conStr, Model.DutchAuctionParam model)
{
    string sql = @"insert into DutchAuctionParam (ChainId,ContractAddress,tokenSell,tokenSellAmountSellMin,tokenSellAmountBuyMin,UpdateTime,tokenSellAmountSellMin_Text,tokenSellAmountBuyMin_Text) values (@ChainId,@ContractAddress,@tokenSell,@tokenSellAmountSellMin,@tokenSellAmountBuyMin,@UpdateTime,@tokenSellAmountSellMin_Text,@tokenSellAmountBuyMin_Text)";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = model.ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = model.ContractAddress;
    cm.Parameters.Add("@tokenSell", SqlDbType.NVarChar, 43).Value = model.tokenSell;
    cm.Parameters.Add("@tokenSellAmountSellMin", SqlDbType.Float, 8).Value = model.tokenSellAmountSellMin;
    cm.Parameters.Add("@tokenSellAmountBuyMin", SqlDbType.Float, 8).Value = model.tokenSellAmountBuyMin;
    cm.Parameters.Add("@UpdateTime", SqlDbType.DateTime, 8).Value = model.UpdateTime;
    cm.Parameters.Add("@tokenSellAmountSellMin_Text", SqlDbType.NVarChar, 80).Value = model.tokenSellAmountSellMin_Text;
    cm.Parameters.Add("@tokenSellAmountBuyMin_Text", SqlDbType.NVarChar, 80).Value = model.tokenSellAmountBuyMin_Text;

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

#region  表 DutchAuctionParam 的Delete操作
public static int Delete(string conStr, System.Int32 ChainId,System.String ContractAddress,System.String tokenSell)
{
    string sql = @"Delete From DutchAuctionParam Where ChainId = @ChainId and ContractAddress = @ContractAddress and tokenSell = @tokenSell";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;
    cm.Parameters.Add("@tokenSell", SqlDbType.NVarChar, 43).Value = tokenSell;
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

#region  表 DutchAuctionParam 的 Update 操作
public static int Update(string conStr, Model.DutchAuctionParam model)
{
    string sql = @"Update DutchAuctionParam Set tokenSellAmountSellMin = @tokenSellAmountSellMin, tokenSellAmountBuyMin = @tokenSellAmountBuyMin, UpdateTime = @UpdateTime, tokenSellAmountSellMin_Text = @tokenSellAmountSellMin_Text, tokenSellAmountBuyMin_Text = @tokenSellAmountBuyMin_Text Where ChainId = @ChainId And ContractAddress = @ContractAddress And tokenSell = @tokenSell ";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = model.ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = model.ContractAddress;
    cm.Parameters.Add("@tokenSell", SqlDbType.NVarChar, 43).Value = model.tokenSell;
    cm.Parameters.Add("@tokenSellAmountSellMin", SqlDbType.Float, 8).Value = model.tokenSellAmountSellMin;
    cm.Parameters.Add("@tokenSellAmountBuyMin", SqlDbType.Float, 8).Value = model.tokenSellAmountBuyMin;
    cm.Parameters.Add("@UpdateTime", SqlDbType.DateTime, 8).Value = model.UpdateTime;
    cm.Parameters.Add("@tokenSellAmountSellMin_Text", SqlDbType.NVarChar, 80).Value = model.tokenSellAmountSellMin_Text;
    cm.Parameters.Add("@tokenSellAmountBuyMin_Text", SqlDbType.NVarChar, 80).Value = model.tokenSellAmountBuyMin_Text;

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

#region  表 DutchAuctionParam 的GetModel操作
public static Model.DutchAuctionParam GetModel(string conStr, System.Int32 ChainId, System.String ContractAddress, System.String tokenSell)
{
    string sql = @"select * from DutchAuctionParam Where ChainId = @ChainId and ContractAddress = @ContractAddress and tokenSell = @tokenSell ";

    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;
    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;
    cm.Parameters.Add("@tokenSell", SqlDbType.NVarChar, 43).Value = tokenSell;

    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = cm;
    System.Data.DataSet ds = new System.Data.DataSet();
    da.Fill(ds);
    if (ds.Tables[0].Rows.Count == 1)
    {
        return Model.DutchAuctionParam.DataRow2Object(ds.Tables[0].Rows[0]);
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

#region  表 DutchAuctionParam 的 Exist 操作 判断
public static bool Exist(string conStr, System.Int32 ChainId, System.String ContractAddress, System.String tokenSell)
{
    string sql = @"Select Count(*) From DutchAuctionParam Where ChainId = @ChainId and ContractAddress = @ContractAddress and tokenSell = @tokenSell ";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;
    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;
    cm.Parameters.Add("@tokenSell", SqlDbType.NVarChar, 43).Value = tokenSell;

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