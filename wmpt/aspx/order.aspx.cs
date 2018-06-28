using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class aspx_order : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string mOp = Request["Op"];
        string mID = "";

        HiddenOp.Value = mOp.ToUpper();
        if (mOp.ToUpper() != "add".ToUpper())
        {
            mID = Request["id"].ToString().Trim();
            HiddenID.Value = mID;
        }
        else
        {

        }
    }
}