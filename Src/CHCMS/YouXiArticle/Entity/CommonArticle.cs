using System;

namespace YouXiArticle
{
	public class CommonArticle
	{
		public long ID { get; set; }
		public string Title
		{
			get;
			set;
		}
		public string Body { set; get; }
		public string Author { set; get; }
		public bool IsUrl { set; get; }
		public DateTime Addtime { get; set; }
		public byte Type { get; set; }
	}
}
