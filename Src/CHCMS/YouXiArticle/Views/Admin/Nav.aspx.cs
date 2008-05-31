using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouXiArticle.Models;
using YouXiArticle.Controllers;
namespace YouXiArticle.Views.Admin
{
	public partial class AddNav : ViewPage<SiteInfo>
	{
		public string getM(object ntin, long id)
		{
			//throw new Exception(ntin.ToString());
			int nt = int.Parse(ntin.ToString());
			string ret = "";
			if (nt == (int)NavType.Article || nt == (int)NavType.List)
				ret = Html.ActionLink<AdminController>(c => c.Article(id, 0), "文本");
			if (nt != (int)NavType.Article)
				ret += " " + Html.ActionLink<AdminController>(c => c.Url(id, 0), "Url");
			return ret;
		}
	}
}
