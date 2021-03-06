﻿using System;
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
		 		#region article
		/// <summary>
		/// 获取特定分类的文本文章列表
		/// </summary>
		/// <param name="navid">栏目分类ID</param>
		/// <param name="temp">要使用的模板</param>
		/// <param name="top">提出前N条</param>
		/// <returns>文章列表</returns>
		public string Articles(long navid,string temp ,int top){
			return Articles(navid, temp, 1, top);
		}
		/// <summary>
		/// 获取特定分类前20条记录
		/// </summary>
		/// <param name="navid">栏目分类ID</param>
		/// <param name="temp">要使用的模板</param>
		/// <returns></returns>
		public string Articles(long navid, string temp)
		{
			return Articles(navid, temp, 1, 20);
		}
		/// <summary>
		/// 获取特定分类中某一页
		/// </summary>
		/// <param name="navid">栏目分类ID</param>
		/// <param name="temp">模板</param>
		/// <param name="page">要获取的页码</param>
		/// <param name="everypage">每页几条信息</param>
		/// <returns></returns>
		public string Articles(long navid, string temp, int page, int everypage)
		{
			////if (temp == null) temp = string.Format("List/{0}", navid);
			var x = DBExt.GetArticles(navid);
			Dictionary d = new Dictionary();
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
