using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;
using Common.Response;

/// <summary>
///UserAction 的摘要说明
/// </summary>
public class UserAction : ActionFace
{
	public UserAction()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}


    private Maticsoft.BLL.Seller userservice = new Maticsoft.BLL.Seller();


    
    public void dataProccess(Maticsoft.Model.Seller user, HttpContext context)
    {
        string mOprAction = context.Request["OPRAction"].ToString().Trim().ToUpper();
        Maticsoft.Model.Seller user_Model = (Maticsoft.Model.Seller)context.Session["user"];

       if (mOprAction == "getUserList".ToUpper())//获取用户列表
        {
            int page = int.Parse(context.Request["page"]);
            int rows = int.Parse(context.Request["rows"]);
            string sort = context.Request["sort"];
            string order = context.Request["order"];
            string where = "1=1";

            order = sort + " " + order;

            if (user_Model.role_id == 0)//管理员
            {
                ;
            }
            else if (user_Model.role_id == 1)//其他商户
            {
                where = where + "  and  seller_id='" + user.seller_id.ToString().Trim() + "'";
            }
                       
                    
            get_data(page, rows, order, where,context);
        }

        else if (mOprAction == "add".ToUpper())//添加用户
        {
            string seller_name = context.Request["seller_name"];
            string seller_pwd = context.Request["seller_pwd"];
//            int role_id = Int32.Parse(context.Request["role_id"]);
            string seller_addr = context.Request["seller_addr"];
            string seller_phone = context.Request["seller_phone"];
            string seller_idcard = context.Request["seller_idcard"];
    
            Maticsoft.Model.Seller usermodel = new Maticsoft.Model.Seller();

            usermodel.seller_name = seller_name;
            usermodel.seller_pwd = seller_pwd;
//            usermodel.role_id = role_id;
            usermodel.seller_addr = seller_addr;
            usermodel.seller_phone = seller_phone;
            usermodel.seller_idcard = seller_idcard;            
            usermodel.seller_id = GetMaxID.getid(1, "Seller");
           
           string msg = "";
           bool result = userservice.Add(usermodel);

            if (result)
            {
                msg = "添加成功!";
                ResponseHtml.OutputMessage(0, "msg", msg, context);
            }
            else
            {
                msg = "增加失败!";
                ResponseHtml.OutputMessage(2, "msg", msg, context);
            }   
        }
        else if (mOprAction == "up".ToUpper())//管理员修改用户信息
        {
            string seller_name = context.Request["seller_name"];
            string seller_pwd = context.Request["seller_pwd"];
//            int role_id = Int32.Parse(context.Request["role_id"]);
            string seller_addr = context.Request["seller_addr"];
            string seller_phone = context.Request["seller_phone"];
            string seller_idcard = context.Request["seller_idcard"];

           int seller_id = Int32.Parse(context.Request["seller_id"].Trim());


            Maticsoft.Model.Seller usermodel = new Maticsoft.Model.Seller();

            usermodel.seller_name = seller_name;
            usermodel.seller_pwd = seller_pwd;
//            usermodel.role_id = role_id;
            usermodel.seller_addr = seller_addr;
            usermodel.seller_phone = seller_phone;
            usermodel.seller_idcard = seller_idcard;
            usermodel.seller_id = seller_id;
      
            string msg = "";
            bool result = userservice.Update(usermodel);

            if (result)
            {
                msg = "修改成功!";
                ResponseHtml.OutputMessage(0, "msg", msg, context);
            }
            else
            {
                msg = "修改失败!";
                ResponseHtml.OutputMessage(2, "msg", msg, context);
            }
        }

        else if (mOprAction == "del".ToUpper())//删除用户
        {
            string ids = context.Request["ids"];
            string msg = "";
            bool result = userservice.DeleteList(ids);
            if (result)
            {
                msg = "删除成功!";
                ResponseHtml.OutputMessage(0, "msg", msg, context);
            }
            else
            {
                msg = "删除失败!";
                ResponseHtml.OutputMessage(2, "msg", msg, context);
            }
        }
        else if (mOprAction == "getusermodel".ToUpper())//获取一条指定用户的所有信息
        {
            int id = GetMaxID.praseInt(context.Request["id"]);
            Maticsoft.Model.Seller view_usermodel = userservice.GetModel(id);


            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(view_usermodel);
            ResponseHtml.OutputMessage(0, "json", json, context);
        }
        else if (mOprAction == "getpersonalmodel".ToUpper())//获取当前登录用户信息
        {

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(user_Model);
            ResponseHtml.OutputMessage(0, "json", json, context);
        }
        else if (mOprAction == "up_personal".ToUpper())//用户自己修改个人信息
        {
            int seller_id = user_Model.seller_id;//;
            string seller_name = context.Request["seller_name"];
            string seller_pwd = context.Request["seller_pwd"];
            int role_id = Int32.Parse(context.Request["role_id"]);
            string seller_addr = context.Request["seller_addr"];
            string seller_phone = context.Request["seller_phone"];
            string seller_idcard = context.Request["seller_idcard"];

            user_Model.seller_name = seller_name;
            user_Model.seller_pwd = seller_pwd;
            user_Model.role_id = role_id;
            user_Model.seller_addr = seller_addr;
            user_Model.seller_phone = seller_phone;
            user_Model.seller_idcard = seller_idcard;
            user_Model.seller_id = seller_id;

            string msg = "";
            bool result = userservice.Update(user_Model);

            if (result)
            {
                msg = "修改成功!";
                ResponseHtml.OutputMessage(0, "msg", msg, context);
            }
            else
            {
                msg = "修改失败!";
                ResponseHtml.OutputMessage(2, "msg", msg, context);
            }
        }

     }
    
    private void get_data(int page, int rows, string order, string where, HttpContext context)
    {
        DataSet ds = userservice.GetListByPage(where, order, rows * (page - 1) + 1, rows * page);
        int rowCount = userservice.GetRecordCount(where);
        ResponseHtml.OutputTable(ds.Tables[0], rowCount, context);

    }
   
}