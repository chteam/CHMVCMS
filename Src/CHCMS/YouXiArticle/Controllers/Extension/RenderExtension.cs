namespace System.Web.Mvc
{
	using System;
	using System.Text;
	using System.Web.Script.Serialization;
	using System.Runtime.Serialization.Json;
	/// <summary>
	/// 对RenderView的扩展
	/// blog:http://chsword.cnblogs.com/
	/// </summary>
	static public class RenderExtension
	{
		/// <summary>
		/// 显示要显示的文本
		/// </summary>
		/// <param name="c"></param>
		/// <param name="str">文本内容</param>
		[Obsolete("仅在Asp.net Mvc Preview2中使用,PV3中已经提供新的方法Content")]
		static public void RenderText(this Controller c, string str)
		{
			c.HttpContext.Response.Write(str);
		}
		/// <summary>
		/// 将要显示的对象以JSON返回要客户端
		/// </summary>
		/// <param name="c"></param>
		/// <param name="data">要发送的对象</param>
		[Obsolete("仅在Asp.net Mvc Preview2中使用,PV3中已经提供新的方法Json")]
		public static void RenderJSON(this Controller c, object data)
		{
			c.RenderJSON(data, null);
		}
		/// <summary>
		/// 将要显示的对象以JSON返回要客户端
		/// </summary>
		/// <param name="c"></param>
		/// <param name="data">要发送的对象</param>
		/// <param name="contenttype">传送的Content-Type默认为application/json</param>
		[Obsolete("仅在Asp.net Mvc Preview2中使用,PV3中已经提供新的方法Json")]
		public static void RenderJSON(this Controller c, object data, string contenttype)
		{
			c.RenderJSON(data, contenttype, null);
		}
		/// <summary>
		/// 将要显示的对象以JSON返回要客户端
		/// </summary>
		/// <param name="c"></param>
		/// <param name="data">要发送的对象</param>
		/// <param name="contenttype">传送的Content-Type为空则默认为application/json</param>
		/// <param name="encoding">编码方式</param>
		[Obsolete("仅在Asp.net Mvc Preview2中使用,PV3中已经提供新的方法Json")]
		public static void RenderJSON(this Controller c, object data, string contenttype, Encoding encoding)
		{
			HttpResponseBase response = c.HttpContext.Response;
			if (!string.IsNullOrEmpty(contenttype))
			{
				response.ContentType = contenttype;
			}
			else
			{
				response.ContentType = "application/json";
			}
			if (encoding != null)
			{
				response.ContentEncoding = encoding;
			}
			if (data != null)
			{
				DataContractJsonSerializer sr = new DataContractJsonSerializer(typeof(object));
				sr.WriteObject(response.OutputStream, data);
			}
		}
	}
}
