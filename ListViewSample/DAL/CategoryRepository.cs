using System;
using ListViewSample.Core.Models;

namespace ListViewSample.Core.DAL
{
	public interface ICategoryRepository : IBaseRepository<Category> {
		
	}
	public class CategoryRepository: BaseRepository<Category>, ICategoryRepository
	{
		public CategoryRepository() : base()
		{
		}
	}
}
