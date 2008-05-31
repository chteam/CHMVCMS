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
using System.Text;

namespace YouXiArticle
{
	public partial class TemplateHelper : BaseHelper
	{
		#region 初始化
		public string Domain{get;set;}
		public NavType Navtype { get; set; }
		public TemplateHelper(string domain){
			this.Domain = domain;
			this.Navtype = NavType.List;
		}
		public TemplateHelper(string domain,NavType navtype)
		{
			this.Domain = domain;
			this.Navtype = navtype;
		}
		#endregion

	

	
		#region private
		/// <summary>
		/// 检测文件是否存在
		/// </summary>
		/// <param name="ph">文件的URL相对路径</param>
		/// <returns></returns>
		bool FileExists(string ph){
			return System.IO.File.Exists(HttpContext.Current.Server.MapPath(ph));
		}
		/// <summary>
		/// 获取列表的模板有,先从List文件夹扫描,没有再找根目录
		/// </summary>
		/// <param name="d">要传入模板的Data</param>
		/// <param name="temp">模板页</param>
		/// <returns></returns>
		string GetListTemplate(Dictionary d, string temp)
		{
			if (!string.IsNullOrEmpty(temp))
			{
				temp = temp.ToLower().TrimEnd(".vm".ToCharArray());
				if (FileExists(String.Format("~/Game/{0}/Template/List/{1}.vm", this.Domain, temp)))
				{
					temp = "List/" + temp;

				}
				else if (FileExists(String.Format("~/Game/{0}/Template/{1}.vm", this.Domain, temp))) {}
				else{
					temp = "List/" + NavType.List.ToString();
				}
			}
			else
			{
				Navigation nav = (d["nav"] as Navigation);
				NavType nt = (NavType)nav.NavType;
				temp = "List/" +nt.ToString();
			}
			return VelocityTools.GetTemplate(this.Domain, temp, d);
		}
		#endregion

	}
}
