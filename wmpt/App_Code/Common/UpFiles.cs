using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Common.UpLoad
{
    /// <summary>
    ///UpFiles 的摘要说明
    /// </summary>
    public class UpFiles
    {
       
        private bool mIsExistUpFiles;
        private string[] mFilesURLs;

        public string[] FilesURLs
        {
            get { return mFilesURLs; }
        }
        public bool IsExistUpFiles
        {
            get { return mIsExistUpFiles; }
        }
        public UpFiles(HttpContext context, string Year, string AreaCode,string FL)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            HttpFileCollection hfc = context.Request.Files;
            int FilesCount = hfc.Count;
            mIsExistUpFiles = FilesCount > 0;
            mFilesURLs = new string[FilesCount];
            int i;
            for (i = 0; i < FilesCount; i++)
            {
                HttpPostedFile hpf = hfc[i];
                if (hpf.ContentLength > 0)
                {
                    string filename = System.IO.Path.GetFileName(hpf.FileName);
                    string Suffix = filename.Split('.')[1];
                    string path = context.Server.MapPath("~/upload");
                    path = path + "/" + Year;
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    filename = AreaCode + "-" + FL+"-"+i.ToString() + "." + Suffix;
                    string s2 = path + "/" + filename;
                    hpf.SaveAs(s2);
                    mFilesURLs[i] = "../upload/" + Year + "/" + filename;
                }

            }

        }
    }
}