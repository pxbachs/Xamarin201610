using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ListViewSample.Core.Models;
using ListViewSample.Plugins;
using MvvmCross.Platform;
using MvvmCross.Plugins.Sqlite;

namespace ListViewSample.Core.DAL
{
	public class BaseRepository<T> : IBaseRepository<T> where T:class, ITCEntity, new()
	{
		IMvxSqliteConnectionFactory _IMvxSqliteConnectionFactory;
		SQLite.SQLiteConnection dbConnection;

		public BaseRepository()
		{
			//TODO: connect db
			_IMvxSqliteConnectionFactory = Mvx.Resolve<IMvxSqliteConnectionFactory>();

			IFilePath fp = Mvx.Resolve<IFilePath>();
			var dbpath = fp.DBPath();
			//dev env
			//xoa db cu
#if DEBUG
			fp.DeleteDB(dbpath);
#endif
			dbConnection = _IMvxSqliteConnectionFactory.GetConnection(dbpath);



			////ORM, Linq
			////create/add/delete


			////create table
			dbConnection.CreateTable<Category>();

			////insert
			//dbConnection.Insert(new Category("Category 1", "Description 1", "anhmoi2-3086-1477115773_490x294.jpg"));
			//dbConnection.Insert(new Category("Category 2", "Description 2", "anhmoi2-3086-1477115773_490x294.jpg"));
			//dbConnection.Insert(new Category("Category 3", "Description 3", "anhmoi2-3086-1477115773_490x294.jpg"));

			////list
			//var query = (from cats in dbConnection.Table<Category>() 
			//             where cats.Name.Equals("")
			//             select cats);

			//foreach (var cat in query) {
			//	System.Diagnostics.Debug.WriteLine(cat.ToString());
			//}


		}


		public List<T> AllItems()
		{
			return dbConnection.Table<T>().ToList();
		}

		public void Add(T item)
		{
			dbConnection.Insert(item);
		}

		public void Delete(T item)
		{
			dbConnection.Delete(item);
		}

		public void Update(T item)
		{
			dbConnection.Update(item);
		}

		public T GetItem(int id)
		{
			return dbConnection.Get<T>(id);
		}
	}

}
