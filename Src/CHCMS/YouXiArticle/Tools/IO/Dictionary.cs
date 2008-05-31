
using System.IO;
namespace YouXiArticle.Tools.IO
{
	public class Dictionary
	{

		/// <summary>
		/// 文件夹复制
		/// </summary>
		/// <param name="sourceDirName">原始路径</param>
		/// <param name="destDirName">目标路径</param>
		/// <returns></returns>
		public static void Copy(string sourceDirName, string destDirName)
		{
			if (sourceDirName.Substring(sourceDirName.Length - 1) != "\\")
			{
				sourceDirName = sourceDirName + "\\";
			}
			if (destDirName.Substring(destDirName.Length - 1) != "\\")
			{
				destDirName = destDirName + "\\";
			}

			if (Directory.Exists(sourceDirName))
			{
				if (!Directory.Exists(destDirName))
				{
					Directory.CreateDirectory(destDirName);
				}
				foreach (string item in Directory.GetFiles(sourceDirName))
				{
					File.Copy(item, destDirName + Path.GetFileName(item), true);
				}
				foreach (string item in Directory.GetDirectories(sourceDirName))
				{
					Copy(item, destDirName + item.Substring(item.LastIndexOf("\\") + 1));
				}
			}
		}
	}
}
