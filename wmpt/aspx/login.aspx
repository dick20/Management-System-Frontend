<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="aspx_login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>欢迎使用小河马外卖订餐系统</title>
  <script src="../Scripts/easyui/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../Scripts/easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../Scripts/easyui/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
	<script src="../Scripts/myValidate.js"></script>
    <link href="../Scripts/easyui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/easyui/themes/icon.css" rel="stylesheet" type="text/css" />
     <link href="../Styles/login.css" rel="Stylesheet" type="text/css" />
       <script type="text/javascript">
           window.moveTo(0, 0);
           window.resizeTo(screen.availWidth, screen.availHeight);
           $(function () {
               var mbodyheight = $(document).height();
               var mbodywidth = $(document).width();

               var mleft = mbodywidth - $("#LoginPanel").panel('options').width;

               mleft = mleft / 2;
               var mtop = mbodyheight - $("#LoginPanel").panel('options').height;
               mtop = mtop / 2;

               $("#LoginPanel").panel('move', { left: mleft, top: mtop });

               $("#returnButton").click(function () {
                   $('#dd').dialog('close');
                   window.location.href = 'login.aspx';
               });

               $("#submitButton").click(function () {
     
                   if ($("#yzm2").val() == "") {
                       $.messager.alert('验证码警告', '请输入验证码！');
                       return;
                   }

                   if ($("#UserInfoForm").form('validate')) {
                       SavePass();

                   }

               }
			);



           })
           function getmore() {
               alert("请登录后查看更多通知公告！");
           }
           function login() {

               var mYear = $("#Year").val();
               var mCertification = $("#Certification").val();
               var mUserName = $("#UserName").val();
               var mPassword = $("#pwd").val();
               var myzm = $("#yzm").val();

              // if ($("#loginForm").form('validate')) {
               $.ajax({
                   type: 'post',
                   url: '../handler/loginhandler.ashx',
                   data: {Certification:mCertification,UserName:mUserName,Password:mPassword,yzm:myzm},
                   success: function (data) {
                       if (data == "1" ) {
                           window.location = '../aspx/index.aspx'; //
                       }

                       else if (data == "-1") {
                           alert("验证码错误！");
                           return false;
                       }
                       else if (data == "-2") {

                           alert("系统内部错误！");
                           return false;
                       }
                       else {
                           alert("用户名或密码错误！");
                           return false;
                       }
                   },
                   error: function (jqXHR, textStatus, errorThrown) {
                       alert(textStatus + ":" + errorThrown + ":" + jqXHR);
                       for (var p in jqXHR) {
                           alert(jqXHR[p]);
                       }
                       /*错误信息处理*/
                   }
               });
               }
          // }
       </script>
  

    <style type="text/css">
        #button
        {
            width: 40px;
        }
        input
        {
              background-color:#88adbf;
               border:none;
            
            }
        .style1
        {
            height: 143px;
        }
    </style>
</head>
<body    style="background-image:url('../images/bj1.jpg'); background-repeat:no-repeat; background-position:top">

   <div data-options="region:'center',title:''"  style="background:#eee;">
       <div id="LoginPanel" class="easyui-panel" style="width:350px; height:230px; border:0px; " title="用户登陆" data-options="iconCls:'icon-login',style:{position:'absolute',left:50,top:250}">
         <table width="100%" style="width:100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
             <td colspan=3>
                <div style=" margin-top:20px;" />
              </td>
            </tr>

            <tr >
               <td style=" text-align:right;color:#91c0ec;padding:4px; font-size:13px; color:Blue">商家身份证号：</td>
               <td colspan="2"><input id="Certification" name="Certification"   style="width:126px;border:1px solid #042a73;text-align:center;" type='text' class="easyui-validatebox"  data-options="required:true,missingMessage:'请输入身份证号'"/></td>      
            </tr>
            <tr >
               <td style=" text-align:right;color:#91c0ec;padding:4px; font-size:13px; color:Blue;">商家姓名：</td>
               <td colspan="2"><input id="UserName" name="UserName"  style="width:106px;border:1px solid #042a73;text-align:center;" type='text' class="easyui-validatebox"  data-options="required:true,missingMessage:'请输入用户名'"/></td>      
            </tr>
            <tr style=" padding:2px;">
               <td style=" text-align:right;color:#91c0ec;padding:4px; font-size:13px; color:Blue"> 商家密码：</td>
               <td colspan="2"><input style="width:106px; border:1px solid #042a73;text-align:center;" type="password" name="pwd"  id="pwd" class="easyui-validatebox"    data-options="required:true,missingMessage:'请输入密码'"/></td>                
            </tr>
             <tr style=" padding:2px;"><td style=" text-align:right;color:#91c0ec;padding:4px; font-size:13px; color:Blue">验证码：</td><td><input style="width:45px;border:1px solid #042a73; text-align:center;" type='text'  name="yzm"  id="yzm"   class="easyui-validatebox"  data-options="required:false"/>  
                    <asp:Image ID="CodeImg" src="ChekCode.aspx"  onclick="document.getElementById('CodeImg').src='ChekCode.aspx?tmp='+Math.random()" runat="server"  ImageUrl="ChekCode.aspx" />
                </td>                   
             </tr>
             <tr>
               <td style="text-align: center">
                        <a id="A5" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-ok'" onclick="javascript:login();">登陆</a>
   
               </td>

               <td style="text-align: center">
                       <a id="A1" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-help'" onclick="window.open('../help.htm')">帮助</a>
            
               </td>

               <td style="text-align: center">
                       <a id="A2" href="UserRegister.aspx" class="easyui-linkbutton" data-options="iconCls:'icon-reload'" >注册</a>
               
               </td>
             </tr>
         </table>
      </div>
  
    </div>

</body>

</html>
