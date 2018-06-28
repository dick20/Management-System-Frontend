using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///DownLoad 的摘要说明
/// </summary>
/// 
namespace Common.DownLoad
{
    public class FileDownLoad
    {
        public FileDownLoad()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

      public void Download(string FileName, HttpResponse Response)
        {
            // genXmlfile();
            System.IO.FileStream r = new System.IO.FileStream(FileName, System.IO.FileMode.Open);    //文件下载实例化 
            //设置基本信息   
            Response.Buffer = false;
            Response.AddHeader("Connection", "Keep-Alive");
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + System.IO.Path.GetFileName(FileName)); // 此处文件名如果是中文在浏览器默认是筹码,应该加HttpUtility.UrlEncode(filename) 
            Response.AddHeader("Content-Length", r.Length.ToString());
            while (true)    //如果文件大于缓冲区，通过while循环多次加载文件 
            {
                //开辟缓冲区空间   
                byte[] buffer = new byte[1024];  //读取文件的数据   
                int leng = r.Read(buffer, 0, 1024);
                if (leng == 0)             //到文件尾，结束   
                    break;
                if (leng == 1024)            //读出的文件数据长度等于缓冲区长度，直接将缓冲区数据写入  
                    Response.BinaryWrite(buffer);           //向客户端发送数据流 
                else
                {
                    //读出文件数据比缓冲区小，重新定义缓冲区大小，只用于读取文件的最后一个数据块  
                    byte[] b = new byte[leng]; for (int i = 0; i < leng; i++)
                        b[i] = buffer[i];
                    Response.BinaryWrite(b);
                }
            }
            r.Close();//关闭下载文件  
            try
            {
                System.IO.File.Delete(FileName);
            }
            catch { }

           Response.End();//结束文件下载 



        }
    }
}