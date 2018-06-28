/**  版本信息模板在安装目录下，可自行修改。
* Select.cs
*
* 功 能： N/A
* 类 名： Select
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/20 20:48:53   N/A    初版
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
	/// 数据访问类:Select
	/// </summary>
	public partial class Select
	{
		public Select()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("customer_id", "Select"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int customer_id,int food_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Select");
			strSql.Append(" where customer_id=@customer_id and food_id=@food_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@customer_id", SqlDbType.Int,4),
					new SqlParameter("@food_id", SqlDbType.Int,4)			};
			parameters[0].Value = customer_id;
			parameters[1].Value = food_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Select model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Select(");
			strSql.Append("customer_id,food_id,food_num)");
			strSql.Append(" values (");
			strSql.Append("@customer_id,@food_id,@food_num)");
			SqlParameter[] parameters = {
					new SqlParameter("@customer_id", SqlDbType.Int,4),
					new SqlParameter("@food_id", SqlDbType.Int,4),
					new SqlParameter("@food_num", SqlDbType.Int,4)};
			parameters[0].Value = model.customer_id;
			parameters[1].Value = model.food_id;
			parameters[2].Value = model.food_num;

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
		public bool Update(Maticsoft.Model.Select model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Select set ");
			strSql.Append("food_num=@food_num");
			strSql.Append(" where customer_id=@customer_id and food_id=@food_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@food_num", SqlDbType.Int,4),
					new SqlParameter("@customer_id", SqlDbType.Int,4),
					new SqlParameter("@food_id", SqlDbType.Int,4)};
			parameters[0].Value = model.food_num;
			parameters[1].Value = model.customer_id;
			parameters[2].Value = model.food_id;

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
		public bool Delete(int customer_id,int food_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Select ");
			strSql.Append(" where customer_id=@customer_id and food_id=@food_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@customer_id", SqlDbType.Int,4),
					new SqlParameter("@food_id", SqlDbType.Int,4)			};
			parameters[0].Value = customer_id;
			parameters[1].Value = food_id;

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
		public Maticsoft.Model.Select GetModel(int customer_id,int food_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 customer_id,food_id,food_num from Select ");
			strSql.Append(" where customer_id=@customer_id and food_id=@food_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@customer_id", SqlDbType.Int,4),
					new SqlParameter("@food_id", SqlDbType.Int,4)			};
			parameters[0].Value = customer_id;
			parameters[1].Value = food_id;

			Maticsoft.Model.Select model=new Maticsoft.Model.Select();
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
		public Maticsoft.Model.Select DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Select model=new Maticsoft.Model.Select();
			if (row != null)
			{
				if(row["customer_id"]!=null && row["customer_id"].ToString()!="")
				{
					model.customer_id=int.Parse(row["customer_id"].ToString());
				}
				if(row["food_id"]!=null && row["food_id"].ToString()!="")
				{
					model.food_id=int.Parse(row["food_id"].ToString());
				}
				if(row["food_num"]!=null && row["food_num"].ToString()!="")
				{
					model.food_num=int.Parse(row["food_num"].ToString());
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
			strSql.Append("select customer_id,food_id,food_num ");
			strSql.Append(" FROM Select ");
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
			strSql.Append(" customer_id,food_id,food_num ");
			strSql.Append(" FROM Select ");
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
			strSql.Append("select count(1) FROM Select ");
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
				strSql.Append("order by T.food_id desc");
			}
			strSql.Append(")AS Row, T.*  from Select T ");
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
			parameters[0].Value = "Select";
			parameters[1].Value = "food_id";
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

