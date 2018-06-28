/**  版本信息模板在安装目录下，可自行修改。
* Seller.cs
*
* 功 能： N/A
* 类 名： Seller
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
	/// 数据访问类:Seller
	/// </summary>
	public partial class Seller
	{
		public Seller()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("seller_id", "Seller"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int seller_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Seller");
			strSql.Append(" where seller_id=@seller_id");
			SqlParameter[] parameters = {
					new SqlParameter("@seller_id", SqlDbType.Int,4)
			};
			parameters[0].Value = seller_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


        public bool ExistsID(string seller_idcard)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Seller");
            strSql.Append(" where seller_idcard=@seller_idcard");
            SqlParameter[] parameters = {
					new SqlParameter("@seller_idcard",  SqlDbType.NVarChar,50)
			};
            parameters[0].Value = seller_idcard;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Seller model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Seller(");
			strSql.Append("seller_id,seller_name,seller_pwd,role_id,seller_addr,seller_phone,seller_idcard)");
			strSql.Append(" values (");
			strSql.Append("@seller_id,@seller_name,@seller_pwd,@role_id,@seller_addr,@seller_phone,@seller_idcard)");
			SqlParameter[] parameters = {
					new SqlParameter("@seller_id", SqlDbType.Int,4),
					new SqlParameter("@seller_name", SqlDbType.NVarChar,20),
					new SqlParameter("@seller_pwd", SqlDbType.NVarChar,20),
					new SqlParameter("@role_id", SqlDbType.Int,4),
					new SqlParameter("@seller_addr", SqlDbType.NVarChar,50),
					new SqlParameter("@seller_phone", SqlDbType.NVarChar,50),
					new SqlParameter("@seller_idcard", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.seller_id;
			parameters[1].Value = model.seller_name;
			parameters[2].Value = model.seller_pwd;
			parameters[3].Value = model.role_id;
			parameters[4].Value = model.seller_addr;
			parameters[5].Value = model.seller_phone;
			parameters[6].Value = model.seller_idcard;

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
		public bool Update(Maticsoft.Model.Seller model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Seller set ");
			strSql.Append("seller_name=@seller_name,");
			strSql.Append("seller_pwd=@seller_pwd,");
			strSql.Append("role_id=@role_id,");
			strSql.Append("seller_addr=@seller_addr,");
			strSql.Append("seller_phone=@seller_phone,");
			strSql.Append("seller_idcard=@seller_idcard");
			strSql.Append(" where seller_id=@seller_id");
			SqlParameter[] parameters = {
					new SqlParameter("@seller_name", SqlDbType.NVarChar,20),
					new SqlParameter("@seller_pwd", SqlDbType.NVarChar,20),
					new SqlParameter("@role_id", SqlDbType.Int,4),
					new SqlParameter("@seller_addr", SqlDbType.NVarChar,50),
					new SqlParameter("@seller_phone", SqlDbType.NVarChar,50),
					new SqlParameter("@seller_idcard", SqlDbType.NVarChar,50),
					new SqlParameter("@seller_id", SqlDbType.Int,4)};
			parameters[0].Value = model.seller_name;
			parameters[1].Value = model.seller_pwd;
			parameters[2].Value = model.role_id;
			parameters[3].Value = model.seller_addr;
			parameters[4].Value = model.seller_phone;
			parameters[5].Value = model.seller_idcard;
			parameters[6].Value = model.seller_id;

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
		public bool Delete(int seller_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Seller ");
			strSql.Append(" where seller_id=@seller_id");
			SqlParameter[] parameters = {
					new SqlParameter("@seller_id", SqlDbType.Int,4)
			};
			parameters[0].Value = seller_id;

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
		public bool DeleteList(string seller_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Seller ");
			strSql.Append(" where seller_id in ("+seller_idlist + ")  ");
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
		public Maticsoft.Model.Seller GetModel(int seller_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 seller_id,seller_name,seller_pwd,role_id,seller_addr,seller_phone,seller_idcard from Seller ");
			strSql.Append(" where seller_id=@seller_id");
			SqlParameter[] parameters = {
					new SqlParameter("@seller_id", SqlDbType.Int,4)
			};
			parameters[0].Value = seller_id;

			Maticsoft.Model.Seller model=new Maticsoft.Model.Seller();
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
		public Maticsoft.Model.Seller DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Seller model=new Maticsoft.Model.Seller();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select seller_id,seller_name,seller_pwd,role_id,seller_addr,seller_phone,seller_idcard ");
			strSql.Append(" FROM Seller ");
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
			strSql.Append(" seller_id,seller_name,seller_pwd,role_id,seller_addr,seller_phone,seller_idcard ");
			strSql.Append(" FROM Seller ");
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
			strSql.Append("select count(1) FROM Seller ");
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
				strSql.Append("order by T.seller_id desc");
			}
			strSql.Append(")AS Row, T.*  from Seller T ");
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
			parameters[0].Value = "Seller";
			parameters[1].Value = "seller_id";
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

