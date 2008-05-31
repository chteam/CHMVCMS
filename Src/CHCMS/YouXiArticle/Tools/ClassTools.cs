using System;
using System.Collections.Generic;
using System.Reflection;

namespace YouXiArticle
{
	public class ClassTools
	{
		public static Dictionary GetActionMenu(Type t)
		{
			Dictionary ret = new Dictionary();
			MethodInfo[] mis = t.GetMethods(BindingFlags.DeclaredOnly
			  | BindingFlags.InvokeMethod
			  | BindingFlags.Instance
			  | BindingFlags.Public);
			foreach (MethodInfo i in mis)
			{
				ActionMenuAttribute[] am = (ActionMenuAttribute[])(
					i.GetCustomAttributes(
						typeof(YouXiArticle.ActionMenuAttribute), false));
				if (am.Length != 0)
				{
					ret.Add(i.Name, am[0].Title);

				}
			}
			return ret;
		}
	}
}
