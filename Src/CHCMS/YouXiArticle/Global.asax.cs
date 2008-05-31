using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace YouXiArticle
{
    public class GlobalApplication : System.Web.HttpApplication
    {
		public static void RegisterRoutes(RouteCollection routes)
		{
			// Note: Change the URL to "{controller}.mvc/{action}/{id}" to enable
			//       automatic support on IIS6 and IIS7 classic mode
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.MapRoute(
				"Article",
				"{NavType}/{id}.html",
				new { action = "Article", controller = "home", NavType = NavType.Article }
			);
			routes.MapRoute(
				"List",
				"{NavType}/{id}/{everypage}/{page}.html",
				new { action = "List", controller = "home", page = 1, everypage = 20, NavType = NavType.List }
			);

			routes.MapRoute(
				"Mvc",
				"{controller}/{action}/",
				new { action = "Index" }
			);

			routes.MapRoute(
				"Default",
				"Default.aspx",
				new { controller = "Home", action = "Index", id = "" }
			);
		}

        protected void Application_Start(object sender, EventArgs e)
        {
			VelocityTools.Init();
            RegisterRoutes(RouteTable.Routes);
        }
    }
}