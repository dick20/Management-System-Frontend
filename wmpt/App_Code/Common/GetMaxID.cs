using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
///Class1 的摘要说明
/// </summary>
public class GetMaxID
{
	public GetMaxID()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public static int getid(int n,string table){
        string sqlstr = "Update system_MaxID set MaxID=MaxID+@N  where TbaleName=@tablename; ";
        sqlstr += "select MaxId from system_MaxID where TbaleName=@tablename ";
        SqlParameter[] parameters = {
		    new SqlParameter("@N", SqlDbType.Int),
		    new SqlParameter("@tablename", SqlDbType.VarChar, 255)
            };
        parameters[0].Value = n;
        parameters[1].Value = table;
        object o = Maticsoft.DBUtility.DbHelperSQL.GetSingle(sqlstr, parameters);
        if (o!=null)
	    {
            return (int)o;
	    }
        else
        {
            string sql = "insert into system_MaxID values ('" + table + "','1')";
            Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(sql);
            return 1;
        }
        
    }
    public static int praseInt(string str) {
        try
        {
            return int.Parse(str);
        }
        catch (Exception)
        {

            return 0;
        }
    }
    public static double praseDouble(string str)
    {
        try
        {
            return double.Parse(str);
        }
        catch (Exception)
        {

            return 0;
        }
    }


}