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
namespace Maticsoft.Model
{
	/// <summary>
	/// system_MaxID:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class system_MaxID
	{
		public system_MaxID()
		{}
		#region Model
		private int _recordid;
		private string _tbalename;
		private int? _maxid;
		/// <summary>
		/// 
		/// </summary>
		public int RecordID
		{
			set{ _recordid=value;}
			get{return _recordid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TbaleName
		{
			set{ _tbalename=value;}
			get{return _tbalename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MaxID
		{
			set{ _maxid=value;}
			get{return _maxid;}
		}
		#endregion Model

	}
}

