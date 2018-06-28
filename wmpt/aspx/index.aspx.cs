using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class aspx_index : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Maticsoft.Model.Seller user = (Maticsoft.Model.Seller)Session["user"];
            
            string struser = " <b >【当前用户】</b>：" + user.seller_name;
            this.lb_user.Text = struser;


        }
    }
}