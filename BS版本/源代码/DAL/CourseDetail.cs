using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
	/// <summary>
	/// 实验课明细实体类
	/// </summary>
	public class CourseDetail
	{
		#region 成员

		private Int64 _id;
		private string _project;
		private string _isComprehensive;
		private string _week;
		private string _remark1;
		private string _remark2;
		private string _remark3;
		private string _remark4;

		#endregion

		#region 属性

		/// <summary>
		/// 主键
		/// </summary>
		public Int64 id
		{
			get { return _id; }
			set { _id = value; }
		}
		/// <summary>
		/// 项目名称
		/// </summary>
		public string project
		{
			get { return _project; }
			set { _project = value; }
		}
		/// <summary>
		/// 是否综合性
		/// </summary>
		public string isComprehensive
		{
			get { return _isComprehensive; }
			set { _isComprehensive = value; }
		}
		/// <summary>
		/// 周次
		/// </summary>
		public string week
		{
			get { return _week; }
			set { _week = value; }
		}
		/// <summary>
		/// 备注1
		/// </summary>
		public string remark1
		{
			get { return _remark1; }
			set { _remark1 = value; }
		}
		/// <summary>
		/// 备注2
		/// </summary>
		public string remark2
		{
			get { return _remark2; }
			set { _remark2 = value; }
		}
		/// <summary>
		/// 备注3
		/// </summary>
		public string remark3
		{
			get { return _remark3; }
			set { _remark3 = value; }
		}
		/// <summary>
		/// 备注4
		/// </summary>
		public string remark4
		{
			get { return _remark4; }
			set { _remark4 = value; }
		}

		#endregion

		#region 方法

		/// <summary>
		/// 判断实体（表）主键，如果是主键返回 false,否则返回true
		 /// </summary>
		/// <param name=AttributeName>属性名</param>
		 /// <returns></returns>
		static public bool primary(string AttributeName)
		{
			switch (AttributeName)
			{
				case "id": return false;
				case "project": return true;
				case "isComprehensive": return true;
				case "week": return true;
				case "remark1": return true;
				case "remark2": return true;
				case "remark3": return true;
				case "remark4": return true;
				 default: return true;
			}
		}
		/// <summary>
		/// 判断实体（表）字段是否自增，如果是自增返回 false,否则返回true
		 /// </summary>
		/// <param name=AttributeName>属性名</param>
		 /// <returns></returns>
		static public bool remind(string AttributeName)
		{
			switch (AttributeName)
			{
				case "id": return false;
				case "project": return true;
				case "isComprehensive": return true;
				case "week": return true;
				case "remark1": return true;
				case "remark2": return true;
				case "remark3": return true;
				case "remark4": return true;
				 default: return true;
			}
		}
		/// <summary>
		///返回每个字段的的注释
		 /// </summary>
		/// <param name=AttributeName>属性名</param>
		 /// <returns></returns>
		static public string Note(string AttributeName)
		{
			switch (AttributeName)
			{
				case "id": return "主键";
				case "project": return "项目名称";
				case "isComprehensive": return "是否综合性";
				case "week": return "周次";
				case "remark1": return "备注1";
				case "remark2": return "备注2";
				case "remark3": return "备注3";
				case "remark4": return "备注4";
				 default: return null;
			}
		}

		#endregion

	}
}

