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

namespace YouXiArticle
{
	static public class HttpRequestExt
	{
		public static long QueryLong(this HttpRequest request,string key){
			long ret = 0;
			long.TryParse(request.QueryString[key], out ret);
			return ret;
		}
	}
}
