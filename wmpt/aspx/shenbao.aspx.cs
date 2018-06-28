using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;



public partial class aspx_shenbao :BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string mOp = Request["Op"];
        string  mID = "";

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
    protected void BtnUp_Click(object sender, EventArgs e)
    {
        if (FileUpload.HasFile)
        {
            string savePath = Server.MapPath("../upload/");//指定上传文件在服务器上的保存路径
            string serPath = "";
            //检查服务器上是否存在这个物理路径，如果不存在则创建
            if (!System.IO.Directory.Exists(savePath))
            {
                System.IO.Directory.CreateDirectory(savePath);
            }
            string fileNewName = System.Guid.NewGuid().ToString();
            string Extension = Path.GetExtension(FileUpload.PostedFile.FileName);
            savePath = savePath  + fileNewName + Extension;
            FileUpload.SaveAs(savePath);
//            LabMsg.Text = string.Format("<a href='upload/{0}'>upload/{0}</a>", FileUpload.FileName);
            serPath = "../upload/" + fileNewName + Extension;
            this.img.Src = serPath;
            this.food_img.Value = serPath;
        }
        else
        {
//            LabMsg.Text = "你还没有选择上传文件!";
            Response.Write("<script type='text/javascript'>alert('你还没有选择上传文件!');</script>");
            return;

        }



    }
}