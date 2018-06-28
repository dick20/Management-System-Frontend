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


using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;

/// <summary>
///ProjectAction 的摘要说明
/// </summary>
public class MenuAction : ActionFace
{
    public MenuAction()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    Maticsoft.BLL.View_Menu vmenuBll = new Maticsoft.BLL.View_Menu();
    Maticsoft.BLL.Menu menuBll = new Maticsoft.BLL.Menu();
    Maticsoft.BLL.Manager1 manager1Bll = new Maticsoft.BLL.Manager1();
    public void dataProccess(Maticsoft.Model.Seller user, HttpContext context)
    {

        string mOprAction = context.Request["OPRAction"].ToString().Trim().ToUpper();
        if (mOprAction == "get_MenuList".ToUpper())//获取菜单列表
        {   

            string mFoodName = context.Request["keyword"];
            int mPage = int.Parse(context.Request["page"]);
            int mRows = int.Parse(context.Request["rows"]);
            string mSort = context.Request["sort"];
            string mOrder = context.Request["order"];
            string mWhere = "";


            if (mFoodName != "" && mFoodName != null)
            {
                if (mWhere != "")
                    mWhere += " and";
                mWhere += "  food_name like '%" + mFoodName + "%'";
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
                    mDelResult = menuBll.DeleteList(mID.ToString().Trim());

                    if (mDelResult)
                    {
                        manager1Bll.DeleteList(mID.ToString().Trim());
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

                    Maticsoft.Model.Menu mMenuMod = js.Deserialize<Maticsoft.Model.Menu>(mData);
                    Maticsoft.Model.Manager1 mManager1Mod = new Maticsoft.Model.Manager1();

                    mMenuMod.food_id = GetMaxID.getid(1, "Menu");
                     bool mResult = menuBll.Add(mMenuMod);
                     if (mResult)
                     {
                         mManager1Mod.seller_id = user.seller_id;
                         mManager1Mod.food_id = mMenuMod.food_id;
                         manager1Bll.Add(mManager1Mod);
                         ResponseHtml.OutputMessage(0, "msg", "添加成功！", context);
                     }
                     else
                         ResponseHtml.OutputErr(2, "添加失败！", context);
            
                }
                       else if (mOprAction == "Load_UpData".ToUpper())
                        {
                            string food_id = context.Request["id"];

                            Maticsoft.Model.Menu mMenuMod = new Maticsoft.Model.Menu();
                            DataSet mds = menuBll.GetList(" food_id=" + food_id);

                            ResponseHtml.OutputTable(mds.Tables[0], mds.Tables[0].Rows.Count, context);

                        }
                        else if (mOprAction == "up_Data".ToUpper())
                        {

                            string mData = context.Request["mData"];
                            JavaScriptSerializer js = new JavaScriptSerializer();
                            Maticsoft.Model.Menu mMenuMod = js.Deserialize<Maticsoft.Model.Menu>(mData);
                            bool mResult = menuBll.Update(mMenuMod);
                            if (mResult)
                                ResponseHtml.OutputMessage(0, "msg", "修改成功！", context);
                            else
                                ResponseHtml.OutputErr(2, "修改失败！", context);

                        }
        

    }


    private void get_data(int page, int rows, string order, string where, HttpContext context)
    {
        DataSet ds = vmenuBll.GetListByPage( where, order, rows * (page - 1) + 1, rows * page);
        int rowCount = vmenuBll.GetRecordCount(where);
        ResponseHtml.OutputTable(ds.Tables[0], rowCount, context);

    }


}