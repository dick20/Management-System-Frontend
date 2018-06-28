<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userList.aspx.cs" Inherits="aspx_userList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <script src="../Scripts/easyui/jquery-1.8.0.min.js" type="text/javascript"></script>
        <script src="../Scripts/easyui/jquery.easyui.min.js" type="text/javascript"></script>
        <script src="../Scripts/easyui/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
        <link href="../Scripts/easyui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
        <link href="../Scripts/easyui/themes/icon.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            input{width:130px;}
        </style>
        <script type="text/javascript">
            $(function () {
                $.extend($.fn.validatebox.defaults.rules, {
                    /*必须和某个字段相等*/
                    equalTo: {
                        validator: function (value, param) {
                            return $(param[0]).val() == value;
                        },
                        message: '字段不匹配'
                    }

                }); //扩展属性
                $("#edit").dialog('close');
                $("#tt").datagrid({
                    url: '../handler/CommonHandler.ashx?Entity=User&OPRAction=getUserList',
                    sortName: 'seller_id',
                    sortOrder: 'desc',
                    remoteSort: false,
                    idField: 'seller_id',
                    singleSelect: true,
                    columns: [[
                    { field: 'ck', checkbox: true },
                    { title: '商家ID', field: 'seller_id', width: 100, align: 'center', sortable: true,
                      sorter:function(a,b){  
                         var number1 = parseFloat(a);  
                         var number2 = parseFloat(b);  
                         return (number1 > number2 ? 1 : -1);   
                                         } 
                     },
                    { title: '商家名称', field: 'seller_name', width: 100, align: 'center', sortable: true },
  //                  { title: '商家角色', field: 'role_id', width: 100, align: 'center' },
                    { title: '商家地址', field: 'seller_addr', width: 100, align: 'center' },
                    { title: '商家电话', field: 'seller_phone', width: 100, align: 'center' },
                    { title: '身份证号', field: 'seller_idcard', width: 100, align: 'center' }
                    ]],
                    pagination: true,
                    pageSize: 10,
                    pageList: [10, 20, 30, 40],
                    toolbar: [{
                        text: "增加",
                        iconCls: "icon-add",
                        handler: function () { add(); }
                    }, {
                        text: "修改",
                        iconCls: "icon-edit",
                        handler: function () { update(); }

                    }, { text: "删除",
                        iconCls: "icon-remove",
                        handler: function () { del(); }
                    }]
                });
            });

           

            function add() {
                $("#ctype").form('clear');
                $("#edit").dialog({
                    title: "增加用户",
                    modal: true,
                    buttons: [{ text: '增加', handler: adduser}]
                });
            }


            function adduser() {
                var data = $("#ctype").serialize();

                if ($("#ctype").form('validate')) {
                    $.ajax({
                        url: '../handler/CommonHandler.ashx?Entity=user&OPRAction=add',
                        type: 'post',
                        data: data,
                        success: function (r) {
                            r = eval("(" + r + ")");
                            if (r.ErrCode == 1) {
                                alert(r.ErrMessage);
                                top.location.href = "/login.aspx";
                            }
                            else if (r.ErrCode == 2) {
                                alert(r.ErrMessage);
                            }
                            else {
                                alert(r.msg);
                                $("#edit").dialog('close');
                                $("#tt").datagrid('reload');
                            }
                        }
                    });
                }
            }
            function update() {

                var row = $("#tt").datagrid('getSelections');
                if (row.length != 1) {
                    $.messager.alert('提示', "请选择要修改的用户!");
                }
                else {
                    var rowid = row[0].seller_id;
                    $("#ctype").form('clear');
                    $("#edit").dialog({
                        title: "修改用户",
                        modal: true,
                        buttons: [{ text: '修改', handler: function () {
                            update_user(rowid);
                        }
                        }]
                    });

                    $.ajax({
                        url: '../handler/CommonHandler.ashx?Entity=user&OPRAction=getuserModel',
                        data: { 'id': rowid },
                        type: 'post',
                        success: function (r) {
                            r = eval("(" + r + ")");
                            if (r.ErrCode == 1) {
                                alert(r.ErrMessage);
                                top.location.href = "/login.aspx";
                            }
                            else if (r.ErrCode == 2) {
                                alert(r.ErrMessage);
                            }
                            else {
                                //  debugger
                                r.json = eval("(" + r.json + ")");
                                $("#ctype").form('load', r.json);
                                var pwd = $("#seller_pwd").val();
                                $("#pwd2").val(pwd);
                            }
                        }
                    })
                }


            }
            function update_user(id) {
                var data = $("#ctype").serialize();
                data += "&seller_id=" + id;
                $.ajax({
                    url: '../handler/CommonHandler.ashx?Entity=User&OPRAction=up',
                    type: 'post',
                    data: data,
                    success: function (r) {
                        r = eval("(" + r + ")");
                        if (r.ErrCode == 1) {
                            alert(r.ErrMessage);
                            top.location.href = "/login.aspx";
                        }
                        else if (r.ErrCode == 2) {
                            alert(r.ErrMessage);
                        }
                        else {
                            alert(r.msg);
                            $("#edit").dialog('close');
                            $("#tt").datagrid('reload');
                        }
                    }
                });
            }


            function del() {
                var rows = $("#tt").datagrid("getSelections");
                var ids = "";
                if (rows.length != 0) {
                    $.each(rows, function (index, value) {
                        ids += ",'" + value.seller_id + "'";
                    });
                    ids = ids.substring(1);
                    $.messager.confirm("系统提示", "您确定要删除选中的用户吗?", function (r) {
                        if (r) {
                            $.ajax({
                                url: '../handler/CommonHandler.ashx?Entity=user&OPRAction=del',
                                data: { "ids": ids },
                                type: 'post',
                                success: function (r) {
                                    r = eval("(" + r + ")");
                                    if (r.ErrCode == 1) {
                                        alert(r.ErrMessage);
                                        top.location.href = "/login.aspx";
                                    }
                                    else if (r.ErrCode == 2) {
                                        alert(r.ErrMessage);
                                    }
                                    else {
                                        alert(r.msg);
                                        $("#tt").datagrid("reload");
                                    }
                                }
                            });
                        }
                    });
                }
                else {
                    $.messager.alert("系统提示", "请先选择您要删除的用户!");
                }

            }
        </script>
