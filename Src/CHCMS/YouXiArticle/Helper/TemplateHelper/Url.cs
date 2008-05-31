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
		#region UrlAction
		/// <summary>
		/// 获取指定的URL列表
		/// </summary>
		/// <param name="navid">栏目ID</param>
		/// <param name="temp">模板</param>
		/// <param name="top">要提取的条数</param>
		/// <returns></returns>
		public string UrlActions(long navid, string temp, int top)
		{
			return UrlActions(navid, temp, 1, top);
		}
		/// <summary>
		/// 获取指定的URL列表,前20
		/// </summary>
		/// <param name="navid">栏目ID</param>
		/// <param name="temp">模板</param>
		/// <returns></returns>
		public string UrlActions(long navid, string temp)
		{
			return UrlActions(navid, temp, 1, 20);
		}
		/// <summary>
		/// 获取指定URL列表
		/// </summary>
		/// <param name="navid">栏目ID</param>
		/// <param name="temp">模板</param>
		/// <param name="page">要提取的页码</param>
		/// <param name="everypage">一页几个</param>
		/// <returns></returns>
		public string UrlActions(long navid, string temp, int page, int everypage)
		{
			if (temp == null) temp = string.Format("List/{0}", navid);
			var x = DBExt.GetUrlActions(navid);
			Dictionary d = new Dictionary();
			d.Add("count", x.Count);
			d.Add("page", page);
			d.Add("everypage", everypage);
			var x1 = x.Skip((page - 1) * everypage).Take(everypage);
			d.Add("list", x1);
			//	d.Add("nav", nav);
			return GetListTemplate(d, temp);
		}
		#endregion
	}
}
