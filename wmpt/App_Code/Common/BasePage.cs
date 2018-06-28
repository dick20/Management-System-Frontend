using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Text;

/// <summary>
///BasePage 的摘要说明
/// </summary>
public class BasePage:System.Web.UI.Page
{
    private Hashtable m_Parameters;	//瀛樻斁鎵€鏈夋煡璇㈠弬鏁?
    private int m_PageLoadCounter = 1;
    private string _AllowedRole;

    private string mRole;

    public string Role
    {
        get { return mRole; }
        set { mRole = value; }
    }

    /// <summary>
    /// 绫荤殑鏋勯€犲嚱鏁?
    /// </summary>

    public BasePage()
    {
        m_Parameters = new Hashtable();
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        //this.Load += new System.EventHandler(this.BasePage_Load);
        //this.Error += new System.EventHandler(this.BasePage_Error);

        CheckLogin();

    }


    /// <summary>
    /// 瑙ｆ瀽WEB璇锋眰鏌ヨ瀛楃涓?
    /// </summary>
    private void ExplainParameters()
    {
        string parameter;
        string parameterName;
        string parameterValue;
        string[] parameters;

        parameter = HttpUtility.UrlDecode(Request.QueryString.ToString());
        parameters = parameter.Split('&');

        for (int index = 0; index < parameters.Length; index++)
        {
            if (parameters[index].Length > 0)
            {
                parameterName = parameters[index].Substring(0, parameters[index].IndexOf("="));
                //parameterName = parameterName.ToUpper();

                parameterValue = parameters[index].Substring(parameters[index].IndexOf("=") + 1);

                if (m_Parameters.Contains(parameterName))
                {
                    m_Parameters.Remove(parameterName);
                }
                m_Parameters.Add(parameterName, parameterValue);
            }
        }
    }


    protected void BasePage_Error(object sender, System.EventArgs e)
    {
    }



    /// <summary>
    ///杈撳嚭淇℃伅鍒板鎴风
    /// </summary>
    /// <param name="p_Message">瑕佽緭鍑虹殑淇℃伅</param>
    public void OutputMessage(string p_Message)
    {
        StringBuilder outputMsg;

        outputMsg = new StringBuilder();

        outputMsg.Append("<script language='javascript'>\n");
        outputMsg.Append("\twindow.setTimeout('showMessage()',1);\n");
        outputMsg.Append("\tfunction showMessage(){\n");
        outputMsg.Append("\t\twindow.alert('");
        outputMsg.Append(p_Message);
        outputMsg.Append("');\n");
        outputMsg.Append("\t}\n");
        outputMsg.Append("</script>\n");

        Response.Clear();
        Response.Write(outputMsg.ToString());
    }

    /// <summary>
    /// 杈撳嚭淇℃伅鍒板鎴风,骞堕噸瀹氬悜鍒版柊鐨勯〉闈?
    /// </summary>
    /// <param name="p_Message">瑕佽緭鍑虹殑淇℃伅</param>
    /// <param name="p_Url">鏂伴〉闈㈢殑URL</param>
    public void OutputMessage(string p_Message, string p_Url)
    {
        string url;
        string parameters;
        StringBuilder outputMsg;

        url = "";
        parameters = "";
        outputMsg = new StringBuilder();

        outputMsg.Append("<script language='javascript'>\n");
        outputMsg.Append("\twindow.setTimeout('showMessage()',1);\n");
        outputMsg.Append("\tfunction showMessage(){\n");
        outputMsg.Append("\t\twindow.alert('");
        outputMsg.Append(p_Message);
        outputMsg.Append("');\n");

        if (p_Url.IndexOf("?") > -1)
        {
            url = p_Url.Substring(0, p_Url.IndexOf("?"));
            url += "?";
            parameters = p_Url.Substring(p_Url.IndexOf("?") + 1);
        }
        else
        {
            url = p_Url;
        }

        //			url = url.ToLower();

        if (url.ToLower().IndexOf(".aspx") > -1 || url.ToLower().IndexOf(".html") > -1 || url.ToLower().IndexOf(".htm") > -1)
        {
            if (!url.Equals(""))
            {
                outputMsg.Append("var vUrl;\n");
                outputMsg.Append("var vParameters;\n");
                outputMsg.Append("vUrl = \"");
                outputMsg.Append(url);
                outputMsg.Append("\";\n");
                outputMsg.Append("vParameters = \"");
                outputMsg.Append(parameters);
                outputMsg.Append("\";\n");
                outputMsg.Append("vUrl += ");
                outputMsg.Append("encodeURIComponent(vParameters);\n");
                outputMsg.Append("\t\twindow.location.href = ");
                outputMsg.Append("vUrl;\n");
            }
        }
        else
        {
            outputMsg.Append(url);
        }

        outputMsg.Append("\t}\n");
        outputMsg.Append("</script>\n");

        Response.Clear();
        Response.Write(outputMsg.ToString());
    }

    /// <summary>
    ///妫€娴嬬櫥褰?
    /// </summary>
    private void CheckLogin()
    {
        if (Session["User"] == null)
        {
            ReLogin();
        }
        else
        {
            CheckRole();
        }
    }
    public Maticsoft.Model.Seller user
    {
        get { return (Maticsoft.Model.Seller)Session["User"]; }
    }
    private void CheckRole()
    {
        Maticsoft.Model.Seller muser = (Maticsoft.Model.Seller)Session["User"];
        mRole = muser.role_id.ToString();
        string mfile = GetFileName();
        //bool mIsAllowed=
        if (!Maticsoft.Utility.Utility.IsAllowedByUser(mfile, mRole))
        {
            string mstr = "";
            mstr += "<script  Language='JavaScript' >";
            mstr += " alert('此模块未授权，不能进入！');";
            mstr += "</script>";
            // Response.Charset = "UTF-8";
            Response.Clear();
            Response.Write(mstr);
            Response.End();

        }
    }
    private string GetFileName()
    {
        string mfile = "";
        string mpath = Request.Path;
        int i = mpath.LastIndexOf("/");
        if (i >= 0)
        {
            mfile = mpath.Substring(i + 1);
        }
        else
        {
            mfile = mpath;
        }

        return mfile;
    }

