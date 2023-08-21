//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/5/17 15:44:09
//
using System;
using System.Data;
using System.Data.SqlClient;


namespace BlockChain.ShareToken.DAL
{
internal class DutchAuction_OnSell
{
#region 对应的数据库表 DutchAuction_OnSell
public const string TableName = @"DutchAuction_OnSell";
#endregion

#region  表 DutchAuction_OnSell 的Insert操作
public static void Insert(string conStr, Model.DutchAuction_OnSell model)
{
    string sql = @"insert into DutchAuction_OnSell (ChainId,ContractAddress,BlockNumber,TransactionHash,_seller,_tokenSell,_tokenSellAmount,_tokenBuy,_buyHighestAmount,_sellId,_sellHash,curTokenSellAmount,next1Block,next1Price,next2Block,next2Price,next3Block,next3Price,_tokenSellAmount_Text,_buyHighestAmount_Text,curTokenSellAmount_Text,CreateTime,UpdateTime,IsDone) values (@ChainId,@ContractAddress,@BlockNumber,@TransactionHash,@_seller,@_tokenSell,@_tokenSellAmount,@_tokenBuy,@_buyHighestAmount,@_sellId,@_sellHash,@curTokenSellAmount,@next1Block,@next1Price,@next2Block,@next2Price,@next3Block,@next3Price,@_tokenSellAmount_Text,@_buyHighestAmount_Text,@curTokenSellAmount_Text,@CreateTime,@UpdateTime,@IsDone)";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = model.ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = model.ContractAddress;
    cm.Parameters.Add("@BlockNumber", SqlDbType.BigInt, 8).Value = model.BlockNumber;
    cm.Parameters.Add("@TransactionHash", SqlDbType.NVarChar, 66).Value = model.TransactionHash;
    cm.Parameters.Add("@_seller", SqlDbType.NVarChar, 43).Value = model._seller;
    cm.Parameters.Add("@_tokenSell", SqlDbType.NVarChar, 43).Value = model._tokenSell;
    cm.Parameters.Add("@_tokenSellAmount", SqlDbType.Float, 8).Value = model._tokenSellAmount;
    cm.Parameters.Add("@_tokenBuy", SqlDbType.NVarChar, 43).Value = model._tokenBuy;
    cm.Parameters.Add("@_buyHighestAmount", SqlDbType.Float, 8).Value = model._buyHighestAmount;
    cm.Parameters.Add("@_sellId", SqlDbType.BigInt, 8).Value = model._sellId;
    cm.Parameters.Add("@_sellHash", SqlDbType.NVarChar, 66).Value = model._sellHash;
    cm.Parameters.Add("@curTokenSellAmount", SqlDbType.Float, 8).Value = model.curTokenSellAmount;
    cm.Parameters.Add("@next1Block", SqlDbType.BigInt, 8).Value = model.next1Block;
    cm.Parameters.Add("@next1Price", SqlDbType.Float, 8).Value = model.next1Price;
    cm.Parameters.Add("@next2Block", SqlDbType.BigInt, 8).Value = model.next2Block;
    cm.Parameters.Add("@next2Price", SqlDbType.Float, 8).Value = model.next2Price;
    cm.Parameters.Add("@next3Block", SqlDbType.BigInt, 8).Value = model.next3Block;
    cm.Parameters.Add("@next3Price", SqlDbType.Float, 8).Value = model.next3Price;
    cm.Parameters.Add("@_tokenSellAmount_Text", SqlDbType.NVarChar, 80).Value = model._tokenSellAmount_Text;
    cm.Parameters.Add("@_buyHighestAmount_Text", SqlDbType.NVarChar, 80).Value = model._buyHighestAmount_Text;
    cm.Parameters.Add("@curTokenSellAmount_Text", SqlDbType.NVarChar, 80).Value = model.curTokenSellAmount_Text;
    cm.Parameters.Add("@CreateTime", SqlDbType.DateTime, 8).Value = model.CreateTime;
    cm.Parameters.Add("@UpdateTime", SqlDbType.DateTime, 8).Value = model.UpdateTime;
    cm.Parameters.Add("@IsDone", SqlDbType.Bit, 1).Value = model.IsDone;

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

#region  表 DutchAuction_OnSell 的Delete操作
public static int Delete(string conStr, System.Int32 ChainId,System.String ContractAddress,System.Int64 _sellId)
{
    string sql = @"Delete From DutchAuction_OnSell Where ChainId = @ChainId and ContractAddress = @ContractAddress and _sellId = @_sellId";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;
    cm.Parameters.Add("@_sellId", SqlDbType.BigInt, 8).Value = _sellId;
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

#region  表 DutchAuction_OnSell 的 Update 操作
public static int Update(string conStr, Model.DutchAuction_OnSell model)
{
    string sql = @"Update DutchAuction_OnSell Set BlockNumber = @BlockNumber, TransactionHash = @TransactionHash, _seller = @_seller, _tokenSell = @_tokenSell, _tokenSellAmount = @_tokenSellAmount, _tokenBuy = @_tokenBuy, _buyHighestAmount = @_buyHighestAmount, _sellHash = @_sellHash, curTokenSellAmount = @curTokenSellAmount, next1Block = @next1Block, next1Price = @next1Price, next2Block = @next2Block, next2Price = @next2Price, next3Block = @next3Block, next3Price = @next3Price, _tokenSellAmount_Text = @_tokenSellAmount_Text, _buyHighestAmount_Text = @_buyHighestAmount_Text, curTokenSellAmount_Text = @curTokenSellAmount_Text, CreateTime = @CreateTime, UpdateTime = @UpdateTime, IsDone = @IsDone Where ChainId = @ChainId And ContractAddress = @ContractAddress And _sellId = @_sellId ";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = model.ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = model.ContractAddress;
    cm.Parameters.Add("@BlockNumber", SqlDbType.BigInt, 8).Value = model.BlockNumber;
    cm.Parameters.Add("@TransactionHash", SqlDbType.NVarChar, 66).Value = model.TransactionHash;
    cm.Parameters.Add("@_seller", SqlDbType.NVarChar, 43).Value = model._seller;
    cm.Parameters.Add("@_tokenSell", SqlDbType.NVarChar, 43).Value = model._tokenSell;
    cm.Parameters.Add("@_tokenSellAmount", SqlDbType.Float, 8).Value = model._tokenSellAmount;
    cm.Parameters.Add("@_tokenBuy", SqlDbType.NVarChar, 43).Value = model._tokenBuy;
    cm.Parameters.Add("@_buyHighestAmount", SqlDbType.Float, 8).Value = model._buyHighestAmount;
    cm.Parameters.Add("@_sellId", SqlDbType.BigInt, 8).Value = model._sellId;
    cm.Parameters.Add("@_sellHash", SqlDbType.NVarChar, 66).Value = model._sellHash;
    cm.Parameters.Add("@curTokenSellAmount", SqlDbType.Float, 8).Value = model.curTokenSellAmount;
    cm.Parameters.Add("@next1Block", SqlDbType.BigInt, 8).Value = model.next1Block;
    cm.Parameters.Add("@next1Price", SqlDbType.Float, 8).Value = model.next1Price;
    cm.Parameters.Add("@next2Block", SqlDbType.BigInt, 8).Value = model.next2Block;
    cm.Parameters.Add("@next2Price", SqlDbType.Float, 8).Value = model.next2Price;
    cm.Parameters.Add("@next3Block", SqlDbType.BigInt, 8).Value = model.next3Block;
    cm.Parameters.Add("@next3Price", SqlDbType.Float, 8).Value = model.next3Price;
    cm.Parameters.Add("@_tokenSellAmount_Text", SqlDbType.NVarChar, 80).Value = model._tokenSellAmount_Text;
    cm.Parameters.Add("@_buyHighestAmount_Text", SqlDbType.NVarChar, 80).Value = model._buyHighestAmount_Text;
    cm.Parameters.Add("@curTokenSellAmount_Text", SqlDbType.NVarChar, 80).Value = model.curTokenSellAmount_Text;
    cm.Parameters.Add("@CreateTime", SqlDbType.DateTime, 8).Value = model.CreateTime;
    cm.Parameters.Add("@UpdateTime", SqlDbType.DateTime, 8).Value = model.UpdateTime;
    cm.Parameters.Add("@IsDone", SqlDbType.Bit, 1).Value = model.IsDone;

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

#region  表 DutchAuction_OnSell 的GetModel操作
public static Model.DutchAuction_OnSell GetModel(string conStr, System.Int32 ChainId, System.String ContractAddress, System.Int64 _sellId)
{
    string sql = @"select * from DutchAuction_OnSell Where ChainId = @ChainId and ContractAddress = @ContractAddress and _sellId = @_sellId ";

    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;
    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;
    cm.Parameters.Add("@_sellId", SqlDbType.BigInt, 8).Value = _sellId;

    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = cm;
    System.Data.DataSet ds = new System.Data.DataSet();
    da.Fill(ds);
    if (ds.Tables[0].Rows.Count == 1)
    {
        return Model.DutchAuction_OnSell.DataRow2Object(ds.Tables[0].Rows[0]);
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

#region  表 DutchAuction_OnSell 的 Exist 操作 判断
public static bool Exist(string conStr, System.Int32 ChainId, System.String ContractAddress, System.Int64 _sellId)
{
    string sql = @"Select Count(*) From DutchAuction_OnSell Where ChainId = @ChainId and ContractAddress = @ContractAddress and _sellId = @_sellId ";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;
    cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = ChainId;
    cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;
    cm.Parameters.Add("@_sellId", SqlDbType.BigInt, 8).Value = _sellId;

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