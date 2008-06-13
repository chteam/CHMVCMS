using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TryIn
{
	public class Command
	{
		ICommand ICommand;
		public Command(string str){
			CommandText = str;
			string[] a=str.Split(' ' );
			if(a.Length<1) throw new Exception("不配");
			switch(a[0]){
				case "getpage":
					ICommand = new GetPage("");
					break;
				case "indb":
					ICommand = new InDB();
					break;
				default:break;
			}
		}
		public string CommandText { get; set; }
		public void Execute(){
			ICommand.Execute();
			
		}
	}
}
