<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shenbao.aspx.cs" Inherits="aspx_shenbao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                url: '../handler/CommonHandler.ashx?Entity=menu&OPRAction=Load_UpData',
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

            $("#food_name").val(mObject.food_name);
            $("#food_type").combobox('setValue', mObject.food_type);
            $("#food_price").val(mObject.food_price);
            $("#food_desc").val(mObject.food_desc);
            $("#img").attr('src', mObject.food_img);

            $("#food_img").val(mObject.food_img);
            $("#HiddenID").val(mObject.food_id);                     
        }



          //动态删除表格
          function del_row(obj,n) {
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

          mObject.food_name = $("#food_name").val();
          mObject.food_type = $("#food_type").combobox('getValue');
          mObject.food_price = $("#food_price").val();          
          mObject.food_desc = $("#food_desc").val();
          mObject.food_img = $("#food_img").val();

          return mObject;
      
      }
      
   
       function saveData() {

          var mObject = GetFormData();

          var mOp=$("#HiddenOp").val();

          if (mOp == "ADD") {
              $.ajax({
                  url: '../handler/CommonHandler.ashx?Entity=menu&OPRAction=add_Data',
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

                          top.addTab('菜品管理', 'menuList.aspx');

                      }
                  }

              });
          }

          else if (mOp == "UP") {
              mObject.food_id = $("#HiddenID").val();
              $.ajax({
                  url: '../handler/CommonHandler.ashx?Entity=menu&OPRAction=up_Data',
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
                          top.addTab('菜品管理', 'menuList.aspx');

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
          if ($("#food_name").val() == "") {
              mCtrName = "食品名称";
              $("#food_name").focus();
              mIsNull = true;
          }
          else if ($("#food_type").val() == "") {
              mCtrName = "食品类型";
              $("#food_type").focus();
              mIsNull = true;
          }
          else if ($("#food_price").val() == "") {
              mCtrName = "食品价格";
              $("#food_price").focus();
              mIsNull = true;
          }
          else if ($("#food_desc").val() == "") {
              mCtrName = "食品描述";
              $("#food_desc").focus();
              mIsNull = true;
          }

          if (mIsNull) {
              mCtrName += "不能为空！";
              alert(mCtrName);
          }
              
          return mIsNull;
      }


      function chgImg(file) {
          //img控件预览图片
          var FileUpload = $("#FileUpload").val();
          $("#img").attr("src", "file:///" + FileUpload);
          //div预览图片（兼容模式）
          var prevDiv = document.getElementById('preview');
          if (file.files && file.files[0]) {
              var reader = new FileReader();
              reader.onload = function (evt) {
                  prevDiv.innerHTML = '<img src="' + evt.target.result + '" style="max-height:80px" />';
              }
              reader.readAsDataURL(file.files[0]);
          }
          else {
              prevDiv.innerHTML = '<div class="img" style="max-height:80px;filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale,src=\'' + file.value + '\')"></div>';
          }
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
             食品信息</b> </label>
         
      </div>
 <div>
<form id="form1" runat="server">
            <table border="0" cellpadding="0" cellspacing="0"  class="baobiao" >
          
	 <tr><td  style=" background-color:#F2F2F2;color:#5889FC;font-weight:600; height:24px;">
         食品基本信息</td></tr>

            <tr>
	            <td  align="left" style="height:24px;">
		            食品图片： <!--<input  id="food_img" data-options="prompt:'请选择食品名称图片！'" class="easyui-filebox"/>&nbsp; -->
                    
                    <asp:FileUpload ID="FileUpload" runat="server" onchange="chgImg(this)" />  &nbsp;&nbsp;
                    <asp:Button ID="BtnUp" runat="server" onclick="BtnUp_Click" Text="上 传" />
                </td>
            </tr> 

		<tr>
			<td  align="left" style="height:24px;">
			    食品名称： <input  id="food_name" data-options="required:true,missingMessage:'请输入食品名称！'" class="easyui-validatebox"/>&nbsp; </td>
		</tr> 
        <tr><td>食品类型：<select  id="food_type"
                    style="width:148px;"  class="easyui-combobox" name="D4"><option value="1">炒菜</option><option value="2">稀饭</option><option value="3">火锅</option><option value="4">甜点</option><option value="5">酒水</option> </select>
                 </td></tr>
        

<tr><td align="left" style="height:24px;">食品价格：<input  id="food_price"  data-options="required:true,missingMessage:'请输入食品价格！'"  class="easyui-validatebox"  />（元） 
</td></tr>                   
        
            <tr>
              <td>食品描述：                
                <textarea name="textarea" rows="3"  id="food_desc"  style="width: 403px" ></textarea>                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;</td>
            </tr>  

            <tr>
                <td>
<%--                    <asp:Label ID="LabMsg" runat="server"></asp:Label><br />--%>
                    <img id="img"  width="300"  height="200" src="" runat="server" />
                    <div id="preview"></div>
                </td>
            </tr> 


     <asp:HiddenField ID="HiddenOp" runat="server" Value="add" />
     <asp:HiddenField ID="HiddenID" runat="server" Value="0" />
     <asp:HiddenField ID="food_img" runat="server" Value="" />
                
</table>
   </form>
</div>
<div style="clear"></div>
 
 
        



<div class="submit" >
<button id="btn_Save"  onclick="tijiao();">提交</button>   

 </div>
   
</body>
</html>
