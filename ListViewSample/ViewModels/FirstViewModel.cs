using System;
using System.Collections.ObjectModel;
using ListViewSample.Core.Models;
using MvvmCross.Core.ViewModels;

namespace ListViewSample.Core.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {

		public ObservableCollection<Category> ListCategory { get; set; }

		public FirstViewModel()
		{
			ListCategory = new ObservableCollection<Category>();

			ListCategory.Add(new Category("Category 1", "Description 1", "images/cat_icon1.png"));
			ListCategory.Add(new Category("Category 2", "Description 2", "images/cat_icon2.png"));
			ListCategory.Add(new Category("Category 3", "Description 3", "images/cat_icon3.png"));
			ListCategory.Add(new Category("Category 4", "Description 4", "images/cat_icon4.png"));

		}


		private MvxCommand<Category> _CategorySelectedCommand;
		public System.Windows.Input.ICommand CategorySelected
		{
			get
			{
				_CategorySelectedCommand = _CategorySelectedCommand ?? new MvxCommand<Category>(DoSelectedCategory);
				return _CategorySelectedCommand;
			}
		}

		void DoSelectedCategory(Category obj)
		{
			System.Diagnostics.Debug.WriteLine("Category Selected: " + obj.Name);
		}

}
}
