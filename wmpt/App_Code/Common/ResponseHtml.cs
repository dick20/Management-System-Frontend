using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Common.Json;
using System.Collections;
namespace Common.Response
{
    /// <summary>
    ///ResponseHtml 的摘要说明
    ///
    /// </summary>
    public class ResponseHtml
    {
        public ResponseHtml()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public static void OutputErr(int errCode, string errMessage, HttpContext context)
        {
            Common.Json.JsonHelp jss = new JsonHelp(errCode, errMessage);
            string mstr = jss.Serialize();


            context.Response.Clear();
            context.Response.ContentType = "text/plain";
            context.Response.Write(mstr);
            //  HttpContext.Current.ApplicationInstance.CompleteRequest();

        }
        public static void OutputErr(int errCode, string errMessage, IDictionary<string, object>[] dArray, HttpContext context)
        {
            Common.Json.JsonHelp jss = new JsonHelp(errCode, errMessage, dArray);
            string mstr = jss.Serialize();


            context.Response.Clear();
            context.Response.ContentType = "text/plain";
            context.Response.Write(mstr);
            //  HttpContext.Current.ApplicationInstance.CompleteRequest();

        }
        public static void OutputErr(int errCode, string errMessage, IDictionary<string, object> dArray, HttpContext context)
        {
            Common.Json.JsonHelp jss = new JsonHelp(errCode, errMessage, dArray);
            string mstr = jss.Serialize();


            context.Response.Clear();
            context.Response.ContentType = "text/plain";
            context.Response.Write(mstr);
            //  HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        public static void OutputErr(int errCode, string errMessage, ArrayList dArray, HttpContext context)
        {
            Common.Json.JsonHelp jss = new JsonHelp(errCode, errMessage, dArray);
            string mstr = jss.Serialize();


            context.Response.Clear();
            context.Response.ContentType = "text/plain";
            context.Response.Write(mstr);
            //  HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        public static void OutputMessage(int Code, string Name, string message, HttpContext context)
        {
            Common.Json.JsonHelp jss = new JsonHelp(Code, "");
            jss.Add(Name, message);
            string mstr = jss.Serialize();


            context.Response.Clear();
            context.Response.ContentType = "text/plain";
            context.Response.Write(mstr);
            //  HttpContext.Current.ApplicationInstance.CompleteRequest();

        }
        public static void OutputTable(DataTable Table,int rowCount, HttpContext context)
        {
            Common.Json.JsonHelp jss = new JsonHelp(Table, rowCount, true);
            string mstr = jss.Serialize();


            context.Response.Clear();
            context.Response.ContentType = "text/plain";
            context.Response.Write(mstr);
            //  HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        public static void OutputObject(Object obj,HttpContext context)
        {
            Common.Json.JsonHelp jss = new JsonHelp(obj);
            string mstr = jss.SerializeObj();
            mstr = mstr.Replace("Children", "children");
            context.Response.Clear();
            context.Response.ContentType = "text/plain";
            context.Response.Write(mstr);
            //  HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

    }
}