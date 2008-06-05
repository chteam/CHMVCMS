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
	public enum GameType
	{
		动作冒险,
		格斗,
		体育,
		竞速赛车,
		音乐舞蹈,
		回合战斗,
		角色扮演,
		FPS射击,
		益智休闲,
		网页游戏
	}
	public enum GameArea
	{
		大陆, 港台, 日韩, 欧美
	}
	public enum GameView { 二维, 三维 }
	public enum GameStatus { 未测试, 封测, 内测, 公测, 收费, 永久免费, 部分免费, 停止运营 }
	public enum GameStory { 武侠, 卡通, 奇幻, 历史, 科幻, 神话 }
	//GameCompany	bigint	Checked
}
