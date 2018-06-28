<%@ WebHandler Language="C#" Class="CommonHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using Common.Response;
public class CommonHandler : IHttpHandler, IRequiresSessionState{

    private Maticsoft.Model.Seller SessionUser = null;
    public void ProcessRequest (HttpContext context) {
        try
        {
            if (checkSession(context) == false)
            {
                ResponseHtml.OutputErr(1, "session超时或用户未登录", context); 
            }
            else
            {
                string mEntity = context.Request["Entity"].ToString();
                ActionFace IAction = ActionFactroy.createAction(mEntity);
                IAction.dataProccess(SessionUser, context);
            }
       
        }
        catch (Exception e)
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
    public bool checkSession(HttpContext context) {
        bool b = false;
        SessionUser = context.Session["user"] as Maticsoft.Model.Seller;
        if (SessionUser!=null)
        {
            b = true;
        }
        
        return b;
    }

}