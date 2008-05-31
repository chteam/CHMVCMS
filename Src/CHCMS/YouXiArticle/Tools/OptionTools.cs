namespace YouXiArticle
{
	public class OptionTools
	{
		static public Dictionary HasArticle {
			get
			{
				Dictionary d = new Dictionary();
				d.Add("true", "有");
				d.Add("false", "没有");
				return d;
			}
		}
		static public Dictionary HasUrl
		{
			get
			{
				Dictionary d = new Dictionary();
				d.Add("true", "有");
				d.Add("false", "没有");
				return d;
			}
		}
	}
}
