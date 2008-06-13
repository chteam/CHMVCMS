using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using YouXiArticle.Models;
namespace TryIn
{
public	class InDB:ICommand
	{
	//string Title;
	public InDB(){
	//	Title = str.Trim();
	}
	#region ICommand 成员

		public void Execute()
		{
			StreamReader sr = new StreamReader("text\\page.txt");
			while (!sr.EndOfStream){
				string str = sr.ReadLine();
				string[] a = str.Split(' ');
				if (a.Length < 2) continue;
				string title = str.TrimStart(a[0].ToCharArray()).Trim();
				SiteInfo si =new SiteInfo();
				Console.WriteLine(title);
				Console.WriteLine(Tools.GetPYString(title));

				si.Domain=Tools.GetPYString(title);
				si.Letter = (si.Domain != null && si.Domain.Length > 1) ? si.Domain[0].ToString().ToUpper() : "";
				si.Title = title;
				si.StylePath = si.Domain;
				Tools.DB.SiteInfo.InsertOnSubmit(si);
			}
			Tools.DB.SubmitChanges();
			Console.WriteLine("Over");
		}

		#endregion
	}
}
