<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="aspx_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>欢迎使用小河马外卖订餐系统</title>
    <script src="../Scripts/easyui/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../Scripts/easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../Scripts/easyui/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="../Scripts/easyui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/easyui/themes/icon.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
body {
	font: 12px/20px "微软雅黑", "宋体", Arial, sans-serif, Verdana, Tahoma;
	padding: 0;
	margin: 0;
}
a:link {
 text-decoration: none;
}
a:visited {
 text-decoration: none;
}
a:hover {
 text-decoration: underline;
}
a:active {
 text-decoration: none;
}
.cs-north {
	height:70px;
            width: 1141px;background:url('../images/top_bg.jpg')  repeat-x; padding:0;
        }
.cs-north-bg { padding:0; margin:0;
	
	
}
.cs-north-logo {
	height: 40px;
	margin: 15px 0 0 15px;
	display: inline-block;
	color:#000000;font-size:22px;font-weight:bold;text-decoration:none
}
.cs-west {
	width:200px;padding:0px;
}
.cs-south {
	height:40px;background:url('themes/pepper-grinder/images/ui-bg_fine-grain_15_ffffff_60x60.png') repeat-x;padding:0px;text-align:center;
}
.cs-navi-tab {
	padding: 5px;
}
.cs-tab-menu {
	width:120px;
}
.cs-home-remark {
	padding: 10px;
}
.wrapper {
    float: right;
    height: 30px;
    margin-left: 10px;
}
.ui-skin-nav {
    float: right;
	padding: 0;
	margin-right: 10px;
	list-style: none outside none;
	height: 20px;
	
}

.ui-skin-nav .li-skinitem {
    float: left;
    font-size: 12px;
    line-height: 20px;
	margin-left: 10px;
    text-align: center;
}
.ui-skin-nav .li-skinitem span {
	cursor: pointer;
	width:10px;
	height:10px;
	display:inline-block;
}
.ui-skin-nav .li-skinitem span.cs-skin-on{
	border: 1px solid #FFFFFF;
}
li {list-style-type:none;}

