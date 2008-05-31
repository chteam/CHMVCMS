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
	public partial class TemplateHelper
	{
		#region 导航
		public string Navigations(string temp)
		{
			var x = (from n in this.DataContext.Navigation
					 where n.SiteSiteInfo.Domain == Domain
					 select n).ToList();
			Dictionary d = new Dictionary();
			d.Add("ds", x);
			return VelocityTools.GetTemplate(this.Domain, temp, d);
		}
		#endregion
	}
}
