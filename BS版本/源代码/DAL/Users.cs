using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
	/// <summary>
	/// 用户实体类
	/// </summary>
	public class Users
	{
		#region 成员

		private Int64 _id;
		private string _name;
		private string _pwd;
		private string _role;
		private string _describe;
		private string _remark1;
		private string _remark2;

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
		/// 用户名
		/// </summary>
		public string name
		{
			get { return _name; }
			set { _name = value; }
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string pwd
		{
			get { return _pwd; }
			set { _pwd = value; }
		}
		/// <summary>
		/// 角色
		/// </summary>
		public string role
		{
			get { return _role; }
			set { _role = value; }
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string describe
		{
			get { return _describe; }
			set { _describe = value; }
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
				case "name": return true;
				case "pwd": return true;
				case "role": return true;
				case "describe": return true;
				case "remark1": return true;
				case "remark2": return true;
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
				case "name": return true;
				case "pwd": return true;
				case "role": return true;
				case "describe": return true;
				case "remark1": return true;
				case "remark2": return true;
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
				case "name": return "用户名";
				case "pwd": return "密码";
				case "role": return "角色";
				case "describe": return "描述";
				case "remark1": return "备注1";
				case "remark2": return "备注2";
				 default: return null;
			}
		}

		#endregion

	}
}

