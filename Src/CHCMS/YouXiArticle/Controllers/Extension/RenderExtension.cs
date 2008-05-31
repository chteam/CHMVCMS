using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Mvc;

namespace YouXiArticle.Controllers
{
	static public class RenderExtension
	{
		static public void RenderText(this Controller c,string str){
			c.HttpContext.Response.Write(str);
		}
	}
}
