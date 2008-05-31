using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouXiArticle.Models;
using LinqToSqlExtensions;
namespace YouXiArticle.Controllers
{
    public class AdminController : DataController
    {
        public ActionResult Login()
        {
			return View();
        }
        #region Site
        [ActionMenu(Title="添加子站")]
        public ActionResult AddSite()
        {
			return View();
        }
		[ActionMenu(Title = "管理子站")]
		public ActionResult SiteList()
		{
			//RenderView("SiteList");
			return View();
		}

	
        public void AddSitePost()
        {
            SiteInfo si = new SiteInfo();
            BindingHelperExtensions.UpdateFrom(si, Request.Form);
            this.DataContext.SiteInfo.InsertOnSubmit(si);
            this.DataContext.SubmitChanges();
			GameTools.CreateGameDictionarys(si);
            TempData["msg"] = "添加成功";
			this.RedirectToReferrer();
        }
        public void DeleteSite(string ID) {
            long i = 0;
            if (!long.TryParse(ID.Trim(), out i))
            {
                TempData["msg"] = "删除不成功，ID不符合规范" + "[" + Request.Url.ToString() + "]" + ID;
                this.RedirectToReferrer();
            }
            this.DataContext.SiteInfo.Delete(c => c.ID == i);
            this.RedirectToReferrer();
        }
        #endregion


		#region Nav
		public ActionResult Nav(long SiteID, long ModifyID)
		{
			var x = (from n in this.DataContext.SiteInfo
					 where n.ID == SiteID
					 select n).SingleOrDefault();
			ViewData["SiteID"] = SiteID;
			if (ModifyID == 0)
			{
				NavType nt = new NavType();
				ViewData["NavType"] = new SelectList(nt.ToListItem(), "Value", "Text");
			}
			else
			{
				var u = DBExt.FindNavigation(ModifyID);
				ViewData["Title"] = u.Title;
				ViewData["Url"] = u.Url;
				NavType nt = new NavType();
				ViewData["NavType"] = new SelectList(nt.ToListItem(), "Value", "Text", u.NavType);
			}

			//this.HttpContext.Application["AdminTrubo"]
			AdminTrubo.Add(x.Title, x.ID);
			return View(x);
		}
		public void AddNav(long id)
		{
			Navigation n = new Navigation();
			BindingHelperExtensions.UpdateFrom(n, Request.Form);
			if (id == 0)
			{
				this.DataContext.Navigation.InsertOnSubmit(n);
				this.DataContext.SubmitChanges();
			}
			else
			{
				n.ID = id;
				DBExt.UploadNavigation(n);
			}
			TempData["msg"] = "成功";
			this.RedirectToReferrer();
		}
		public void DeleteNav(long id)
		{
			this.DataContext.Navigation.Delete(c => c.ID == id);
			this.RedirectToReferrer();
		}
		#endregion

		#region Article
		public ActionResult Article(long id, long ModifyID)
		{
			var x = DBExt.FindNavigation(id);
			ViewData["Body"] = "";
			if (ModifyID != 0)
			{
				var a = DBExt.FindArticle(ModifyID);
				ViewData["Title"] = a.Title;
				ViewData["Body"] = a.Body;
				ViewData["Author"] = a.Author;
			}
			ViewData["NavigationID"] = x.ID;
			return View(x);
		}
		public void AddArticle(long ModifyID)
		{
			Article n = new Article();
			
			BindingHelperExtensions.UpdateFrom(n, Request.Form);
			//throw new Exception(n.Title);
			if (ModifyID == 0)
			{
				n.AddTime = DateTime.Now;
				this.DataContext.Article.InsertOnSubmit(n);
				this.DataContext.SubmitChanges();
			}
			else {
				n.ID = ModifyID;
				DBExt.UpdateArticle(n);
			}
			TempData["msg"] = "添加成功";
			this.RedirectToReferrer();
		}
		public void DelArticle(long id) {
			this.DataContext.Article.Delete(c => c.ID == id);
			this.RedirectToReferrer();
		}

		#endregion

		#region Url
		public ActionResult Url(long id,long ModifyID)
		{
			var x = DBExt.FindNavigation(id);
			if (ModifyID != 0)
			{
				var a = DBExt.FindUrl(ModifyID);
				ViewData["Title"] = a.Title;
				ViewData["Url"] = a.Url;
				ViewData["Author"] = a.Author;
			}
			ViewData["NavigationID"] = x.ID;
			return View(x);
		}
		public void AddUrl(long ModifyID)
		{
			UrlAction n = new UrlAction();
			BindingHelperExtensions.UpdateFrom(n, Request.Form);
			if (ModifyID == 0)
			{
				n.AddTime = DateTime.Now;

				this.DataContext.UrlAction.InsertOnSubmit(n);
				this.DataContext.SubmitChanges();
			}
			else
			{
				n.ID = ModifyID;
				DBExt.UpdateUrl(n);
			}
			TempData["msg"] = "添加成功";
			this.RedirectToReferrer();
		}
		public void DelUrl(long id)
		{
			this.DataContext.UrlAction.Delete(c => c.ID == id);
			this.RedirectToReferrer();
		}

		#endregion
	}
}
