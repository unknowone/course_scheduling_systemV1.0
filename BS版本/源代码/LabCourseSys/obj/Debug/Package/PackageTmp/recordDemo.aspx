﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recordDemo.aspx.cs" Inherits="LabCourseSys.recordDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../Js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../js/recordDemo.js" type="text/javascript"></script>
    <script src="../../layer/layer.js" type="text/javascript"></script>
    <link href="../styles/Common.css" rel="stylesheet" />
    <link href="../styles/Index2.css" rel="stylesheet" />
    <script type="text/javascript">
        var course = "";
        function courseTable() {
            course = $("#labNo").val();

            sessionStorage["ttt"] = "demo";
            if (course == "所有实验室") {
                alert("请先选择实验室！");
            }
            else {
                getID();
                layer.open({
                    type: 2,
                    //skin: 'layui-layer-lan',
                    title: course + '课表',
                    fix: false,
                    shadeClose: true,
                    maxmin: true,
                    area: ['78%', '89%'],
                    content: '../../CourseTable.aspx',
                    end: function () {

                    }
                });
            }
        }
        function getID() {
            $.ajax(
          {
              type: "post",
              url: "../../webService/labInfoService.asmx/findIdByName",
              data: '{"no":"' + course + '"}',
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              async: false,
              success: function (result) {
                  sessionStorage["labID"] = result.d;
              },
              error: function (err) {

              }
          });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="maindiv">
            <div class="maindiv">
                <div id="daohang" style="padding: 0.5%">
                    <table class='fuyuntable1322'>
                        <tr style="float: left">
                            <td>课程：
                            <input type="text" name="B1" style="width: 15%" id="courses" />
                                班级：
                            <input type="text" name="B1" style="width: 15%" id="classs" />
                                教师：
                            <input type="text" name="B1" style="width: 15%" id="teacher" />
                                实验室门标：
                                  <select name="B1" id="labNo" style="width: 15%">
                                      <option value="所有实验室">所有实验室</option>
                                  </select>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="button" value="周次" name="B1" id="week" />
                                <input type="button" name="B1" value="节次" id="sec" />
                                <input type="button" name="B1" class="btn btn-success" value="检索数据" id="find" />
                                <input type="button" name="B1" class="btn btn-success" value="查看实验室课表" id="table" onclick="courseTable()" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="contents" style="padding: 0.5%">
                    <div class="span12" style='padding: 8px'>
                        <table class="table table-condensed table-bordered table-hover tab">
                            <thead>
                                <tr>
                                    <th>序号</th>
                                    <th>课程</th>
                                    <th>班级</th>
                                    <th>教师</th>
                                    <th>项目名称</th>
                                    <th>是否综合性</th>
                                    <th>周次</th>
                                    <th>星期</th>
                                    <th>节次</th>
                                    <th>人数</th>
                                    <th>组别</th>
                                    <th>实验室</th>
                                </tr>
                            </thead>
                            <tbody id="tbody"></tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
