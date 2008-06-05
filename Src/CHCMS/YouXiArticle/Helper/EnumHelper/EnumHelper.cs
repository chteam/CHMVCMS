using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace YouXiArticle
{
	public class EnumHelper
	{
		public string GetGameType(int i)
		{
			GameType gt = new GameType();
			return gt.GetName(i);
		}
		public string GetGameArea(int i)
		{
			GameArea gt = new GameArea();
			return gt.GetName(i);
		}
		public string GetGameStatus(int i)
		{
			GameStatus gt = new GameStatus();
			return gt.GetName(i);
		}
		public string GetGameStory(int i)
		{
			GameStory gt = new GameStory();
			return gt.GetName(i);
		}
		public string GetGameView(int i)
		{
			GameView gt = new GameView();
			return gt.GetName(i);
		}
	}
}
