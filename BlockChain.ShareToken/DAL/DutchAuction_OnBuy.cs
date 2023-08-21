//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/5/17 15:44:09
//
using System;
using System.Data;
using System.Data.SqlClient;


namespace BlockChain.ShareToken.DAL
{
internal class DutchAuction_OnBuy
{
#region 对应的数据库表 DutchAuction_OnBuy
public const string TableName = @"DutchAuction_OnBuy";
#endregion

#region  表 DutchAuction_OnBuy 的Insert操作
public static void Insert(string conStr, Model.DutchAuction_OnBuy model)
{
    string sql = @"insert into DutchAuction_OnBuy (ChainId,ContractAddress,BlockNumber,TransactionHash,_buyer,_seller,_sellHash,_sellTokenAmountOut,_buyTokenAmountIn,_sellTokenAmountOut_Text,_buyTokenAmountIn_Text) values (@ChainId,@ContractAddress,@BlockNumber,@TransactionHash,@_buyer,@_seller,@_sellHash,@_sellTokenAmountOut,@_buyTokenAmountIn,@_sellTokenAmountOut_Text,@_buyTokenAmountIn_Text)";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = model.ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = model.ContractAddress;
    cm.Parameters.Add("@BlockNumber", SqlDbType.BigInt, 8).Value = model.BlockNumber;
    cm.Parameters.Add("@TransactionHash", SqlDbType.NVarChar, 66).Value = model.TransactionHash;
    cm.Parameters.Add("@_buyer", SqlDbType.NVarChar, 43).Value = model._buyer;
    cm.Parameters.Add("@_seller", SqlDbType.NVarChar, 43).Value = model._seller;
    cm.Parameters.Add("@_sellHash", SqlDbType.NVarChar, 66).Value = model._sellHash;
    cm.Parameters.Add("@_sellTokenAmountOut", SqlDbType.Float, 8).Value = model._sellTokenAmountOut;
    cm.Parameters.Add("@_buyTokenAmountIn", SqlDbType.Float, 8).Value = model._buyTokenAmountIn;
    cm.Parameters.Add("@_sellTokenAmountOut_Text", SqlDbType.NVarChar, 80).Value = model._sellTokenAmountOut_Text;
    cm.Parameters.Add("@_buyTokenAmountIn_Text", SqlDbType.NVarChar, 80).Value = model._buyTokenAmountIn_Text;

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

#region  表 DutchAuction_OnBuy 的Delete操作
public static int Delete(string conStr, System.Int32 ChainId,System.String ContractAddress,System.String _sellHash)
{
    string sql = @"Delete From DutchAuction_OnBuy Where ChainId = @ChainId and ContractAddress = @ContractAddress and _sellHash = @_sellHash";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;
    cm.Parameters.Add("@_sellHash", SqlDbType.NVarChar, 66).Value = _sellHash;
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

#region  表 DutchAuction_OnBuy 的 Update 操作
public static int Update(string conStr, Model.DutchAuction_OnBuy model)
{
    string sql = @"Update DutchAuction_OnBuy Set BlockNumber = @BlockNumber, TransactionHash = @TransactionHash, _buyer = @_buyer, _seller = @_seller, _sellTokenAmountOut = @_sellTokenAmountOut, _buyTokenAmountIn = @_buyTokenAmountIn, _sellTokenAmountOut_Text = @_sellTokenAmountOut_Text, _buyTokenAmountIn_Text = @_buyTokenAmountIn_Text Where ChainId = @ChainId And ContractAddress = @ContractAddress And _sellHash = @_sellHash ";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = model.ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = model.ContractAddress;
    cm.Parameters.Add("@BlockNumber", SqlDbType.BigInt, 8).Value = model.BlockNumber;
    cm.Parameters.Add("@TransactionHash", SqlDbType.NVarChar, 66).Value = model.TransactionHash;
    cm.Parameters.Add("@_buyer", SqlDbType.NVarChar, 43).Value = model._buyer;
    cm.Parameters.Add("@_seller", SqlDbType.NVarChar, 43).Value = model._seller;
    cm.Parameters.Add("@_sellHash", SqlDbType.NVarChar, 66).Value = model._sellHash;
    cm.Parameters.Add("@_sellTokenAmountOut", SqlDbType.Float, 8).Value = model._sellTokenAmountOut;
    cm.Parameters.Add("@_buyTokenAmountIn", SqlDbType.Float, 8).Value = model._buyTokenAmountIn;
    cm.Parameters.Add("@_sellTokenAmountOut_Text", SqlDbType.NVarChar, 80).Value = model._sellTokenAmountOut_Text;
    cm.Parameters.Add("@_buyTokenAmountIn_Text", SqlDbType.NVarChar, 80).Value = model._buyTokenAmountIn_Text;

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

#region  表 DutchAuction_OnBuy 的GetModel操作
public static Model.DutchAuction_OnBuy GetModel(string conStr, System.Int32 ChainId, System.String ContractAddress, System.String _sellHash)
{
    string sql = @"select * from DutchAuction_OnBuy Where ChainId = @ChainId and ContractAddress = @ContractAddress and _sellHash = @_sellHash ";

    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;
    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;
    cm.Parameters.Add("@_sellHash", SqlDbType.NVarChar, 66).Value = _sellHash;

    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = cm;
    System.Data.DataSet ds = new System.Data.DataSet();
    da.Fill(ds);
    if (ds.Tables[0].Rows.Count == 1)
    {
        return Model.DutchAuction_OnBuy.DataRow2Object(ds.Tables[0].Rows[0]);
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

#region  表 DutchAuction_OnBuy 的 Exist 操作 判断
public static bool Exist(string conStr, System.Int32 ChainId, System.String ContractAddress, System.String _sellHash)
{
    string sql = @"Select Count(*) From DutchAuction_OnBuy Where ChainId = @ChainId and ContractAddress = @ContractAddress and _sellHash = @_sellHash ";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;
    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;
    cm.Parameters.Add("@_sellHash", SqlDbType.NVarChar, 66).Value = _sellHash;

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