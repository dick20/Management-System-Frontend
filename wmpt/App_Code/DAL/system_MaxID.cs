/**  版本信息模板在安装目录下，可自行修改。
* system_MaxID.cs
*
* 功 能： N/A
* 类 名： system_MaxID
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/21 9:13:14   N/A    初版
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
	/// 数据访问类:system_MaxID
	/// </summary>
	public partial class system_MaxID
	{
		public system_MaxID()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("RecordID", "system_MaxID"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RecordID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from system_MaxID");
			strSql.Append(" where RecordID=@RecordID");
			SqlParameter[] parameters = {
					new SqlParameter("@RecordID", SqlDbType.Int,4)
			};
			parameters[0].Value = RecordID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.system_MaxID model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into system_MaxID(");
			strSql.Append("TbaleName,MaxID)");
			strSql.Append(" values (");
			strSql.Append("@TbaleName,@MaxID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TbaleName", SqlDbType.NVarChar,50),
					new SqlParameter("@MaxID", SqlDbType.Int,4)};
			parameters[0].Value = model.TbaleName;
			parameters[1].Value = model.MaxID;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.system_MaxID model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update system_MaxID set ");
			strSql.Append("TbaleName=@TbaleName,");
			strSql.Append("MaxID=@MaxID");
			strSql.Append(" where RecordID=@RecordID");
			SqlParameter[] parameters = {
					new SqlParameter("@TbaleName", SqlDbType.NVarChar,50),
					new SqlParameter("@MaxID", SqlDbType.Int,4),
					new SqlParameter("@RecordID", SqlDbType.Int,4)};
			parameters[0].Value = model.TbaleName;
			parameters[1].Value = model.MaxID;
			parameters[2].Value = model.RecordID;

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
		public bool Delete(int RecordID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from system_MaxID ");
			strSql.Append(" where RecordID=@RecordID");
			SqlParameter[] parameters = {
					new SqlParameter("@RecordID", SqlDbType.Int,4)
			};
			parameters[0].Value = RecordID;

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
		public bool DeleteList(string RecordIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from system_MaxID ");
			strSql.Append(" where RecordID in ("+RecordIDlist + ")  ");
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
		public Maticsoft.Model.system_MaxID GetModel(int RecordID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RecordID,TbaleName,MaxID from system_MaxID ");
			strSql.Append(" where RecordID=@RecordID");
			SqlParameter[] parameters = {
					new SqlParameter("@RecordID", SqlDbType.Int,4)
			};
			parameters[0].Value = RecordID;

			Maticsoft.Model.system_MaxID model=new Maticsoft.Model.system_MaxID();
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
		public Maticsoft.Model.system_MaxID DataRowToModel(DataRow row)
		{
			Maticsoft.Model.system_MaxID model=new Maticsoft.Model.system_MaxID();
			if (row != null)
			{
				if(row["RecordID"]!=null && row["RecordID"].ToString()!="")
				{
					model.RecordID=int.Parse(row["RecordID"].ToString());
				}
				if(row["TbaleName"]!=null)
				{
					model.TbaleName=row["TbaleName"].ToString();
				}
				if(row["MaxID"]!=null && row["MaxID"].ToString()!="")
				{
					model.MaxID=int.Parse(row["MaxID"].ToString());
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
			strSql.Append("select RecordID,TbaleName,MaxID ");
			strSql.Append(" FROM system_MaxID ");
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
			strSql.Append(" RecordID,TbaleName,MaxID ");
			strSql.Append(" FROM system_MaxID ");
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
			strSql.Append("select count(1) FROM system_MaxID ");
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
			strSql.Append(")AS Row, T.*  from system_MaxID T ");
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
			parameters[0].Value = "system_MaxID";
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

