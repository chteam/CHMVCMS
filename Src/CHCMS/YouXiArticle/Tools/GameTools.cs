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
using YouXiArticle.Models;

namespace YouXiArticle
{
	public class GameTools
	{
		static string path = "~/Game/{0}";
		static public bool Exists(string domain)
		{
			return System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(
				string.Format(path, domain)));
		}


		public static void CreateGameDictionarys(SiteInfo site)
		{
			
			Tools.IO.Dictionary.Copy(
				HttpContext.Current.Server.MapPath("~/Template"),
				HttpContext.Current.Server.MapPath(string.Format(path, site.Domain))
				);

			//string[] dirs = { "Template", "Old", "Style/Images", "Style/Css", "Config", "Backup" };
			//System.IO.Directory.CreateDirectory(
			//    tHttpContext.Current.Server.MapPah(string.Format(path, site.Domain, ""))
			//);
			//foreach (string s in dirs)
			//{
			//    System.IO.Directory.CreateDirectory(
			//    HttpContext.Current.Server.MapPath(string.Format(path, site.Domain, s))
			//);
			//}

		}
	}
}