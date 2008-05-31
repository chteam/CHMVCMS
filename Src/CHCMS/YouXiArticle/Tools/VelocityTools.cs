using System.Collections.Generic;
using System.IO;
using System.Web;
using Commons.Collections;
using NVelocity;
using NVelocity.App;
using System;

namespace YouXiArticle
{
	public class VelocityTools
	{
		static Dictionary<string, VelocityEngine> _dict = new Dictionary<string, VelocityEngine>();
		/// <summary>
		/// Velocity的全局引擎表
		/// </summary>
		static public Dictionary<string, VelocityEngine> VelocityDict
		{
			get { return _dict; }
			set { _dict = value; }
		}
		/// <summary>
		/// 全部进行初始化
		/// </summary>
		static public void Init()
		{
			VelocityTools.VelocityDict.Clear();
			foreach (string s in System.IO.Directory.GetDirectories(HttpContext.Current.Server.MapPath("~/Game/")))
			{
				string str = System.IO.Path.GetFileName(s);
				VelocityDict.Add(str, VelocityTools.CreateVelocity(str));
			}
		}
		/// <summary>
		/// 初始化某一Velocity引擎
		/// </summary>
		/// <param name="Domain">要初始化的域</param>
		/// <returns></returns>
		static public VelocityEngine CreateVelocity(string Domain)
		{
			string path = HttpContext.Current.Server.MapPath(string.Format("~/Game/{0}/Template", Domain));
			ExtendedProperties props = new ExtendedProperties();
			props.AddProperty("file.resource.loader.path", path);
			props.AddProperty("input.encoding", "utf-8");
			props.AddProperty("output.encoding", "utf-8");
			VelocityEngine velocity = new VelocityEngine();
			velocity.Init(props);
			return velocity;
		}
		/// <summary>
		/// 模板解释器
		/// </summary>
		/// <param name="Domain">域名</param>
		/// <param name="fn">模板文件</param>
		/// <param name="parames">参数,可以以'键,值,键,值...'的形式写入</param>
		/// <returns></returns>
		static public string GetTemplate(string Domain, string fn, params object[] parames) {
			return GetTemplate(Domain, fn, Dictionary.CreateFromArgs(parames));
		}
		/// <summary>
		/// 模板解释器
		/// </summary>
		/// <param name="Domain">要解释的域名</param>
		/// <param name="fn">模板文件</param>
		/// <param name="param">参数</param>
		/// <returns></returns>
		static public string GetTemplate(string Domain, string fn, IDictionary<string, object> param)
		{
			VelocityContext context = new VelocityContext();
			//if(param !=null)
			foreach (string key in param.Keys)
			{
				context.Put(key, param[key]);
			}
			context.Put("DB", new DBHelper(Domain));
			context.Put("T", new TemplateHelper(Domain));
			context.Put("Url", new UrlHelper(Domain));
			StringWriter writer = new StringWriter();
			//try
			//{
				Template template = VelocityTools.VelocityDict[Domain].GetTemplate(string.Format("{0}.vm", fn));
				if (template != null)
				{
					template.Merge(context, writer);
				}
				return writer.GetStringBuilder().ToString();
			//}catch(Exception e){
			//    return string.Format("模板引擎对'{0}'解释错误:{1}", fn, e.Message);
			//}
		}
	}
}
