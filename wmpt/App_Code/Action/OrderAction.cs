using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;
using Common.Response;
using Common.Json;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Text;

using System.Drawing.Imaging;
using System.Data.SqlClient;

/// <summary>
///ProjectAction 的摘要说明
/// </summary>
public class OrderAction : ActionFace
{
    public OrderAction()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    Maticsoft.BLL.View_Order vorderBll = new Maticsoft.BLL.View_Order();
    Maticsoft.BLL.Order orderBll = new Maticsoft.BLL.Order();
    Maticsoft.BLL.Manager2 manager2Bll = new Maticsoft.BLL.Manager2();
    public void dataProccess(Maticsoft.Model.Seller user, HttpContext context)
    {

        string mOprAction = context.Request["OPRAction"].ToString().Trim().ToUpper();
        if (mOprAction == "get_OrderList".ToUpper())//获取菜单列表
        {   

            string mOrderInfo = context.Request["keyword"];
            int mPage = int.Parse(context.Request["page"]);
            int mRows = int.Parse(context.Request["rows"]);
            string mSort = context.Request["sort"];
            string mOrder = context.Request["order"];
            string mWhere = "";


            if (mOrderInfo != "" && mOrderInfo != null)
            {
                if (mWhere != "")
                    mWhere += " and";
                mWhere += "  order_info like '%" + mOrderInfo + "%'";
            }

            mOrder = mSort + " " + mOrder;
            
           
            if (user.role_id == 0)//管理员
            {
                get_data( mPage,  mRows,  mOrder, mWhere,   context);
              
            }
            else               //店家
            {
                if (mWhere != "")
                    mWhere += "  and";
                 mWhere += "  seller_id='" + user.seller_id.ToString().Trim() + "'";
                get_data(mPage, mRows, mOrder, mWhere,  context);
            }
        }
            else if (mOprAction == "del_Data".ToUpper())
            {
                string mID = context.Request["ids"];
                bool mDelResult;
                if (mID != null && mID != "")
                {
                    mDelResult = orderBll.DeleteList(mID.ToString().Trim());

                    if (mDelResult)
                    {
                        manager2Bll.DeleteList(mID.ToString().Trim());
                        ResponseHtml.OutputErr(0, "删除成功！", context);
                    }
                    else
                        ResponseHtml.OutputErr(2, "删除失败！", context);
                }
            }
                 else if (mOprAction == "add_Data".ToUpper())
                {

                     string mData = context.Request["mData"];
                    JavaScriptSerializer js = new JavaScriptSerializer();

                    Maticsoft.Model.Order mOrderMod = js.Deserialize<Maticsoft.Model.Order>(mData);
                    Maticsoft.Model.Manager2 mManager2Mod = new Maticsoft.Model.Manager2();

                    mOrderMod.order_id = GetMaxID.getid(1, "Order");
                     bool mResult = orderBll.Add(mOrderMod);
                     if (mResult)
                     {
                         mManager2Mod.seller_id = user.seller_id;
                         mManager2Mod.order_id = mOrderMod.order_id;
                         manager2Bll.Add(mManager2Mod);
                         ResponseHtml.OutputMessage(0, "msg", "添加成功！", context);
                     }
                     else
                         ResponseHtml.OutputErr(2, "添加失败！", context);
            
                }
                       else if (mOprAction == "Load_UpData".ToUpper())
                        {
                            string order_id = context.Request["id"];

                            Maticsoft.Model.Order mOrderMod = new Maticsoft.Model.Order();
                            DataSet mds = orderBll.GetList(" order_id=" + order_id);

                            ResponseHtml.OutputTable(mds.Tables[0], mds.Tables[0].Rows.Count, context);

                        }
                        else if (mOprAction == "up_Data".ToUpper())
                        {

                            string mData = context.Request["mData"];
                            JavaScriptSerializer js = new JavaScriptSerializer();
                            Maticsoft.Model.Order mOrderMod = js.Deserialize<Maticsoft.Model.Order>(mData);
                            bool mResult = orderBll.Update(mOrderMod);
                            if (mResult)
                                ResponseHtml.OutputMessage(0, "msg", "修改成功！", context);
                            else
                                ResponseHtml.OutputErr(2, "修改失败！", context);

                        }
        

    }


    private void get_data(int page, int rows, string order, string where, HttpContext context)
    {
        DataSet ds = vorderBll.GetListByPage( where, order, rows * (page - 1) + 1, rows * page);
        int rowCount = vorderBll.GetRecordCount(where);
        ResponseHtml.OutputTable(ds.Tables[0], rowCount, context);

    }


}