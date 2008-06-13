using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouXiArticle.Models;
using YouXiArticle;

namespace TryIn
{
	public class GetUrl:ICommand
	{
		string url;
		string Title;
		public GetUrl(string page,string title){
			url = page;
			Title = title;
		}
		#region ICommand 成员

		public void Execute()
		{
			HttpProc p = new HttpProc(url);
			string html = p.Proc();
			if (html.Contains(
				"您访问的页面错误或者已经不"
				))
			{
				Console.WriteLine("不可访问");
				return;

			}
			try
			{
				string t=Tools.GetReg("<div class=\"g10\">([^<]*)", html);
				int gt = (int)Enum.Parse(typeof(GameType), Tools.GetReg("leixing=([^\"]+)", html));
				int tc = (int)Enum.Parse(typeof(GameStory), Tools.GetReg("ticai=([^\"]+)", html));
				int zt = (int)Enum.Parse(typeof(GameStatus), Tools.GetReg("zhuangtai=([^\"]+)", html));
				int dq = (int)Enum.Parse(typeof(GameArea), Tools.GetReg("diqu=([^\"]+)", html));
				int hm = (int)Enum.Parse(typeof(GameView), Tools.GetReg("huamian=([^\"]+)", html) == "3D" ? "三维" : "二维");
				DateTime dt = DateTime.Now;
				string dts=Tools.GetReg("上市日期：([^<]+)</", html);
				DateTime.TryParse(dts, out dt);
		

				var s = (from i in Tools.DB.SiteInfo
						 where i.Title == t.Trim()
						 select i
						).SingleOrDefault();

				s.GameType = gt;
				s.GameStory = tc;
				s.GameStatus = zt;
				s.Developer = Tools.GetReg("开发公司：([^<]+)</", html);
				s.RunCompany = Tools.GetReg("gongsi=([^\"]+)", html);
				//s.TestTime = dt;
				s.GameView = hm;
				Tools.DB.SubmitChanges();
				Console.WriteLine("成功:" + Title);
				//			Console.ReadKey();
			}
			catch(Exception e)
			{
				Console.WriteLine("Error:" + Title + "[" + e.Message + "]");
			}
			Console.WriteLine("===========");
			
		}

		#endregion
	}
}
