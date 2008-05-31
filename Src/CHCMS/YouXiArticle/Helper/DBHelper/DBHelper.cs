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
using System.Collections.Generic;

namespace YouXiArticle
{
	public class DBHelper : BaseHelper
	{
		string _domain;

		public string Domain
		{
			get { return _domain; }
			set { _domain = value; }
		}
		public DBHelper(string domain)
		{
			this.Domain = domain;
		}
		public IList<Navigation> GetNavigations()
		{
			return DBExt.GetNavigations(this.Domain);
		}
	}
}
