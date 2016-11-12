using System;
using System.Collections.Generic;
using ListViewSample.Core.Models;

namespace ListViewSample.Core.DAL
{
	public interface IBaseRepository<T> where T : ITCEntity, new()
	{
		List<T> AllItems();
		void Add(T item);
		void Delete(T item);
		void Update(T item);
		T GetItem(int id);
	}
}
