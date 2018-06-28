/**  版本信息模板在安装目录下，可自行修改。
* View_Order.cs
*
* 功 能： N/A
* 类 名： View_Order
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/21 16:46:26   N/A    初版
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
	/// 数据访问类:View_Order
	/// </summary>
	public partial class View_Order
	{
		public View_Order()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.View_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into View_Order(");
			strSql.Append("seller_id,seller_name,seller_pwd,role_id,seller_addr,seller_phone,seller_idcard,order_id,total,order_info,order_state,remark)");
			strSql.Append(" values (");
			strSql.Append("@seller_id,@seller_name,@seller_pwd,@role_id,@seller_addr,@seller_phone,@seller_idcard,@order_id,@total,@order_info,@order_state,@remark)");
			SqlParameter[] parameters = {
					new SqlParameter("@seller_id", SqlDbType.Int,4),
					new SqlParameter("@seller_name", SqlDbType.NVarChar,20),
					new SqlParameter("@seller_pwd", SqlDbType.NVarChar,20),
					new SqlParameter("@role_id", SqlDbType.Int,4),
					new SqlParameter("@seller_addr", SqlDbType.NVarChar,50),
					new SqlParameter("@seller_phone", SqlDbType.NVarChar,50),
					new SqlParameter("@seller_idcard", SqlDbType.NVarChar,50),
					new SqlParameter("@order_id", SqlDbType.Int,4),
					new SqlParameter("@total", SqlDbType.Float,8),
					new SqlParameter("@order_info", SqlDbType.NVarChar,500),
					new SqlParameter("@order_state", SqlDbType.NVarChar,10),
					new SqlParameter("@remark", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.seller_id;
			parameters[1].Value = model.seller_name;
			parameters[2].Value = model.seller_pwd;
			parameters[3].Value = model.role_id;
			parameters[4].Value = model.seller_addr;
			parameters[5].Value = model.seller_phone;
			parameters[6].Value = model.seller_idcard;
			parameters[7].Value = model.order_id;
			parameters[8].Value = model.total;
			parameters[9].Value = model.order_info;
			parameters[10].Value = model.order_state;
			parameters[11].Value = model.remark;

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
		public bool Update(Maticsoft.Model.View_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update View_Order set ");
			strSql.Append("seller_id=@seller_id,");
			strSql.Append("seller_name=@seller_name,");
			strSql.Append("seller_pwd=@seller_pwd,");
			strSql.Append("role_id=@role_id,");
			strSql.Append("seller_addr=@seller_addr,");
			strSql.Append("seller_phone=@seller_phone,");
			strSql.Append("seller_idcard=@seller_idcard,");
			strSql.Append("order_id=@order_id,");
			strSql.Append("total=@total,");
			strSql.Append("order_info=@order_info,");
			strSql.Append("order_state=@order_state,");
			strSql.Append("remark=@remark");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@seller_id", SqlDbType.Int,4),
					new SqlParameter("@seller_name", SqlDbType.NVarChar,20),
					new SqlParameter("@seller_pwd", SqlDbType.NVarChar,20),
					new SqlParameter("@role_id", SqlDbType.Int,4),
					new SqlParameter("@seller_addr", SqlDbType.NVarChar,50),
					new SqlParameter("@seller_phone", SqlDbType.NVarChar,50),
					new SqlParameter("@seller_idcard", SqlDbType.NVarChar,50),
					new SqlParameter("@order_id", SqlDbType.Int,4),
					new SqlParameter("@total", SqlDbType.Float,8),
					new SqlParameter("@order_info", SqlDbType.NVarChar,500),
					new SqlParameter("@order_state", SqlDbType.NVarChar,10),
					new SqlParameter("@remark", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.seller_id;
			parameters[1].Value = model.seller_name;
			parameters[2].Value = model.seller_pwd;
			parameters[3].Value = model.role_id;
			parameters[4].Value = model.seller_addr;
			parameters[5].Value = model.seller_phone;
			parameters[6].Value = model.seller_idcard;
			parameters[7].Value = model.order_id;
			parameters[8].Value = model.total;
			parameters[9].Value = model.order_info;
			parameters[10].Value = model.order_state;
			parameters[11].Value = model.remark;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from View_Order ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		public Maticsoft.Model.View_Order GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 seller_id,seller_name,seller_pwd,role_id,seller_addr,seller_phone,seller_idcard,order_id,total,order_info,order_state,remark from View_Order ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Maticsoft.Model.View_Order model=new Maticsoft.Model.View_Order();
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
		public Maticsoft.Model.View_Order DataRowToModel(DataRow row)
		{
			Maticsoft.Model.View_Order model=new Maticsoft.Model.View_Order();
			if (row != null)
			{
				if(row["seller_id"]!=null && row["seller_id"].ToString()!="")
				{
					model.seller_id=int.Parse(row["seller_id"].ToString());
				}
				if(row["seller_name"]!=null)
				{
					model.seller_name=row["seller_name"].ToString();
				}
				if(row["seller_pwd"]!=null)
				{
					model.seller_pwd=row["seller_pwd"].ToString();
				}
				if(row["role_id"]!=null && row["role_id"].ToString()!="")
				{
					model.role_id=int.Parse(row["role_id"].ToString());
				}
				if(row["seller_addr"]!=null)
				{
					model.seller_addr=row["seller_addr"].ToString();
				}
				if(row["seller_phone"]!=null)
				{
					model.seller_phone=row["seller_phone"].ToString();
				}
				if(row["seller_idcard"]!=null)
				{
					model.seller_idcard=row["seller_idcard"].ToString();
				}
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
			strSql.Append("select seller_id,seller_name,seller_pwd,role_id,seller_addr,seller_phone,seller_idcard,order_id,total,order_info,order_state,remark ");
			strSql.Append(" FROM View_Order ");
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
			strSql.Append(" seller_id,seller_name,seller_pwd,role_id,seller_addr,seller_phone,seller_idcard,order_id,total,order_info,order_state,remark ");
			strSql.Append(" FROM View_Order ");
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
			strSql.Append("select count(1) FROM View_Order ");
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
				strSql.Append("order by T.RecordID desc");
			}
			strSql.Append(")AS Row, T.*  from View_Order T ");
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
			parameters[0].Value = "View_Order";
			parameters[1].Value = "RecordID";
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

