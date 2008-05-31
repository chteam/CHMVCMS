using System.Collections.Generic;
using System;

namespace YouXiArticle
{
	public class Dictionary : Dictionary<string, object>,IDictionary<string,object>
	{	/// <summary>
		/// 将数组参数转为Dictionary
		/// 例如："username","dudu","passwor",123456
		/// 则转为具有username和password两个键值的Dictionary
		/// </summary>
		/// <param name="args">要转为Dictionary的数组，要偶数个</param>
		/// <returns>Dictionary</returns>
		public static Dictionary CreateFromArgs(params object[] args)
		{
			if (args.Length % 2 != 0)
				throw new Exception("不可以有奇数个传入数据");
			Dictionary dict = new Dictionary();
			for (int i = 0; i < args.Length; i += 2)
			{
				dict.Add(args[i].ToString(), args[i + 1]);
			}
			return dict;
		}
	}
}