</head>
<body>
    <div>
        <table id="tt"></table>
    </div>
    <div id="edit" class="easyui-dialog"> 
    <form id="ctype" runat="server">
    <table style="font-size:12px;">
    <tr>
            <td>姓名:	</td>
            <td><input id="seller_name" name="seller_name" class="easyui-validatebox" data-options="required:true,missingMessage:'请输入姓名'"/></td>
            <td nowrap>地址：</td>
            <td><input id="seller_addr" name="seller_addr" class="easyui-validatebox" data-options="required:true,missingMessage:'请输入地址'"/></td>
      </tr>
	  <tr>
            <td nowrap>身份证号：</td>
            <td><input id="seller_idcard" name="seller_idcard" class="easyui-validatebox" data-options="required:true,missingMessage:'请输入身份证号'"/></td>
            <td>手机号：</td>
            <td><input id="seller_phone" name="seller_phone"   class="easyui-validatebox" data-options="required:true,missingMessage:'请输入手机号码'" /></td>
        </tr>
	  
      <tr>
            <td nowrap>密码：</td>
            <td  > <input id="seller_pwd" name="seller_pwd" validType="length[6,12]" class="easyui-validatebox"   type="password"   data-options="required:true" /></td>
           <td nowrap>确认密码：</td>
            <td><input type="password" name="PassWord1"   id="pwd2"   required="true" class="easyui-validatebox" type="password"  validType="equalTo['#seller_pwd']" invalidMessage="两次输入密码不匹配"/></td>
        </tr>
       
    </table>
    </form>
    </div>
</body>
</html>
