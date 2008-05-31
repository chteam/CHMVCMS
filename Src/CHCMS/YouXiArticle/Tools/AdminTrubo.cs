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
using System.Collections;
using System.Collections.Generic;

namespace YouXiArticle
{
	public class AdminTrubo : Queue<Pair>
	{
		static string APPNAME = "AdminTrubo";
		public static void Add(string key,long value){
			
			Pair pr = new Pair();
			pr.First = key;
			pr.Second = value;
			var r=(from x in AdminTrubo.Current
					   where x.First.ToString()==key
					   select x).SingleOrDefault();
			if (r != null) return;
			AdminTrubo.Current.Enqueue(pr);
			while(AdminTrubo.Current.Count>10)
				AdminTrubo.Current.Dequeue();
		}
		public static void Remove(){
			AdminTrubo.Current.Dequeue();
		}
		public static Queue<Pair> Current{
			get{
				if(HttpContext.Current.Application[APPNAME]==null)
				{
					Queue<Pair> qu = new Queue<Pair>();
					HttpContext.Current.Application.Lock();
					HttpContext.Current.Application[APPNAME] = qu;
					HttpContext.Current.Application.UnLock();
				}
				return HttpContext.Current.Application[APPNAME] as Queue<Pair>;
			}
		}
	}
}
