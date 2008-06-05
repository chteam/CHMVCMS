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
		 		#region SiteInfo

		public string SiteSummary(SiteInfo si, string temp)
		{
			return VelocityTools.GetTemplate(this.Domain, temp,
				"site", si

				);
		}
		#endregion
	}
}
