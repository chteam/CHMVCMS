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

namespace System.Web.Mvc
{
	static public class FckTextBoxExt
	{
		public static string FckTextBox(this HtmlHelper u, string name)
		{
			return u.FckTextBox(name, "");
		}
		public static string FckTextBox(this HtmlHelper u, string name,object text){

			return u.FckTextBox(name, text.ToString());
		}
		public static string FckTextBox(this HtmlHelper u, string name,string text)
		{
			return string.Format(@"<textarea name=""{0}"" id=""{0}"" rows=""10"" cols=""80"" style=""width:100%; height: 200px"">{1}</textarea>
<script type=""text/javascript"">
	var oFCKeditor = new FCKeditor('{0}') ;
	//oFCKeditor.BasePath	= sBasePath ;
	oFCKeditor.ReplaceTextarea() ;
</script>
", name, text);

		}
	}
}