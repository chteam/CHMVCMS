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
	public partial class TemplateHelper
	{

		#region 分页
		public string Pager(int page, int everypage, int count)
		{
			count = (count + everypage) / everypage - 1;
			StringBuilder sb = new StringBuilder();
			var selecttemp = "<span class=\"this-page\">{0}</span>";
			var breaktemp = "<span class=\"break\">...</span>";
			var unselecttemp = "<a href=\"{0}.html\" title=\"第{0}页\" class=\"page-size{2}\">{1}</a>";
			if (page > 1)
			{
				if (page - 2 > 1)
				{
					sb.AppendFormat(unselecttemp, "1", "« 第一页", "");
					sb.Append(breaktemp);
				}
				sb.AppendFormat(unselecttemp, page - 1, "< 上一页", "");
			}

			for (int i = 2; i <= 6; i++)
			{
				if ((page + i - 4) >= 1 && (page + i - 4) <= count)
				{
					if (4 == i)
					{
						sb.AppendFormat(selecttemp, page);
					}
					else
					{
						sb.AppendFormat(unselecttemp, page + i - 4, page + i - 4, Math.Abs(i - 4));
					}
				}
			}
			if (page < count)
			{
				sb.AppendFormat(unselecttemp, 1 + page, "下一页 >", "");
				if (page + 2 < count)
				{
					sb.AppendFormat(breaktemp);
					sb.AppendFormat(unselecttemp, count, "最后页 »", "");

				}
			}
			return sb.ToString();
		}
		#endregion
	}
}
