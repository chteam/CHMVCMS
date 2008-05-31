using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouXiArticle.Models;

namespace YouXiArticle.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (this.SubDomain == "admin") {
                RedirectToAction("Login", "Admin");
            }
			SiteInfo si = DBExt.FindSiteInfo(this.SubDomain);
			ViewData["site"] = si;
            if (!GameTools.Exists(this.SubDomain)){
                return Content("无此站");
			}
            else{
				return Content(VelocityTools.GetTemplate(this.SubDomain, "index", ViewData));
			}
        }

		public ActionResult List(NavType navtype, long id, int page, int everypage)
		{
			//throw new Exception(navtype.ToString());
			if (this.SubDomain == "admin")
			{
				RedirectToAction("Login", "Admin");
			}

			if (!GameTools.Exists(this.SubDomain))
			{
				return Content("无此站");
			}
			Navigation si = DBExt.FindNavigation(id);
			ViewData["site"] = si.SiteSiteInfo;
			ViewData["nav"] = si;
			ViewData["page"] = page;
			ViewData["everypage"] = everypage;
			return Content(VelocityTools.GetTemplate(this.SubDomain, "list", ViewData));
		}

		public ActionResult Article(NavType navtype,long id)
        {
			if (this.SubDomain == "admin")
			{
				RedirectToAction("Login", "Admin");
			}
			if(navtype==NavType.List){
				return Content("错误的类型");
			}
			if (navtype == NavType.Article)
			{
				Article a = DBExt.FindArticle(id);

				ViewData["site"] = a.Navigation.SiteSiteInfo;
				ViewData["nav"] = a.Navigation;
				ViewData["content"] = a;
			}else{
				UrlAction u = DBExt.FindUrl(id);
				ViewData["site"] = u.Navigation.SiteSiteInfo;
				ViewData["nav"] = u.Navigation;
				ViewData["content"] = a;
			}
			if (!GameTools.Exists(this.SubDomain))
			{
				return Content("无此站");
			}
			else
			{
				return Content(VelocityTools.GetTemplate(this.SubDomain, "Article", ViewData));
			}
        }
    }
}
