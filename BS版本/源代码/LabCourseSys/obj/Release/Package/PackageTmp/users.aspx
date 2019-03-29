﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="LabCourseSys.users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../Js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../js/user.js" type="text/javascript"></script>
    <script src="../../layer/layer.js" type="text/javascript"></script>
    <link href="../styles/Common.css" rel="stylesheet" />
    <link href="../styles/Index2.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="maindiv">
            <div class="maindiv">
                <div id="daohang" style="padding: 15px">
                    <table class='fuyuntable1322'>
                        <tr>
                            <td>&nbsp;&nbsp;&nbsp;
                                <input type="button" name="B1" class="btn btn-success" value="添加用户" id="add" />
                                <input type="button" name="B1" class="btn btn-success" value="重置任务完成情况" id="reset" />
                               <%--   <input type="button" name="B1" class="btn btn-success" value="查看管理员任务情况" id="check" onclick="check()" />--%>
                               <%-- <input type="button" name="B1" class="btn btn-success" value="管理假期" id="Button1" />--%>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="contents" style="padding: 5px">
                    <div class="span12" style='padding: 8px'>
                        <table class="table table-condensed table-bordered table-hover tab">
                            <thead>
                                <tr>
                                    <th>序号</th>
                                    <th>用户名</th>
                                    <th>密码</th>
                                    <th>角色</th>
                                    <th>描述</th>
                                    <th>操作</th>
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
