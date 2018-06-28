<%@ WebHandler Language="C#" Class="loginhandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Data;


public class loginhandler : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        try
        {
            context.Response.ContentType = "text/plain";
            string msg = "";
            string username = context.Request["UserName"];
            string certification = context.Request["Certification"];
            string pwd = context.Request["Password"];
            string yzm = context.Request["yzm"];
            string yzm1 = context.Session["CheckCode"].ToString().ToLower();


            Maticsoft.BLL.Seller sellerService = new Maticsoft.BLL.Seller();
            Maticsoft.Model.Seller sellerMod = new Maticsoft.Model.Seller();


            string where = "  seller_idcard='" + certification + "' and  seller_name='" + username + "' and seller_pwd = '" + pwd + "'";
            List<Maticsoft.Model.Seller> list = sellerService.GetModelList(where);
            if (yzm1.Trim() != yzm.ToLower().Trim())
            {
                msg = "-1";//验证码错误
            }
            else if (list.Count == 1)//密码验证通过
            {
                context.Session["User"] = list[0];
                msg = "1";

            }
            else
            {
                context.Session["User"] = null;//密码验证失败
                msg = "0";
            }
            context.Response.Clear();
            context.Response.Write(msg);

        }
        catch (Exception e)
        {
            context.Response.Clear();
            context.Response.Write("-2");

        }
        context.Response.End();

    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}