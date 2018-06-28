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
namespace Maticsoft.Model
{
	/// <summary>
	/// Select:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Select
	{
		public Select()
		{}
		#region Model
		private int _customer_id;
		private int _food_id;
		private int? _food_num;
		/// <summary>
		/// 
		/// </summary>
		public int customer_id
		{
			set{ _customer_id=value;}
			get{return _customer_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int food_id
		{
			set{ _food_id=value;}
			get{return _food_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? food_num
		{
			set{ _food_num=value;}
			get{return _food_num;}
		}
		#endregion Model

	}
}

