/**  版本信息模板在安装目录下，可自行修改。
* Ordering.cs
*
* 功 能： N/A
* 类 名： Ordering
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/20 20:48:52   N/A    初版
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
	/// 数据访问类:Ordering
	/// </summary>
	public partial class Ordering
	{
		public Ordering()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("customer_id", "Ordering"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int customer_id,int order_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ordering");
			strSql.Append(" where customer_id=@customer_id and order_id=@order_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@customer_id", SqlDbType.Int,4),
					new SqlParameter("@order_id", SqlDbType.Int,4)			};
			parameters[0].Value = customer_id;
			parameters[1].Value = order_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Ordering model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ordering(");
			strSql.Append("customer_id,order_id,ordering_time,table_id)");
			strSql.Append(" values (");
			strSql.Append("@customer_id,@order_id,@ordering_time,@table_id)");
			SqlParameter[] parameters = {
					new SqlParameter("@customer_id", SqlDbType.Int,4),
					new SqlParameter("@order_id", SqlDbType.Int,4),
					new SqlParameter("@ordering_time", SqlDbType.DateTime),
					new SqlParameter("@table_id", SqlDbType.Int,4)};
			parameters[0].Value = model.customer_id;
			parameters[1].Value = model.order_id;
			parameters[2].Value = model.ordering_time;
			parameters[3].Value = model.table_id;

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
		public bool Update(Maticsoft.Model.Ordering model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ordering set ");
			strSql.Append("ordering_time=@ordering_time,");
			strSql.Append("table_id=@table_id");
			strSql.Append(" where customer_id=@customer_id and order_id=@order_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@ordering_time", SqlDbType.DateTime),
					new SqlParameter("@table_id", SqlDbType.Int,4),
					new SqlParameter("@customer_id", SqlDbType.Int,4),
					new SqlParameter("@order_id", SqlDbType.Int,4)};
			parameters[0].Value = model.ordering_time;
			parameters[1].Value = model.table_id;
			parameters[2].Value = model.customer_id;
			parameters[3].Value = model.order_id;

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
		public bool Delete(int customer_id,int order_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ordering ");
			strSql.Append(" where customer_id=@customer_id and order_id=@order_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@customer_id", SqlDbType.Int,4),
					new SqlParameter("@order_id", SqlDbType.Int,4)			};
			parameters[0].Value = customer_id;
			parameters[1].Value = order_id;

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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Ordering GetModel(int customer_id,int order_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 customer_id,order_id,ordering_time,table_id from Ordering ");
			strSql.Append(" where customer_id=@customer_id and order_id=@order_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@customer_id", SqlDbType.Int,4),
					new SqlParameter("@order_id", SqlDbType.Int,4)			};
			parameters[0].Value = customer_id;
			parameters[1].Value = order_id;

			Maticsoft.Model.Ordering model=new Maticsoft.Model.Ordering();
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
		public Maticsoft.Model.Ordering DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Ordering model=new Maticsoft.Model.Ordering();
			if (row != null)
			{
				if(row["customer_id"]!=null && row["customer_id"].ToString()!="")
				{
					model.customer_id=int.Parse(row["customer_id"].ToString());
				}
				if(row["order_id"]!=null && row["order_id"].ToString()!="")
				{
					model.order_id=int.Parse(row["order_id"].ToString());
				}
				if(row["ordering_time"]!=null && row["ordering_time"].ToString()!="")
				{
					model.ordering_time=DateTime.Parse(row["ordering_time"].ToString());
				}
				if(row["table_id"]!=null && row["table_id"].ToString()!="")
				{
					model.table_id=int.Parse(row["table_id"].ToString());
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
			strSql.Append("select customer_id,order_id,ordering_time,table_id ");
			strSql.Append(" FROM Ordering ");
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
			strSql.Append(" customer_id,order_id,ordering_time,table_id ");
			strSql.Append(" FROM Ordering ");
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
			strSql.Append("select count(1) FROM Ordering ");
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
				strSql.Append("order by T.order_id desc");
			}
			strSql.Append(")AS Row, T.*  from Ordering T ");
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
			parameters[0].Value = "Ordering";
			parameters[1].Value = "order_id";
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

