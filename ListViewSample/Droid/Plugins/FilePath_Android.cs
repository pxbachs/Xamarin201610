using System;
using System.IO;
using ListViewSample.Plugins;

namespace ListViewSample.Droid.Plugins
{
	public class FilePath_Android : IFilePath
	{
		public FilePath_Android()
		{
		}

		public string DBPath()
		{
			//todo: real API
			//Environment.SpecialFolder.Personal
			//IMvxFileStore
			var p = Path.Combine("/sdcard/Download/","testdb.sql");
			return p;
		}

		public void DeleteDB(string path)
		{
			File.Delete(path);
		}
	}
}