    /// <summary>
    ///
    /// </summary>
    ///

    /// <summary>
    /// 閲嶆柊鐧诲綍
    /// </summary>
    private void ReLogin()
    {
        string mstr = "";
        mstr += "<script  Language='JavaScript' >";
        mstr += " alert('未登陆或超时！请进入登陆页面');";
        mstr += "top.location.href='../aspx/login.aspx';";
        mstr += "</script>";
        Response.Clear();
        Response.Write(mstr);
        Response.End();

    }


    /// <summary>
    /// 鎵€鏈夐〉闈㈣姹傜殑鏌ヨ瀛楃涓?
    /// </summary>
    public Hashtable Parameters
    {
        get
        {
            return m_Parameters;
        }
    }



    protected override void OnLoad(System.EventArgs e)
    {
        base.OnLoad(e);

        Response.Expires = 0;
        Response.Cache.SetNoStore();
    }


    /// <summary>
    /// 鑾峰彇鏌愪竴URL鐨勭粷瀵硅矾寰?
    /// </summary>
    /// <param name="p_Url"></param>
    /// <returns></returns>
    public string GetAbsoultUrl(string p_Url)
    {
        string absoultUrl;

        absoultUrl = p_Url;

        if (absoultUrl != null && !absoultUrl.Equals(""))
        {
            if (!absoultUrl.StartsWith("/"))
            {
                absoultUrl = "/" + absoultUrl;
            }

            if (!absoultUrl.StartsWith(Request.ApplicationPath))
            {
                absoultUrl = Request.ApplicationPath + absoultUrl;
            }
        }

        return absoultUrl;
    }


    private string GoBackScript(int p_GoBackCount)
    {
        StringBuilder s_Script = new StringBuilder();

        s_Script.Append("window.top.goBack(-");
        s_Script.Append(p_GoBackCount.ToString());
        s_Script.Append(");");

 

        return s_Script.ToString();
    }


    /// <summary>
    /// 鑾峰彇椤甸潰杩斿洖鍔熻兘鑴氭湰
    /// </summary>
    /// <returns></returns>
    public string GetReturnScript()
    {
        //			string	returnScript;
        //			string	pageLoadCounter;
        //
        //			if(this.ViewState["PageLoadCounter"] == null)
        //			{
        //				pageLoadCounter = "0";
        //			}
        //			else
        //			{
        //				pageLoadCounter = this.ViewState["PageLoadCounter"].ToString();
        //			}
        //
        //			returnScript = "window.setTimeout(window.history.go(-";
        //			returnScript += (Convert.ToInt32(pageLoadCounter) + 1).ToString();
        //			returnScript += "),100);window.setTimeout(window.location.reload(),200);";
        //
        //			return returnScript;

        return GoBackScript(this.m_PageLoadCounter);
    }


    /// <summary>
    /// 鑾峰彇闈為〉闈㈡彁浜?棣栨瑁呰浇浣嗕互杈撳嚭鐨勬柟寮忚繑鍥?鐨勮繑鍥炲姛鑳借剼鏈?
    /// </summary>
    /// <returns></returns>
    public string GetNonPostBackReturnScript()
    {
        //			string	returnScript;
        //			string	pageLoadCounter;
        //
        //			if(this.ViewState["PageLoadCounter"] == null)
        //			{
        //				pageLoadCounter = "1";
        //			}
        //			else
        //			{
        //				pageLoadCounter = this.ViewState["PageLoadCounter"].ToString();
        //			}
        //
        //			returnScript = "window.setTimeout(window.history.go(-";
        //			returnScript += (Convert.ToInt32(pageLoadCounter) + 1).ToString();
        //			returnScript += "),100);window.setTimeout(window.location.reload(),200);";
        //
        //			return returnScript;

        return GoBackScript(this.m_PageLoadCounter);
    }


    /// <summary>
    /// 鑾峰彇椤甸潰鎻愪氦鍚庣殑杩斿洖鍔熻兘鑴氭湰
    /// </summary>
    /// <returns></returns>
    //		public string GetPostBackReturnScript()
    //		{
    //			string	returnScript;
    //			string	pageLoadCounter;
    //
    //			if(this.ViewState["PageLoadCounter"] == null)
    //			{
    //				pageLoadCounter = "1";
    //			}
    //			else
    //			{
    //				pageLoadCounter = this.ViewState["PageLoadCounter"].ToString();
    //			}
    //
    //			returnScript = "window.setTimeout(window.history.go(-";
    //			returnScript += pageLoadCounter;
    //			returnScript += "),100);window.setTimeout(window.location.reload(),200);";
    //
    //			return returnScript;
    //		}

    protected override object SaveViewState()
    {
        m_PageLoadCounter++;

        object baseState = base.SaveViewState();

        object[] CusStates = new object[2];
        CusStates[0] = baseState;
        CusStates[1] = m_PageLoadCounter;

        return CusStates;
    }

    protected override void LoadViewState(object savedState)
    {
        if (savedState != null)
        {
            object[] CusState = (object[])savedState;

            if (CusState[0] != null)
                base.LoadViewState(CusState[0]);
            if (CusState[1] != null)
                this.m_PageLoadCounter = (int)CusState[1];
        }
    }
    public string AllowedRole
    {
        get { return _AllowedRole; }
        set { _AllowedRole = value; }
    }
}