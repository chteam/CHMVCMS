using System.Linq;
using System.Collections.Generic;
using System;

namespace YouXiArticle.Models
{
	public class DBExt
	{
#region init
		public ArticleDataContext DB { get; set; }
		public DBExt()
		{
			DB = new ArticleDataContext();
		}
		public DBExt(ArticleDataContext db)
		{
			DB = db;
		}
#endregion
		public SiteInfo FindSiteInfo(string domain)
		{
			return (from s in DB.SiteInfo
					where s.Domain == domain
					select s).SingleOrDefault();
		}
		public IList<Navigation> GetNavigations(string domain)
		{
			return (from n in DB.Navigation
					join s in DB.SiteInfo on n.SiteID equals s.ID
					where s.Domain == domain
					select n).ToList<Navigation>();
		}
		public void UploadNavigation(Navigation n)
		{

			var x = FindNavigation(n.ID);
			x.NavType = n.NavType;
			x.Title = n.Title;
			x.Url = n.Url;
			x.HasUrl = n.HasUrl;
			x.HasArticle = n.HasArticle;
			DB.SubmitChanges();
		}
		public Navigation FindNavigation(long id)
		{

			return (from s in DB.SiteInfo
					join n in DB.Navigation on s.ID equals n.SiteID
					where n.ID == id
					select n).SingleOrDefault();
		}
		public void UpdateArticle(Article a){
			
			var x = FindArticle(a.ID);
			//if(x==null)throw new Exception(a.Title);;
			x.Title = a.Title;
			x.Body = a.Body;
			x.Author = a.Author;
			DB.SubmitChanges();
		}
		public Article FindArticle(long id)
		{
			var r = (from s in DB.SiteInfo
					 join n in DB.Navigation on s.ID equals n.SiteID
					 join a in DB.Article on n.ID equals a.NavigationID
					 where a.ID == id
					 select a).SingleOrDefault();
			r.Hits++;
			DB.SubmitChanges();
			return r;
		}

		public UrlAction FindUrl(long id){
			var r= (from s in DB.SiteInfo
					join n in DB.Navigation on s.ID equals n.SiteID
					join a in DB.UrlAction on n.ID equals a.NavigationID
					where a.ID == id
					select a).SingleOrDefault();
			r.Hits++;
			DB.SubmitChanges();
			return r;
		}
		public IList<CommonArticle> GetArticles(Navigation nav)
		{
			return GetArticles(nav.ID);
		}

		public IList<CommonArticle> GetArticles(long navid)
		{

			return (from a in DB.Article
					where a.NavigationID == navid
					orderby a.ID descending
					select new CommonArticle()
					{
						Addtime = a.AddTime,
						Body = a.Body,
						Author = a.Author,
						IsUrl = false,
						Type = 0,
						Title = a.Title,
						ID = a.ID
					}).ToList<CommonArticle>();
		}
		public IList<CommonArticle> GetUrlArticles(Navigation nav)
		{
			return GetUrlArticles(nav.ID);
		}
		public IList<CommonArticle> GetUrlArticles(long navid)
		{

			return (from a in DB.UrlAction
					where a.NavigationID == navid
					orderby a.ID descending
					select new CommonArticle()
					{
						ID = a.ID,
						Addtime = a.AddTime,
						Body = a.Url,
						Author = a.Author,
						Title = a.Title,
						Type = 1,
						IsUrl = true
					}).Union(
					 (from a in DB.Article
					  where a.NavigationID == navid
					  orderby a.ID descending
					  select new CommonArticle()
					  {
						  Addtime = a.AddTime,
						  Body = a.Body,
						  IsUrl = false,
						  Author = a.Author,
						  Type = 0,
						  Title = a.Title,
						  ID = a.ID
					  })
					 ).ToList<CommonArticle>();
		}
		public IList<CommonArticle> GetUrlActions(Navigation nav)
		{
			return GetUrlActions(nav.ID);
		}

		public IList<CommonArticle> GetUrlActions(long navid)
		{

			return (from a in DB.UrlAction
					where a.NavigationID == navid
					orderby a.ID descending
					select new CommonArticle()
					{
						ID = a.ID,
						Author = a.Author,
						Addtime = a.AddTime,
						Body = a.Url,
						Title = a.Title,
						Type = 1,
						IsUrl = true
					}).ToList<CommonArticle>();
		}

		public void UpdateUrl(UrlAction n)
		{
			var x = FindUrl(n.ID);
			//if(x==null)throw new Exception(a.Title);;
			x.Title = n.Title;
			x.Url = n.Url;
			x.Author = n.Author;
			DB.SubmitChanges();
		}
	}
}
