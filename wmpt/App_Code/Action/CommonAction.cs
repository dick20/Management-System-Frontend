using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Common.Response;
using System.Web.Script.Serialization;


/// <summary>
///CommonAction 的摘要说明
/// </summary>
public class CommonAction : ActionFace
{
	public CommonAction()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public void dataProccess(Maticsoft.Model.Seller user, HttpContext context)
    {

        string mOprAction = context.Request["OPRAction"].ToString().Trim().ToUpper();
        if (mOprAction == "loginout".ToUpper())//
        {
            context.Session["user"] = null;
            string msg = "注销成功！";
                 ResponseHtml.OutputMessage(0, "msg", msg, context);
        }
 
     }



}