<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="aspx_order" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
      <script src="../Scripts/easyui/jquery-1.8.0.min.js" type="text/javascript"></script>
        <script src="../Scripts/easyui/jquery.easyui.min.js" type="text/javascript"></script>
        <script src="../Scripts/easyui/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
          <script src="../Scripts/ExportExcel.js" type="text/javascript"></script>
        <link href="../Scripts/easyui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
        <link href="../Scripts/easyui/themes/icon.css" rel="stylesheet" type="text/css" />
        <link href="../Styles/templet.css" rel="stylesheet" type="text/css" />
   
       <script type="text/javascript" language="javascript">

           $(function () {
               load_data();
           })

           //加载数据

           function load_data() {
               var mOp = $("#HiddenOp").val();
               var mID = $("#HiddenID").val();

               if (mOp == "up".toUpperCase()) {
                   LoadUpData(mID);
               }
           }


           function LoadUpData(mID) {
               $.ajax({
                   url: '../handler/CommonHandler.ashx?Entity=order&OPRAction=Load_UpData',
                   data: { "id": mID },
                   type: 'post',
                   dataType: "json",

                   success: function (data) {
                       //debugger;
                       if (data.ErrCode == 1) {
                           alert(data.ErrMessage);
                           top.location.href = "login.aspx";
                       }
                       else if (data.ErrCode == 2) {
                           alert(data.ErrMessage);
                       }
                       else {
                           FillForm(data);
                       }
                   }

               })

           }


           //数据填充到表单
           function FillForm(mData) {

               var mObject = mData.rows[0];

               $("#total").val(mObject.total);
               $("#order_state").combobox('setValue', mObject.order_state);
               $("#order_info").val(mObject.order_info);
               $("#remark").val(mObject.remark);

               $("#HiddenID").val(mObject.order_id);
           }



           //动态删除表格
           function del_row(obj, n) {
               var tr = obj.parentNode;
               tr = tr.parentNode;
               var mRowID = tr.rowIndex;
               var mTab = "tab" + n;
               var mBt = "bt" + n;
               del_tabRow(mTab, mRowID, mBt);
           }


           //获取表单数据
           function GetFormData(CataID) {

               var mObject = new Object();

               mObject.total = $("#total").val();
               mObject.order_state = $("#order_state").combobox('getValue');
               mObject.order_info = $("#order_info").val();
               mObject.remark = $("#remark").val();

               return mObject;

           }


           function saveData() {

               var mObject = GetFormData();

               var mOp = $("#HiddenOp").val();

               if (mOp == "ADD") {
                   $.ajax({
                       url: '../handler/CommonHandler.ashx?Entity=order&OPRAction=add_Data',
                       dataType: "json",
                       data: { "mData": JSON.stringify(mObject) },
                       type: 'post',
                       success: function (data) {

                           if (data.ErrCode == 1) {
                               alert(data.ErrMessage);
                               top.location.href = "login.aspx";
                           }
                           else if (data.ErrCode == 2) {
                               alert(data.ErrMessage);
                           }
                           else {
                               alert(data.msg);

                               top.addTab('订单管理', 'orderList.aspx');

                           }
                       }

                   });
               }

               else if (mOp == "UP") {
                   mObject.order_id = $("#HiddenID").val();
                   $.ajax({
                       url: '../handler/CommonHandler.ashx?Entity=order&OPRAction=up_Data',
                       dataType: "json",
                       data: { "mData": JSON.stringify(mObject) },
                       type: 'post',
                       success: function (data) {

                           if (data.ErrCode == 1) {
                               alert(data.ErrMessage);
                               top.location.href = "login.aspx";
                           }
                           else if (data.ErrCode == 2) {
                               alert(data.ErrMessage);
                           }
                           else {
                               alert(data.msg);
                               top.addTab('订单管理', 'orderList.aspx');

                           }
                       }

                   });
               }

           }

           function tijiao() {

               if (checkeNull()) {
                   return;
               }
               saveData();
           }


           function checkeNull() {//检测是否为空
               var mIsNull = false;
               var mCtrName = "";

               //项目基本信息
               if ($("#total").val() == "") {
                   mCtrName = "总价";
                   $("#total").focus();
                   mIsNull = true;
               }
               else if ($("#order_info").val() == "") {
                   mCtrName = "选菜信息";
                   $("#order_info").focus();
                   mIsNull = true;
               }
               else if ($("#order_state").val() == "") {
                   mCtrName = "订单状态";
                   $("#order_state").focus();
                   mIsNull = true;
               }

               if (mIsNull) {
                   mCtrName += "不能为空！";
                   alert(mCtrName);
               }

               return mIsNull;
           }




       </script>
    <style type="text/css">
        .style1
        {
            height: 53px;
        }
    </style>
</head>
<body>
    <div align="center">
        <div class="bt">
            <label id="Label11"  style="text-align:center;font-size:14px;" ><b>
             订单信息</b> </label>
         
      </div>
 <div>
<form id="form1" runat="server">
            <table border="0" cellpadding="0" cellspacing="0"  class="baobiao" >
          
	 <tr><td  style=" background-color:#F2F2F2;color:#5889FC;font-weight:600; height:24px;">
         订单基本信息</td></tr>

		<tr>
			<td  align="left" style="height:24px;">
			    总价： <input  id="total" data-options="required:true,missingMessage:'请输入订单总价！'" class="easyui-validatebox"/>&nbsp; </td>
		</tr> 
		<tr>
		  <td>选菜信息：                
			<textarea name="textarea" rows="3"  id="order_info"  style="width: 403px" ></textarea>                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			&nbsp;</td>
		</tr>  
        <tr><td>订单状态：<select  id="order_state"
                    style="width:148px;"  class="easyui-combobox" name="D4"><option value="1">已提交</option><option value="2">制作中</option><option value="3">配送中</option><option value="4">已完成</option> </select>
                 </td></tr>
        

<tr><td align="left" style="height:24px;">备注：<input  id="remark"  data-options="required:false,missingMessage:'请输入具体要求！'"  class="easyui-validatebox"  />
</td></tr>                   
        

     <asp:HiddenField ID="HiddenOp" runat="server" Value="add" />
     <asp:HiddenField ID="HiddenID" runat="server" Value="0" />

                
</table>
   </form>
</div>
<div style="clear"></div>
 
 
        



<div class="submit" >
<button id="btn_Save"  onclick="tijiao();">提交</button>   

 </div>
   
</body>
</html>