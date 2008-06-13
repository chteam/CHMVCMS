using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TryIn
{
	class Program
	{
		static void Main(string[] args)
		{
			while(true){
				try
				{
					string cmd = Console.ReadLine();
					if (cmd.ToLower() == "exit") break;
					Command cd = new Command(cmd);
					cd.Execute();
				}catch(Exception e){
					Console.WriteLine(e.Message);
				}
			}
		}
	}
}
