﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DBOperate
    {
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="obj">实体类对象</param>
        /// <returns>sql插入语句</returns>
        static public string sqlInsert(object obj)
        {
            Type type = obj.GetType();
            System.Reflection.MethodInfo primary = type.GetMethod("primary");
            System.Reflection.MethodInfo remind = type.GetMethod("remind");
            System.Reflection.PropertyInfo[] props = null;
            try
            {
                props = obj.GetType().GetProperties();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            string sql1 = @"insert into " + type.Name + "(";
            string sql2 = @"values(";
            for (int i = 0; i < props.Length; i++)
            {
                if ((bool)remind.Invoke(obj, new string[] { props[i].Name }))
                {
                    sql1 += props[i].Name;
                    sql1 += (i == props.Length - 1) ? ")" : ",";
                    sql2 += "'" + props[i].GetValue(obj, null) + "'";
                    sql2 += (i == props.Length - 1) ? ")" : ",";

                }
                else
                {
                    if (i == props.Length - 1)
                    {
                        sql1 = sql1.TrimEnd(',');
                        sql2 = sql2.TrimEnd(',');
                        sql1 += ")";
                        sql2 += ")";
                    }
                }
            }
            return sql1 + " " + sql2;
        }

        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="obj">实体类对象</param>
        /// <returns>sql插入语句</returns>
        static public string sqlInsertAddSpara(object obj, out SqlParameter[] sqlpara)
        {

            List<SqlParameter> sqlparameter = new List<SqlParameter>();
            Type type = obj.GetType();
            System.Reflection.MethodInfo primary = type.GetMethod("primary");
            System.Reflection.MethodInfo remind = type.GetMethod("remind");
            System.Reflection.PropertyInfo[] props = null;
            try
            {
                props = obj.GetType().GetProperties();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            string sql1 = @"insert into " + type.Name + "(";
            string sql2 = @"values(";
            for (int i = 0; i < props.Length; i++)
            {
                if ((bool)remind.Invoke(obj, new string[] { props[i].Name }))
                {
                    sql1 += props[i].Name;
                    sql1 += (i == props.Length - 1) ? ")" : ",";
                    object ob = props[i].GetValue(obj, null);
                    sql2 += ob != null ? "@" + props[i].Name : "null";
                    sql2 += (i == props.Length - 1) ? ")" : ",";
                    if (ob != null)
                        sqlparameter.Add(new SqlParameter("@" + props[i].Name, ob));
                }
                else
                {
                    if (i == props.Length - 1)
                    {
                        sql1 = sql1.TrimEnd(',');
                        sql2 = sql2.TrimEnd(',');
                        sql1 += ")";
                        sql2 += ")";
                    }
                }
            }
            sqlpara = sqlparameter.ToArray();
            return sql1 + " " + sql2;
        }
        /// <summary>
        /// 更新方法（根据主键更新）
        /// </summary>
        /// <param name="obj">实体类对象</param>
        /// <returns>sql更新语句</returns>
        static public string sqlUpdtae(object obj)
        {
            Type type = obj.GetType();
            System.Reflection.MethodInfo primary = type.GetMethod("primary");
            System.Reflection.MethodInfo remind = type.GetMethod("remind");
            System.Reflection.PropertyInfo[] props = null;
            try
            {
                props = obj.GetType().GetProperties();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            string sql = @"update " + type.Name + " set ";
            for (int i = 0; i < props.Length; i++)
            {
                if ((bool)remind.Invoke(obj, new string[] { props[i].Name }))
                {
                    if (props[i].GetValue(obj, null) != null)
                    {
                        sql += props[i].Name + "=" + "'" + props[i].GetValue(obj, null) + "'";
                        sql += (i == props.Length - 1) ? " " : ",";
                    }
                }
                else
                {
                    if (i == props.Length - 1)
                    {
                        sql = sql.TrimEnd(',');
                    }
                }
            }
            sql = sql.Trim();
            if (sql[sql.Length - 1].ToString() == ",")
                sql = sql.Substring(0, sql.Length - 1);
            sql += " where ";
            for (int i = 0; i < props.Length; i++)
            {
                if (!(bool)primary.Invoke(obj, new string[] { props[i].Name }))
                {
                    if (i == 0)
                    {

                        sql += props[i].Name + "= " + "'" + props[i].GetValue(obj, null) + "'";
                    }
                    else
                    {
                        sql += "and " + props[i].Name + "= " + "'" + props[i].GetValue(obj, null) + "'";
                    }
                }
            }
            return sql;
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="obj">实体化对象</param>
        /// <returns>删除sql语句</returns>
        static public string sqlDelete(object obj)
        {
            Type type = obj.GetType();
            System.Reflection.MethodInfo primary = type.GetMethod("primary");
            System.Reflection.PropertyInfo[] props = null;
            try
            {
                props = obj.GetType().GetProperties();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            string sql = @"delete from " + type.Name;
            sql += " where ";
            for (int i = 0; i < props.Length; i++)
            {
                if (!(bool)primary.Invoke(obj, new string[] { props[i].Name }))
                {
                    if (i == 0)
                    {
                        sql += props[i].Name + "= " + "'" + props[i].GetValue(obj, null) + "'";
                    }
                    else
                    {
                        sql += "and " + props[i].Name + "= " + "'" + props[i].GetValue(obj, null) + "'";
                    }
                }
            }
            return sql;
        }
        /// <summary>
        /// 更新方法（根据主键更新）
        /// </summary>
        /// <param name="obj">实体类对象</param>
        /// <returns>sql更新语句</returns>
        static public string sqlUpdtaePara(object obj, out SqlParameter[] sqlpara)
        {
            List<SqlParameter> sqlparameter = new List<SqlParameter>();
            Type type = obj.GetType();
            System.Reflection.MethodInfo primary = type.GetMethod("primary");
            System.Reflection.MethodInfo remind = type.GetMethod("remind");
            System.Reflection.PropertyInfo[] props = null;
            try
            {
                props = obj.GetType().GetProperties();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            string sql = @"update " + type.Name + " set ";
            for (int i = 0; i < props.Length; i++)
            {
                object ob = props[i].GetValue(obj, null);
                if (ob != null)
                {
                    if (ob.ToString() != "")
                    {
                        if ((bool)remind.Invoke(obj, new string[] { props[i].Name }) && (bool)primary.Invoke(obj, new string[] { props[i].Name }))
                        {
                            sql += ob != null ? props[i].Name + "=" + "@" + props[i].Name : props[i].Name + "=null";
                            sql += (i == props.Length - 1) ? " " : ",";
                            if (ob != null)
                                sqlparameter.Add(new SqlParameter("@" + props[i].Name, ob));
                        }
                        else
                        {
                            if (i == props.Length - 1)
                            {
                                sql = sql.TrimEnd(',');
                            }
                        }
                    }
                }
            }
            if (sql[sql.Length - 1] == ',')
                sql = sql.Substring(0, sql.Length - 1);
            sql += " where ";
            for (int i = 0; i < props.Length; i++)
            {
                if (!(bool)primary.Invoke(obj, new string[] { props[i].Name }))
                {
                    if (i == 0)
                    {
                        sql += props[i].Name + "= " + "@" + props[i].Name;
                        sqlparameter.Add(new SqlParameter("@" + props[i].Name, props[i].GetValue(obj, null)));
                    }
                    else
                    {
                        sql += "and " + props[i].Name + "= " + "@" + props[i].Name;
                        sqlparameter.Add(new SqlParameter("@" + props[i].Name, props[i].GetValue(obj, null)));
                    }
                }
            }
            sqlpara = sqlparameter.ToArray();
            return sql;
        }
        /// <summary>
        /// 检索所有
        /// </summary>
        /// <param name="obj">实体类对象</param>
        /// <returns>sql检索全部语句</returns>
        static public string sqlLoadAll(object obj)
        {
            Type type = obj.GetType();
            System.Reflection.MethodInfo Note = type.GetMethod("Note");
            System.Reflection.PropertyInfo[] props = null;
            try
            {
                props = obj.GetType().GetProperties();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            string sql = @"select ";
            for (int i = 0; i < props.Length; i++)
            {
                sql += props[i].Name + " as " + Note.Invoke(obj, new string[] { props[i].Name });
                sql += (i == props.Length - 1) ? " " : ",";
            }
            sql += "from " + type.Name;
            return sql;
        }

    }
}