.ui-skin-nav .li-skinitem span.gray{background-color:gray;}
.ui-skin-nav .li-skinitem span.pepper-grinder{background-color:#BC3604;}
.ui-skin-nav .li-skinitem span.blue{background-color:blue;}
.ui-skin-nav .li-skinitem span.cupertino{background-color:#D7EBF9;}
.ui-skin-nav .li-skinitem span.dark-hive{background-color:black;}
.ui-skin-nav .li-skinitem span.sunny{background-color:#FFE57E;}
.dh_list{list-style:none; text-align:left; padding:5px; margin:5px 0;}
.dh_list li{ line-height:24px; border-bottom:1px dotted  #CDD9ED; background:url(images/list.gif) left no-repeat; padding-left:15px; margin-left:5px; }
</style>
<script type="text/javascript">
    function addTab(title, url) {
        if ($('#tabs').tabs('exists', title)) {
            $('#tabs').tabs('select', title); //选中并刷新
            //debugger;
            var currTab = $('#tabs').tabs('getSelected');
           //var url = $(currTab.panel('options').content).attr('src');
            if (url != undefined && currTab.panel('options').title != '导航') {
                $('#tabs').tabs('update', {
                    tab: currTab,
                   // cache:false,
                    options: {
                        content: createFrame(url)
                    }
                })
            }
        } else {
            var content = createFrame(url);
            $('#tabs').tabs('add', {
                title: title,
                content: content,
               // cache: false,
                closable: true
            });
        }
        tabClose();
    }
    function createFrame(url) {
        var s = '<iframe scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:100%;"></iframe>';
        return s;
    }

    function tabClose() {
        /*双击关闭TAB选项卡*/
        $(".tabs-inner").dblclick(function () {
            var subtitle = $(this).children(".tabs-closable").text();
            $('#tabs').tabs('close', subtitle);
        })
        /*为选项卡绑定右键*/
        $(".tabs-inner").bind('contextmenu', function (e) {
            $('#mm').menu('show', {
                left: e.pageX,
                top: e.pageY
            });

            var subtitle = $(this).children(".tabs-closable").text();

            $('#mm').data("currtab", subtitle);
            $('#tabs').tabs('select', subtitle);
            return false;
        });
    }
    //绑定右键菜单事件
    function tabCloseEven() {
        //刷新
        $('#mm-tabupdate').click(function () {
            var currTab = $('#tabs').tabs('getSelected');
            var url = $(currTab.panel('options').content).attr('src');
            if (url != undefined && currTab.panel('options').title != '导航') {
                $('#tabs').tabs('update', {
                    tab: currTab,
                    options: {
                        content: createFrame(url)
                    }
                })
            }
        })
        //关闭当前
        $('#mm-tabclose').click(function () {
            var currtab_title = $('#mm').data("currtab");
            $('#tabs').tabs('close', currtab_title);
        })
        //全部关闭
        $('#mm-tabcloseall').click(function () {
            $('.tabs-inner span').each(function (i, n) {
                var t = $(n).text();
                if (t != '导航') {
                    $('#tabs').tabs('close', t);
                }
            });
        });
        //关闭除当前之外的TAB
        $('#mm-tabcloseother').click(function () {
            var prevall = $('.tabs-selected').prevAll();
            var nextall = $('.tabs-selected').nextAll();
            if (prevall.length > 0) {
                prevall.each(function (i, n) {
                    var t = $('a:eq(0) span', $(n)).text();
                    if (t != '导航') {
                        $('#tabs').tabs('close', t);
                    }
                });
            }
            if (nextall.length > 0) {
                nextall.each(function (i, n) {
                    var t = $('a:eq(0) span', $(n)).text();
                    if (t != '导航') {
                        $('#tabs').tabs('close', t);
                    }
                });
            }
            return false;
        });
        //关闭当前右侧的TAB
        $('#mm-tabcloseright').click(function () {
            var nextall = $('.tabs-selected').nextAll();
            if (nextall.length == 0) {
                //msgShow('系统提示','后边没有啦~~','error');
                alert('后边没有啦~~');
                return false;
            }
            nextall.each(function (i, n) {
                var t = $('a:eq(0) span', $(n)).text();
                $('#tabs').tabs('close', t);
            });
            return false;
        });
        //关闭当前左侧的TAB
        $('#mm-tabcloseleft').click(function () {
            var prevall = $('.tabs-selected').prevAll();
            if (prevall.length == 0) {
                alert('到头了，前边没有啦~~');
                return false;
            }
            prevall.each(function (i, n) {
                var t = $('a:eq(0) span', $(n)).text();
                $('#tabs').tabs('close', t);
            });
            return false;
        });

        //退出
        $("#mm-exit").click(function () {
            $('#mm').menu('hide');
        })
    }

    $(function () {
        tabCloseEven();

        $('.cs-navi-tab').click(function () {
            var $this = $(this);
            var href = $this.attr('src');
            var title = $this.text();
            addTab(title, href);
        });

        var themes = {
            'gray': 'themes/gray/easyui.css',
            'pepper-grinder': 'themes/pepper-grinder/easyui.css',
            'blue': 'themes/default/easyui.css',
            'cupertino': 'themes/cupertino/easyui.css',
            'dark-hive': 'themes/dark-hive/easyui.css',
            'sunny': 'themes/sunny/easyui.css'
        };

        var skins = $('.li-skinitem span').click(function () {
            var $this = $(this);
            if ($this.hasClass('cs-skin-on')) return;
            skins.removeClass('cs-skin-on');
            $this.addClass('cs-skin-on');
            var skin = $this.attr('rel');
            $('#swicth-style').attr('href', themes[skin]);
            setCookie('cs-skin', skin);
            skin == 'dark-hive' ? $('.cs-north-logo').css('color', '#FFFFFF') : $('.cs-north-logo').css('color', '#000000');
        });

        if (getCookie('cs-skin')) {
            var skin = getCookie('cs-skin');
            $('#swicth-style').attr('href', themes[skin]);
            $this = $('.li-skinitem span[rel=' + skin + ']');
            $this.addClass('cs-skin-on');
            skin == 'dark-hive' ? $('.cs-north-logo').css('color', '#FFFFFF') : $('.cs-north-logo').css('color', '#000000');
        }
    });


    function setCookie(name, value) {//两个参数，一个是cookie的名子，一个是值
        var Days = 30; //此 cookie 将被保存 30 天
        var exp = new Date();    //new Date("December 31, 9998");
        exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
        document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
    }

    function getCookie(name) {//取cookies函数        
        var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
        if (arr != null) return unescape(arr[2]); return null;
    }

    function loginout(flag) {

        var msgs = "确定要";
        if (flag == 1)
        msgs += "注销吗？";
        else
        msgs += "退出系统吗？";

    if (!confirm(msgs)) {
            return;
        }

        $.ajax({
            url: '../handler/CommonHandler.ashx?Entity=common&OPRAction=loginout',
            data: null,
            type: 'post',
            dataType: "json",
            success: function (data) {
                if (data.ErrCode == 1) {
                    alert(data.ErrMessage);
                    top.location.href = "login.aspx";
                }
                else if (data.ErrCode == 2) {
                    alert(data.ErrMessage);
                }
                else {
                    if (flag == 1) {
                        alert(data.msg);
                        top.location.href = "login.aspx";
                    }
                    else { 
                    alert("成功退出系统！")
                    //window.opener=null;
                    window.open('','_self','');
                    window.close();

                    }
                }

            }

        });
       
    
    }
</script>
</head>
<body class="easyui-layout">
	<form id="form1" runat="server">
	<div region="north" border="true" class="cs-north">  
		<div class="cs-north-bg"  > 
		
		<table border="0" cellpadding=0 cellspacing=0 width="100%"><tr><td><img src="../images/top.jpg" style=" border:0; "/></td><td align="right" style=" vertical-align:bottom;padding-right:25px;"><asp:Label ID="lb_user" runat="server" Text="Label"  
                style="   font-size:14px; color:#0033cc; " ></asp:Label></td></tr></table>  
            
          
   
		</div> 
        </div>

	<div region="west" border="true"  split="true" title="导航" class="cs-west">
		<div class="easyui-accordion" fit="false" border="false">
        
 <div  title="<div  style='text-align:center; align:center'><img src='../themes/icons/mini_add.png'/>----菜品管理----</div>"  >
                                <ul class="dh_list"><li>
<a href="javascript:void(0);" src="menuList.aspx" class="cs-navi-tab">菜品管理</a></li>
 </ul>

</div>
   <div title="<div  style='text-align:center; align:center'><img src='../themes/icons/mini_add.png'/>----订单管理----</div>"  >
                             <ul class="dh_list">
                             <li>
                            <a href="javascript:void(0);" src="orderList.aspx" class="cs-navi-tab">订单管理</a></li>
                                                       
                            </ul>
					 
				</div>
                 
                <div title="<div  style='text-align:center; align:center'><img src='../themes/icons/mini_add.png'/>----商家管理----</div>"  >
                             <ul class="dh_list"><li>
                            <a href="javascript:void(0);" src="userList.aspx" class="cs-navi-tab">用户管理</a></li>
                            <li>
                            <a href="javascript:loginout(1);" style=" padding-left:5px;"   >用户注销</a></li>
                            <li>
                            <a href="javascript:loginout(2);" style=" padding-left:5px;"   >退出系统</a></li>
                            </ul>
					 
				</div>
				
		</div>
	</div>
	<div id="mainPanle" region="center" border="true" border="false">
		 <div id="tabs" class="easyui-tabs"  fit="true" border="false" >
                <div title="首页">
			
				<div id="aa" class="easyui-accordion" style="margin:10px 5px;" fit="false" >
                                    <div title="最新动态" icon="icon-save" style="overflow: auto; padding: 10px;" selected="true">
                                                                                               
                                                    

                  </div>
<div>
</div>

                  </div>

				</div>
        </div>
	</div>

	<div region="south" border="false" class="cs-south">
 小河马外卖订餐系统 版权所有</div>
	
	<div id="mm" class="easyui-menu cs-tab-menu">
		<div id="mm-tabupdate">刷新</div>
		<div class="menu-sep"></div>
		<div id="mm-tabclose">关闭</div>
		<div id="mm-tabcloseother">关闭其他</div>
		<div id="mm-tabcloseall">关闭全部</div>
	</div>
    </form>
</body>
</html>
