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

		#region Urlarticle
		/// <summary>
		/// 获取URL与文章混合列表,默认以List/List为模板
		/// </summary>
		/// <param name="navid">栏目ID</param>
		/// <param name="page">页码</param>
		/// <param name="everypage">一页几条</param>
		/// <returns></returns>
		public string UrlArticles(long navid, int page, int everypage)
		{
			return UrlArticles(navid, null, page, everypage);
		}
		/// <summary>
		/// 获取URL与文章混合列表
		/// </summary>
		/// <param name="navid">栏目ID</param>
		/// <param name="temp">模板</param>
		/// <returns></returns>
		public string UrlArticles(long navid, string temp)
		{
			return UrlArticles(navid, temp, 1, 20);
		}
		/// <summary>
		/// 获取URL与文章混合列表
		/// </summary>
		/// <param name="navid">栏目ID</param>
		/// <param name="temp">模板</param>
		/// <param name="top">要提取前几条</param>
		/// <returns></returns>
		public string UrlArticles(long navid, string temp, int top)
		{
			return UrlArticles(navid, temp, 1, top);
		}
		/// <summary>
		/// 获取URL与文章混合列表
		/// </summary>
		/// <param name="navid">栏目ID</param>
		/// <param name="temp">模板</param>
		/// <param name="page">页码</param>
		/// <param name="everypage">页容量</param>
		/// <returns></returns>
		public string UrlArticles(long navid, string temp, int page, int everypage)
		{
			if (temp == null) temp = string.Format("List/{0}", navid);
			Dictionary d = new Dictionary();
			var x = DBExt.GetUrlArticles(navid);
			d.Add("count", x.Count);
			d.Add("page", page);
			d.Add("everypage", everypage);
			var x1 = x.Skip((page - 1) * everypage).Take(everypage);
			d.Add("list", x1);
			d.Add("nav", DBExt.FindNavigation(navid));
			return GetListTemplate(d, temp);
		}
		#endregion
	}
}
