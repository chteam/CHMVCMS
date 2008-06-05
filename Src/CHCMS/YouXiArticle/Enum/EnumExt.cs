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
using System.Collections.Generic;

namespace YouXiArticle
{
	static public class EnumExt
	{
		public static string GetName(this Enum en,int val)
		{
			return Enum.GetName(en.GetType(), val);
		}
		public static string GetName(this Enum en){
			return Enum.GetName(en.GetType(), en);
		}
		public static IList<ListItem> ToListItem(this Enum en1)
		{
			
			List<ListItem> li = new List<ListItem>();
			foreach (int s in Enum.GetValues(en1.GetType()))
			{
				li.Add(new ListItem(Enum.GetName(en1.GetType(), s), s.ToString()));
			}
			return li;
		}
	}
}
