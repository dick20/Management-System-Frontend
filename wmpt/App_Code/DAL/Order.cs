/**  版本信息模板在安装目录下，可自行修改。
* Order.cs
*
* 功 能： N/A
* 类 名： Order
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
	/// 数据访问类:Order
	/// </summary>
	public partial class Order
	{
		public Order()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("order_id", "Order"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int order_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Order]");
			strSql.Append(" where order_id=@order_id");
			SqlParameter[] parameters = {
					new SqlParameter("@order_id", SqlDbType.Int,4)
			};
			parameters[0].Value = order_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Order](");
			strSql.Append("order_id,total,order_info,order_state,remark)");
			strSql.Append(" values (");
			strSql.Append("@order_id,@total,@order_info,@order_state,@remark)");
			SqlParameter[] parameters = {
					new SqlParameter("@order_id", SqlDbType.Int,4),
					new SqlParameter("@total", SqlDbType.Float,8),
					new SqlParameter("@order_info", SqlDbType.NVarChar,500),
					new SqlParameter("@order_state", SqlDbType.NVarChar,10),
					new SqlParameter("@remark", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.order_id;
			parameters[1].Value = model.total;
			parameters[2].Value = model.order_info;
			parameters[3].Value = model.order_state;
			parameters[4].Value = model.remark;

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
		public bool Update(Maticsoft.Model.Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Order] set ");
			strSql.Append("total=@total,");
			strSql.Append("order_info=@order_info,");
			strSql.Append("order_state=@order_state,");
			strSql.Append("remark=@remark");
			strSql.Append(" where order_id=@order_id");
			SqlParameter[] parameters = {
					new SqlParameter("@total", SqlDbType.Float,8),
					new SqlParameter("@order_info", SqlDbType.NVarChar,500),
					new SqlParameter("@order_state", SqlDbType.NVarChar,10),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@order_id", SqlDbType.Int,4)};
			parameters[0].Value = model.total;
			parameters[1].Value = model.order_info;
			parameters[2].Value = model.order_state;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.order_id;

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
		public bool Delete(int order_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Order] ");
			strSql.Append(" where order_id=@order_id");
			SqlParameter[] parameters = {
					new SqlParameter("@order_id", SqlDbType.Int,4)
			};
			parameters[0].Value = order_id;

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
		public bool DeleteList(string order_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Order] ");
			strSql.Append(" where order_id in ("+order_idlist + ")  ");
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
		public Maticsoft.Model.Order GetModel(int order_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 order_id,total,order_info,order_state,remark from [Order] ");
			strSql.Append(" where order_id=@order_id");
			SqlParameter[] parameters = {
					new SqlParameter("@order_id", SqlDbType.Int,4)
			};
			parameters[0].Value = order_id;

			Maticsoft.Model.Order model=new Maticsoft.Model.Order();
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
		public Maticsoft.Model.Order DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Order model=new Maticsoft.Model.Order();
			if (row != null)
			{
				if(row["order_id"]!=null && row["order_id"].ToString()!="")
				{
					model.order_id=int.Parse(row["order_id"].ToString());
				}
				if(row["total"]!=null && row["total"].ToString()!="")
				{
					model.total=decimal.Parse(row["total"].ToString());
				}
				if(row["order_info"]!=null)
				{
					model.order_info=row["order_info"].ToString();
				}
				if(row["order_state"]!=null)
				{
					model.order_state=row["order_state"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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
			strSql.Append("select order_id,total,order_info,order_state,remark ");
			strSql.Append(" FROM [Order] ");
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
			strSql.Append(" order_id,total,order_info,order_state,remark ");
			strSql.Append(" FROM [Order] ");
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
			strSql.Append("select count(1) FROM [Order] ");
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
			strSql.Append(")AS Row, T.*  from [Order] T ");
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
			parameters[0].Value = "Order";
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

