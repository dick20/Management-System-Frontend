<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegister.aspx.cs" Inherits="aspx_UserRegister" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>商家注册</title>
    <script src="../Scripts/easyui/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../Scripts/easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../Scripts/easyui/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
	<script src="../Scripts/myValidate.js"></script>
    <link href="../Scripts/easyui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/easyui/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/login.css" rel="Stylesheet" type="text/css" />
 </head>
<body>       
    <script type="text/javascript">
        $(function () {
            $("#returnButton").click(function () {
                //                      window.location.href = 'login.aspx';
                //                    $('#RegisterDV').dialog('close');
            });

            $("#submitButton").click(function () {
                if ($("#yzm2").val() == "") {
                    $.messager.alert('验证码警告', '请输入验证码！');
                    return;
                }
 

                if ($("#UserInfoForm").form('validate')) {
                   
                    var mUserName = $("#RUserName").val();
                    var mNPass = $("#NPaswword").val(); 
                    var mSPass = $("#Paswword").val();
                    mNPass = $.trim(mNPass);
                    mSPass = $.trim(mSPass);
                    var mCardID = $("#RCertification").val();             
                    var mPhone = $("#Phone").val();
                    var mAddress = $("#Address").val();
                    var mEmployUnit = $("#EmployUnit").val();
                    var myzm = $("#yzm2").val();



                    //------------保存到后台数据库--------//
                    $.ajax({
                        url: '../handler/Registerhandler.ashx?',
                        dataType: 'json',
                        type: 'Post',
                        data: { UserName: mUserName, CardID: mCardID, PassWord: mNPass, Phone: mPhone,  Address: mAddress, yzm2: myzm},

                        success: function (data) {
                            
                            //data = eval("(" + data + ")");
                            //alert(data.ErrCode);
                            if (data.ErrCode == 0) {
                                alert("注册成功！返回登录页面！");
                                window.location.href = 'login.aspx';

                            }
                            else {
                                //alert(data.ErrMessage);
                                $.messager.alert('错误信息提示', data.ErrMessage);
                                return false;
                            }
                        }
                    });



                }
            });
        });
    </script>

 <form id="UserInfoForm" runat="server"> 
    
<table width="80%" class="admintable"   border="0" align="center" style="margin-left:100px; margin-top:50px;">
	  <caption class="admincap">
		商家注册
	  </caption>
	<tr>
		<th height="50" colspan="4" class="adminth" style="padding-left: 20px; text-align: left">
			商家信息填写<span id="tip" style="margin-left: 20px; color: red"> </span>                </th>
	</tr>
 
  <tr>
    <th class="adminth">
	    姓名:	</th>
    <td  class="admincls0">
	    <input class="easyui-validatebox" id="RUserName" name="RUserName" data-options="required:true,missingMessage:'请输入姓名',validType:{length:[2,20]}"  maxlength=20 style="width:140px;"/><font color="red">*</font>	</td>
      <th class="adminth">
	    地址:	</th>
    <td  class="admincls0">
        	<input class="easyui-validatebox" id="Address" name="Address" data-options="required:true,missingMessage:'请输入具体位置'"   style="width:140px;"/><font color="red">*</font>	</td>
  </tr>
  <tr>
    <th class="adminth">
	    身份证号:
	</th>
    <td class="admincls0">
	    <input class="easyui-validatebox" id="RCertification" name="RCertifycation" validtype="idcard" data-options="required:true,missingMessage:'请输入18位身份证号'"  maxlength=18 style="width:140px;"/><font color="red">*</font>	</td>
    <th class="adminth">
	    手机号:
	</th>
    <td class="admincls0">
	    <input class="easyui-validatebox" id="Phone" name="Gender" data-options="required:true,missingMessage:'请输入手机号'"  validtype="mobile" maxlength=13 style="width:140px;"/><font color="red">*</font>	</td>
  </tr>
  <tr>
    <th class="adminth">
	    密码:
	</th>
    <td class="admincls0">
	    <input class="easyui-validatebox" id="Paswword" name="Paswword" type="password" data-options="required:true,missingMessage:'请输入新密码'" validtype="length[6,32]"  maxlength=20 style="width:140px;"/><font color="red">*</font>	</td>
    <th class="adminth">
	    确认密码:
	</th>
    <td class="admincls0">
	    <input class="easyui-validatebox" id="NPaswword" name="NPaswword" type="password" data-options="required:true,missingMessage:'请输入新密码'"  validtype="equalTo['#Paswword']"  maxlength=20 style="width:140px;"/><font color="red">*</font>	</td>
  </tr>
    <tr>
    <th class="adminth">
	    验证码:	</th>
    <td colspan="3" class="admincls0">
	  <input style="width:45px;border:1px solid #042a73; text-align:center;" type='text'  name="yzm2"  id="yzm2"   class="easyui-validatebox"  data-options=""/>&nbsp;&nbsp;  
        <asp:Image ID="CodeImg2" src="ChekCode.aspx"  onclick="document.getElementById('CodeImg2').src='ChekCode.aspx?tmp='+Math.random()" runat="server"  ImageUrl="ChekCode.aspx" />	</td>
    </tr>
  
  
  <tr>
    <td colspan="4" class="admincls0" align="center">
	    	<a href="#" id="submitButton" name="submitButton" class="easyui-linkbutton"  data-options="toggle:true,group:'g1'">确认</a>
	<a href="login.aspx" id="returnButton" name="returnButton" class="easyui-linkbutton"   data-options="toggle:true,group:'g1'">退出</a>
	</td>
    </tr>
</table>

</form>  
</body>
</html>
