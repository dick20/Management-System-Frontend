/**  版本信息模板在安装目录下，可自行修改。
* View_Menu.cs
*
* 功 能： N/A
* 类 名： View_Menu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/21 16:46:25   N/A    初版
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
	/// View_Menu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class View_Menu
	{
		public View_Menu()
		{}
		#region Model
		private int _seller_id;
		private string _seller_name;
		private string _seller_pwd;
		private int? _role_id;
		private string _seller_addr;
		private string _seller_phone;
		private string _seller_idcard;
		private int _food_id;
		private string _food_name;
		private string _food_type;
		private decimal? _food_price;
		private string _food_desc;
		private string _food_img;
		/// <summary>
		/// 
		/// </summary>
		public int seller_id
		{
			set{ _seller_id=value;}
			get{return _seller_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string seller_name
		{
			set{ _seller_name=value;}
			get{return _seller_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string seller_pwd
		{
			set{ _seller_pwd=value;}
			get{return _seller_pwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? role_id
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string seller_addr
		{
			set{ _seller_addr=value;}
			get{return _seller_addr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string seller_phone
		{
			set{ _seller_phone=value;}
			get{return _seller_phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string seller_idcard
		{
			set{ _seller_idcard=value;}
			get{return _seller_idcard;}
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

