using System;
namespace ListViewSample.Plugins
{
	public interface IFilePath
	{
		string DBPath();
		void DeleteDB(string path);

	}
}
