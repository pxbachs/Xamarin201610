using System;
using System.IO;
using ListViewSample.Core.Models;
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



			//ORM, Linq
			//create/add/delete

			//dev env
			//xoa db cu
			#if DEBUG
			fp.DeleteDB(dbpath);
			#endif
			//create table
			dbConnection.CreateTable<Category>();

			//insert
			dbConnection.Insert(new Category("Category 1", "Description 1", "anhmoi2-3086-1477115773_490x294.jpg"));
			dbConnection.Insert(new Category("Category 2", "Description 2", "anhmoi2-3086-1477115773_490x294.jpg"));
			dbConnection.Insert(new Category("Category 3", "Description 3", "anhmoi2-3086-1477115773_490x294.jpg"));

			//list
			var query = (from cats in dbConnection.Table<Category>() 
			             where cats.Name.Equals("")
			             select cats);

			foreach (var cat in query) {
				System.Diagnostics.Debug.WriteLine(cat.ToString());
			}


		}
	}
}
