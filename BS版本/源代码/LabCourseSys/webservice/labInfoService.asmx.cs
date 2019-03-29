﻿using BLL;
using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LabCourseSys.webservice
{
    /// <summary>
    /// labInfoService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class labInfoService : System.Web.Services.WebService
    {
        BLL_labInfo l = new BLL_labInfo();
        LabInfo ll = new LabInfo();
        [WebMethod]
        public string ReLabNo(string no)
        {
            if (l.ReLabNo(no))
                return "重复";
            else
                return "不重复";
        }
        [WebMethod]
        public string findIdByName(string no)
        {
            return l.findIdByName(no);
        }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string findAll()
        {
            DataTable dt = l.findAll();
            DataTable dd = new DataTable();
            dd.Columns.Add("实验室名称");
            dd.Columns.Add("容纳人数");

            dd.Columns.Add("简介");
            dd.Columns.Add("管理员");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow r = dd.NewRow();
                r[0] = dt.Rows[i][1].ToString();
                r[1] = dt.Rows[i][2].ToString();
                r[2] = dt.Rows[i][3].ToString();
                r[3] = dt.Rows[i][4].ToString();
                dd.Rows.Add(r.ItemArray);
            }
            //npoiClass n = new npoiClass();
            //string url = Server.MapPath("~//file//实验室.xls");
            //n.ExportToExcel(dd, "实验室", url);
            return JsonCast.DataTableToJSON(dt, false).ToString();

        }
        [WebMethod]
        public string delete(string id)
        {
            l.delete(id);
            return "";
        }
        [WebMethod]
        public string update(string labName, string id, string name, string count, string des, string user)
        {
            ll.remark2 = labName;
            ll.remark3 = user;
            ll.count = count;
            ll.describe = des;
            ll.name = name;
            ll.id = int.Parse(id);
            l.update(ll);
            return "";
        }
        [WebMethod]
        public string insert(string labName, string name, string count, string des, string user)
        {
            ll.remark2 = labName;
            ll.remark3 = user;
            ll.count = count;
            ll.describe = des;
            ll.name = name;
            ll.remark1 = "1";
            l.insert(ll);
            return "";
        }
        [WebMethod]
        public string getOne(string id)
        {
            string ss = l.getOne(id);
            return ss;
        }
        [WebMethod]
        public string state(string id)
        {
            l.state(id);
            return "";
        }
    }
}
