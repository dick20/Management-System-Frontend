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
namespace Maticsoft.Model
{
	/// <summary>
	/// Menu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Menu
	{
		public Menu()
		{}
		#region Model
		private int _food_id;
		private string _food_name;
		private string _food_type;
		private decimal? _food_price;
		private string _food_desc;
		private string _food_img;
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
		public string food_name
		{
			set{ _food_name=value;}
			get{return _food_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string food_type
		{
			set{ _food_type=value;}
			get{return _food_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? food_price
		{
			set{ _food_price=value;}
			get{return _food_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string food_desc
		{
			set{ _food_desc=value;}
			get{return _food_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string food_img
		{
			set{ _food_img=value;}
			get{return _food_img;}
		}
		#endregion Model

	}
}

