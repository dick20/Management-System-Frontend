<%@ WebHandler Language="C#" Class="Registerhandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Data;
using Common.Response;

public class Registerhandler : IHttpHandler, IRequiresSessionState
{
 
    public void ProcessRequest (HttpContext context) {
        try
        {
            context.Response.ContentType = "text/plain";
       
            string username = context.Request["UserName"];
            string pwd = context.Request["PassWord"];
            string cardID = context.Request["CardID"];
            string phone = context.Request["Phone"];

            string Address = context.Request["Address"];
            string yzm = context.Request["yzm2"];
            string yzm1 = context.Session["CheckCode"].ToString().ToLower();
            string msg = "";
            

             if (yzm1.Trim() != yzm.ToLower().Trim())
             {
                 msg = "验证码错误";//验证码错误
             }
            else{
                Maticsoft.BLL.Seller mbll = new Maticsoft.BLL.Seller();
                Maticsoft.Model.Seller mdel = new Maticsoft.Model.Seller();
                mdel.seller_name = username;
                mdel.seller_pwd = pwd;
                mdel.seller_idcard = cardID;
                mdel.seller_phone = phone;
                mdel.seller_addr = Address;
                mdel.role_id = 1;
                mdel.seller_id = GetMaxID.getid(1, "Seller");
                
                 if(mbll.ExistsID(mdel.seller_idcard))
                 {
                     msg = "此商家账户已经注册过用户";
                     ResponseHtml.OutputErr(2, msg, context);
                     return;
                 }
                 else
                 {
                     mbll.Add(mdel);
                     msg = "";
                 }
                                  
             }
//            context.Response.Write(msg);

            
            if (msg.Trim() == "")
            {
                ResponseHtml.OutputErr(0, msg, context);
            }
            else
            {
                ResponseHtml.OutputErr(2, msg, context); 
            }
            
        }
        catch(Exception e)
        {
            ResponseHtml.OutputErr(2, e.Message, context); 
        }
        context.Response.End();
    } 
    public bool IsReusable {
        get {
            return false;
        }
    }

}