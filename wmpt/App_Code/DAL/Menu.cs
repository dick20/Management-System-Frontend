/**  版本信息模板在安装目录下，可自行修改。
* Menu.cs
*
* 功 能： N/A
* 类 名： Menu
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
	/// 数据访问类:Menu
	/// </summary>
	public partial class Menu
	{
		public Menu()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("food_id", "Menu"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int food_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Menu");
			strSql.Append(" where food_id=@food_id");
			SqlParameter[] parameters = {
					new SqlParameter("@food_id", SqlDbType.Int,4)
			};
			parameters[0].Value = food_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Menu(");
			strSql.Append("food_id,food_name,food_type,food_price,food_desc,food_img)");
			strSql.Append(" values (");
			strSql.Append("@food_id,@food_name,@food_type,@food_price,@food_desc,@food_img)");
			SqlParameter[] parameters = {
					new SqlParameter("@food_id", SqlDbType.Int,4),
					new SqlParameter("@food_name", SqlDbType.NVarChar,20),
					new SqlParameter("@food_type", SqlDbType.NVarChar,20),
					new SqlParameter("@food_price", SqlDbType.Float,8),
					new SqlParameter("@food_desc", SqlDbType.NVarChar,100),
					new SqlParameter("@food_img", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.food_id;
			parameters[1].Value = model.food_name;
			parameters[2].Value = model.food_type;
			parameters[3].Value = model.food_price;
			parameters[4].Value = model.food_desc;
			parameters[5].Value = model.food_img;

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
		public bool Update(Maticsoft.Model.Menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Menu set ");
			strSql.Append("food_name=@food_name,");
			strSql.Append("food_type=@food_type,");
			strSql.Append("food_price=@food_price,");
			strSql.Append("food_desc=@food_desc,");
			strSql.Append("food_img=@food_img");
			strSql.Append(" where food_id=@food_id");
			SqlParameter[] parameters = {
					new SqlParameter("@food_name", SqlDbType.NVarChar,20),
					new SqlParameter("@food_type", SqlDbType.NVarChar,20),
					new SqlParameter("@food_price", SqlDbType.Float,8),
					new SqlParameter("@food_desc", SqlDbType.NVarChar,100),
					new SqlParameter("@food_img", SqlDbType.NVarChar,100),
					new SqlParameter("@food_id", SqlDbType.Int,4)};
			parameters[0].Value = model.food_name;
			parameters[1].Value = model.food_type;
			parameters[2].Value = model.food_price;
			parameters[3].Value = model.food_desc;
			parameters[4].Value = model.food_img;
			parameters[5].Value = model.food_id;

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
		public bool Delete(int food_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Menu ");
			strSql.Append(" where food_id=@food_id");
			SqlParameter[] parameters = {
					new SqlParameter("@food_id", SqlDbType.Int,4)
			};
			parameters[0].Value = food_id;

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
		public bool DeleteList(string food_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Menu ");
			strSql.Append(" where food_id in ("+food_idlist + ")  ");
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
		public Maticsoft.Model.Menu GetModel(int food_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 food_id,food_name,food_type,food_price,food_desc,food_img from Menu ");
			strSql.Append(" where food_id=@food_id");
			SqlParameter[] parameters = {
					new SqlParameter("@food_id", SqlDbType.Int,4)
			};
			parameters[0].Value = food_id;

			Maticsoft.Model.Menu model=new Maticsoft.Model.Menu();
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
		public Maticsoft.Model.Menu DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Menu model=new Maticsoft.Model.Menu();
			if (row != null)
			{
				if(row["food_id"]!=null && row["food_id"].ToString()!="")
				{
					model.food_id=int.Parse(row["food_id"].ToString());
				}
				if(row["food_name"]!=null)
				{
					model.food_name=row["food_name"].ToString();
				}
				if(row["food_type"]!=null)
				{
					model.food_type=row["food_type"].ToString();
				}
				if(row["food_price"]!=null && row["food_price"].ToString()!="")
				{
					model.food_price=decimal.Parse(row["food_price"].ToString());
				}
				if(row["food_desc"]!=null)
				{
					model.food_desc=row["food_desc"].ToString();
				}
				if(row["food_img"]!=null)
				{
					model.food_img=row["food_img"].ToString();
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
			strSql.Append("select food_id,food_name,food_type,food_price,food_desc,food_img ");
			strSql.Append(" FROM Menu ");
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
			strSql.Append(" food_id,food_name,food_type,food_price,food_desc,food_img ");
			strSql.Append(" FROM Menu ");
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
			strSql.Append("select count(1) FROM Menu ");
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
			strSql.Append(")AS Row, T.*  from Menu T ");
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
			parameters[0].Value = "Menu";
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

