/**  版本信息模板在安装目录下，可自行修改。
* Ordering.cs
*
* 功 能： N/A
* 类 名： Ordering
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
	/// Ordering:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Ordering
	{
		public Ordering()
		{}
		#region Model
		private int _customer_id;
		private int _order_id;
		private DateTime? _ordering_time;
		private int? _table_id;
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
		public int order_id
		{
			set{ _order_id=value;}
			get{return _order_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ordering_time
		{
			set{ _ordering_time=value;}
			get{return _ordering_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? table_id
		{
			set{ _table_id=value;}
			get{return _table_id;}
		}
		#endregion Model

	}
}

