namespace System.Web
{
	static public class HttpRequestExt
	{
		public static long QueryLong(this HttpRequest request,string key){
			long ret = 0;
			long.TryParse(request.QueryString[key], out ret);
			return ret;
		}
	}
}
