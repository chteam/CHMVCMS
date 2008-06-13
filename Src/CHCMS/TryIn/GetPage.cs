using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace TryIn
{
public 	class GetPage:ICommand
	{
	string Param;
	public GetPage(string p)
	{
		Param = p;
	}
		#region ICommand 成员

		public void Execute()
		{
			StreamReader sr = new StreamReader("text\\page.txt");
			//Console.Write(sr.ReadToEnd());
			while (!sr.EndOfStream){
				//Console.WriteLine();
				string str = sr.ReadLine();
			//	Console.Write(str+ "|");
				string[] a = str.Split(' ');
				//Console.Write(a.Length);
				if (a.Length < 2) continue;
			
					new GetUrl(a[0], a[1]).Execute();
				
	
			}
		}

		#endregion
	}
}
