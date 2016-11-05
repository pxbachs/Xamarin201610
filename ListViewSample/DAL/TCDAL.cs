using System;
using ListViewSample.Plugins;
using MvvmCross.Platform;
using MvvmCross.Plugins.Sqlite;

namespace ListViewSample.DAL
{
	public class TCDAL
	{
		IMvxSqliteConnectionFactory _IMvxSqliteConnectionFactory;
		SQLite.SQLiteConnection dbConnection;

		public TCDAL()
		{
			//TODO: connect db
			_IMvxSqliteConnectionFactory = Mvx.Resolve<IMvxSqliteConnectionFactory>();

			IFilePath fp = Mvx.Resolve<IFilePath>();
			var dbpath = fp.DBPath();
			dbConnection = _IMvxSqliteConnectionFactory.GetConnection(dbpath);
		}
	}
}
