<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orderList.aspx.cs" Inherits="aspx_orderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <script src="../Scripts/easyui/jquery-1.8.0.min.js" type="text/javascript"></script>
        <script src="../Scripts/easyui/jquery.easyui.min.js" type="text/javascript"></script>
        <script src="../Scripts/easyui/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
        <link href="../Scripts/easyui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
        <link href="../Scripts/easyui/themes/icon.css" rel="stylesheet" type="text/css" />
          <link href="../Styles/templet.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript">
            $(function () {
                var d = new Date().getFullYear();
                $("#selYear").numberspinner("setValue", d);


                $("#dialog1").dialog('close');

                $("#tt").datagrid({
                    url: '../handler/CommonHandler.ashx?Entity=order&OPRAction=get_OrderList',
                    pagination: true,
                    pageSize: 10,
                    sortName: 'order_id',
                    sortOrder: 'desc',
                    singleSelect: true,
                    pageList: [10, 20, 30, 40],
                    singleSelect: true,

                    //fit:true,
                    columns: [[
                      { field: 'ck', checkbox: true },
                      { title: '订单编号', field: 'order_id', width: 70, align: 'center' },
                      { title: '总价', field: 'total', width: 70, align: 'center' },
                      { title: '选菜信息', field: 'order_info', width: 120, align: 'center' },
                       { title: '订单状态', field: 'order_state', width: 80, align: 'center',
                           formatter: function (value, rowData) {
                               var a = "";
                               if (value == "1")
                                   a = "已提交";
                               else if (value == "2")
                                   a = "制作中";
                               else if (value == "3")
                                   a = "配送中";
                               else if (value == "4")
                                   a = "已完成";

                               return a;
                           }

                       },

                      { title: '备注', field: 'remark', width: 130, align: 'center' }

                    ]],
                    toolbar: [{
                        text: '增加',
                        iconCls: "icon-add",
                        handler: function () {
                            top.addTab("添加食品", "order.aspx?Op=Add");

                        }
                    }, {
                        text: '修改（查看）',
                        iconCls: "icon-edit",
                        handler: function () {
                            var rows = $("#tt").datagrid('getSelections');
                            if (rows.length == 1) {
                                //  debugger;
                                top.addTab("添加项目", "order.aspx?Op=Up&id=" + rows[0]["order_id"].toString());

                            }
                            else {
                                $.messager.alert('提示', "请选择一条数据");
                            }
                        }
                    },
                    {
                        text: '删除',
                        iconCls: "icon-remove",
                        handler: function () {
                            var rows = $("#tt").datagrid('getSelections');
                            var ids = "";
                            if (rows.length != 0) {
                                //debugger
                                $.each(rows, function (index, value) {
                                    ids += "," + value.order_id + "";
                                });
                                ids = ids.substring(1);
                                $.messager.confirm("系统提示", "您确定要删除选中的数据吗", function (r) {
                                    if (r) {
                                        $.ajax({
                                            url: '../handler/CommonHandler.ashx?Entity=order&OPRAction=del_Data',
                                            type: 'post',
                                            data: { "ids": ids },
                                            dataType: "json",
                                            success: function (data) {
                                                //  debugger;
                                                //  alert(data);
                                                if (data.ErrCode == 1) {
                                                    alert(data.ErrMessage);
                                                    top.location.href = "login.aspx";
                                                }
                                                else if (data.ErrCode == 2) {
                                                    alert(data.ErrMessage);
                                                }
                                                else {
                                                    alert(data.ErrMessage);
                                                    $("#tt").datagrid('reload');
                                                }
                                            }
                                        });
                                    }
                                });
                            }
                            else {
                                $.messager.alert('提示', "请选择一条数据");
                            }
                        }
                    }
                ]
                });
            })

            function get_SearchResult() {
                // alert('ok');
                //debugger;
                var keyword = $("#order_info").val().toString();
                $("#tt").datagrid('load', { keyword: keyword });
            }




        </script>
</head>

<body>
    <div >
        <table width="100%"  class="keyword">
            <tr>
                  选菜信息：<input id="order_info" /> <a id="selButton"  onclick="get_SearchResult()"   class="easyui-linkbutton" style=" margin-left:60px;"   data-options="iconCls:'icon-search'">查询</a></td>
            </tr>
        </table>
    </div>
    <div>        
        <table id="tt"></table>
    </div>
    <form id="planFrom" runat="server">
    </form>
     <div id="dialog1"  class="easyui-dialog"  style=" padding:5px 5px 5px 15px; margin:0 auto"><img alt="二维码" id="QRCode" src="" style="margin:0 auto"  align="middle"/></div>
</body>
</html>
