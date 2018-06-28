/**  版本信息模板在安装目录下，可自行修改。
* Customer.cs
*
* 功 能： N/A
* 类 名： Customer
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/20 20:48:51   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Customer
	/// </summary>
	public partial class Customer
	{
		public Customer()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("customer_id", "Customer"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int customer_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Customer");
			strSql.Append(" where customer_id=@customer_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@customer_id", SqlDbType.Int,4)			};
			parameters[0].Value = customer_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Customer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Customer(");
			strSql.Append("customer_id,customer_name,customer_addr,customer_phone)");
			strSql.Append(" values (");
			strSql.Append("@customer_id,@customer_name,@customer_addr,@customer_phone)");
			SqlParameter[] parameters = {
					new SqlParameter("@customer_id", SqlDbType.Int,4),
					new SqlParameter("@customer_name", SqlDbType.NVarChar,20),
					new SqlParameter("@customer_addr", SqlDbType.NVarChar,50),
					new SqlParameter("@customer_phone", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.customer_id;
			parameters[1].Value = model.customer_name;
			parameters[2].Value = model.customer_addr;
			parameters[3].Value = model.customer_phone;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Customer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Customer set ");
			strSql.Append("customer_name=@customer_name,");
			strSql.Append("customer_addr=@customer_addr,");
			strSql.Append("customer_phone=@customer_phone");
			strSql.Append(" where customer_id=@customer_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@customer_name", SqlDbType.NVarChar,20),
					new SqlParameter("@customer_addr", SqlDbType.NVarChar,50),
					new SqlParameter("@customer_phone", SqlDbType.NVarChar,50),
					new SqlParameter("@customer_id", SqlDbType.Int,4)};
			parameters[0].Value = model.customer_name;
			parameters[1].Value = model.customer_addr;
			parameters[2].Value = model.customer_phone;
			parameters[3].Value = model.customer_id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int customer_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Customer ");
			strSql.Append(" where customer_id=@customer_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@customer_id", SqlDbType.Int,4)			};
			parameters[0].Value = customer_id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string customer_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Customer ");
			strSql.Append(" where customer_id in ("+customer_idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Customer GetModel(int customer_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 customer_id,customer_name,customer_addr,customer_phone from Customer ");
			strSql.Append(" where customer_id=@customer_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@customer_id", SqlDbType.Int,4)			};
			parameters[0].Value = customer_id;

			Maticsoft.Model.Customer model=new Maticsoft.Model.Customer();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Customer DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Customer model=new Maticsoft.Model.Customer();
			if (row != null)
			{
				if(row["customer_id"]!=null && row["customer_id"].ToString()!="")
				{
					model.customer_id=int.Parse(row["customer_id"].ToString());
				}
				if(row["customer_name"]!=null)
				{
					model.customer_name=row["customer_name"].ToString();
				}
				if(row["customer_addr"]!=null)
				{
					model.customer_addr=row["customer_addr"].ToString();
				}
				if(row["customer_phone"]!=null)
				{
					model.customer_phone=row["customer_phone"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select customer_id,customer_name,customer_addr,customer_phone ");
			strSql.Append(" FROM Customer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" customer_id,customer_name,customer_addr,customer_phone ");
			strSql.Append(" FROM Customer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Customer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.customer_id desc");
			}
			strSql.Append(")AS Row, T.*  from Customer T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Customer";
			parameters[1].Value = "customer_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

