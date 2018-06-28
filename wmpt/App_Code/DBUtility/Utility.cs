using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Maticsoft.BLL;
using System.Xml;
namespace Maticsoft.Utility
{


    public struct RtpTile
    {
        public string XL_Tilte;
        public string XL_IndexCode;
        public  List<IndexMess> indexmess;
    }
    public struct IndexMess
    {
        public string IndexCode;
        public string IndexName;
        public double Score;

    }
    /// <summary>
    ///Utility 的摘要说明
    /// </summary>
   public struct FileRole
   {
        public string FileName;
        public string Rolestr; 
    }
    public class Utility
    {
       static FileRole[] PFileRoles;

        public Utility()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        static public void GetAllFileRols(string Path)
        {
            string mPath =Path+"RoleCFG.xml";
            XmlDocument mXmlDocument;
            mXmlDocument = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(mPath); 
            mXmlDocument.Load(reader);
            XmlNode mRoot = mXmlDocument.DocumentElement;
            int Count = mRoot.ChildNodes.Count;
            PFileRoles=new FileRole[Count];
            int i;
            for (i = 0; i < Count; i++)
            {
                PFileRoles[i].FileName = mRoot.ChildNodes[i].InnerText.Trim();
                PFileRoles[i].Rolestr = GetAttrValue(mRoot.ChildNodes[i].Attributes, "RoleStr");
            }
        }
        static private  string GetAttrValue(XmlAttributeCollection Attr, string AttrName)
        {
            string mvalue = "";
            if (Attr[AttrName] != null)
            {
                mvalue = Attr[AttrName].InnerText;
            }
            return mvalue;
        }
        static public bool IsAllowedByUser(string FileName, string UserType)
        {
            bool isAllowed = false;
            int i;
            for (i = 0; i < PFileRoles.Length; i++)
            {
                if (FileName.ToUpper() == PFileRoles[i].FileName.ToUpper())
                {
                    if (PFileRoles[i].Rolestr.IndexOf(UserType) >= 0)
                    {
                        isAllowed = true;
                        break;
                    }
                }
            }
            return isAllowed;
        }
    }
}