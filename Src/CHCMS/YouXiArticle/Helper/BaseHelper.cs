using YouXiArticle.Models;

namespace YouXiArticle
{
	public class BaseHelper
	{
		#region DataContext DBC单例属性
		ArticleDataContext _DBC = null;

		public ArticleDataContext DataContext
		{
			get
			{
				if (_DBC == null)
					_DBC = new ArticleDataContext();
				return _DBC;
			}
		}
		DBExt _dbExt = null;
		public DBExt DBExt
		{
			get
			{
				if (_dbExt == null)
				{
					_dbExt = new DBExt(this.DataContext);
				}
				return _dbExt;
			}
		}
		#endregion
	}
}
