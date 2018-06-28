using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///ActionFactroy 的摘要说明
/// </summary>
public class ActionFactroy
{
	public ActionFactroy()
	{

	}
    public static ActionFace createAction(string entity) {
        ActionFace Action = null;

        if (entity.ToUpper() == "menu".ToUpper())
        {
           Action = new MenuAction();

        }
     
        else if(entity.ToUpper()=="order".ToUpper())
        {
            Action = new OrderAction();
        }

        else if (entity.ToUpper() == "user".ToUpper())
        {
            Action = new UserAction();
        }

        else if (entity.ToUpper() == "common".ToUpper())
        {
            Action = new CommonAction();
        }
		
        return Action;
    }
}