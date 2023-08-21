﻿//
//  本文件由代码工具自动生成。如非必要请不要修改。2023/4/6 11:25:11
//
using System;
using System.Data;
using System.Data.SqlClient;


namespace BlockChain.Share.DAL
{
internal class Web3Url
{
#region 对应的数据库表 Web3Url
public const string TableName = @"Web3Url";
#endregion

#region  表 Web3Url 的Insert操作
public static void Insert(string conStr, Model.Web3Url model)
{
    string sql = @"insert into Web3Url (Layer,UrlAlias,UrlHash,Url,IsSelected) values (@Layer,@UrlAlias,@UrlHash,@Url,@IsSelected)";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@Layer", SqlDbType.Int, 4).Value = model.Layer;
    cm.Parameters.Add("@UrlAlias", SqlDbType.NVarChar, 64).Value = model.UrlAlias;
    cm.Parameters.Add("@UrlHash", SqlDbType.NVarChar, 128).Value = model.UrlHash;
    cm.Parameters.Add("@Url", SqlDbType.NVarChar, 2000).Value = model.Url;
    cm.Parameters.Add("@IsSelected", SqlDbType.Bit, 1).Value = model.IsSelected;

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

#region  表 Web3Url 的Delete操作
public static int Delete(string conStr, System.Int32 Layer,System.String UrlAlias)
{
    string sql = @"Delete From Web3Url Where Layer = @Layer and UrlAlias = @UrlAlias";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@Layer", SqlDbType.Int, 4).Value = Layer;
    cm.Parameters.Add("@UrlAlias", SqlDbType.NVarChar, 64).Value = UrlAlias;
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

#region  表 Web3Url 的 Update 操作
public static int Update(string conStr, Model.Web3Url model)
{
    string sql = @"Update Web3Url Set UrlHash = @UrlHash, Url = @Url, IsSelected = @IsSelected Where Layer = @Layer And UrlAlias = @UrlAlias ";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;

    cm.Parameters.Add("@Layer", SqlDbType.Int, 4).Value = model.Layer;
    cm.Parameters.Add("@UrlAlias", SqlDbType.NVarChar, 64).Value = model.UrlAlias;
    cm.Parameters.Add("@UrlHash", SqlDbType.NVarChar, 128).Value = model.UrlHash;
    cm.Parameters.Add("@Url", SqlDbType.NVarChar, 2000).Value = model.Url;
    cm.Parameters.Add("@IsSelected", SqlDbType.Bit, 1).Value = model.IsSelected;

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

#region  表 Web3Url 的GetModel操作
public static Model.Web3Url GetModel(string conStr, System.Int32 Layer, System.String UrlAlias)
{
    string sql = @"select * from Web3Url Where Layer = @Layer and UrlAlias = @UrlAlias ";

    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;
    cm.Parameters.Add("@Layer", SqlDbType.Int, 4).Value = Layer;
    cm.Parameters.Add("@UrlAlias", SqlDbType.NVarChar, 64).Value = UrlAlias;

    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = cm;
    System.Data.DataSet ds = new System.Data.DataSet();
    da.Fill(ds);
    if (ds.Tables[0].Rows.Count == 1)
    {
        return Model.Web3Url.DataRow2Object(ds.Tables[0].Rows[0]);
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

#region  表 Web3Url 的 Exist 操作 判断
public static bool Exist(string conStr, System.Int32 Layer, System.String UrlAlias)
{
    string sql = @"Select Count(*) From Web3Url Where Layer = @Layer and UrlAlias = @UrlAlias ";
    SqlConnection cn = new SqlConnection(conStr);
    SqlCommand cm = new SqlCommand();
    cm.Connection = cn;
    cm.CommandType = System.Data.CommandType.Text;
    cm.CommandText = sql;
    cm.Parameters.Add("@Layer", SqlDbType.Int, 4).Value = Layer;
    cm.Parameters.Add("@UrlAlias", SqlDbType.NVarChar, 64).Value = UrlAlias;

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