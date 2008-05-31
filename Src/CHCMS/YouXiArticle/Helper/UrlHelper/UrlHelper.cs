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
using System.Web.Routing;
using System.Web.Mvc;
using YouXiArticle.Models;

namespace YouXiArticle
{
	public class UrlHelper : BaseHelper
	{
		static string root="http://{0}.chs/{1}";
		//System.Web.Mvc.UrlHelper _MvcHelper =new System.Web.Mvc.UrlHelper(new System.Web.Mvc.ViewContext(
		public string Domain { get; set; }
		public UrlHelper(string domain) { this.Domain = domain; }
		#region List
		public string List(long id,NavType nt, int page, int everypage){
			return string.Format(
				root,
				this.Domain,
				string.Format("{3}/{0}/{1}/{2}.html",
				id, everypage, page, Enum.GetName(nt.GetType(), nt)));
		}
		public string List(Navigation nav, int page, int everypage)
		{
			return string.Format(
				root, 
				this.Domain, 
				string.Format("{3}/{0}/{1}/{2}.html", nav.ID, everypage, page,Enum.GetName(typeof(NavType) ,nav.NavType)));
		}
		public string List(long id,NavType nt) {
			return List(id,nt, 1, 20);
		}
		public string List(Navigation nav){
			return List(nav, 1, 20);
		}
		public string List(Navigation nav, int page)
		{
			return List(nav, page, 20);
		}

		public string List(long id,NavType nt, int page)
		{
			return List(id,nt, page, 20);
		}
		#endregion
		public string Article(long id) {
			return string.Format(root, this.Domain, "Article/" + id + ".html");
		}
	}
}
