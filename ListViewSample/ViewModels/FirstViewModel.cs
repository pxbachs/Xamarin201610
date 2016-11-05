using System;
using System.Collections.ObjectModel;
using ListViewSample.Core.Models;
using ListViewSample.DAL;
using ListViewSample.Plugins;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace ListViewSample.Core.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {

		public ObservableCollection<Category> ListCategory { get; set; }

		public FirstViewModel(IFilePath fp)
		{
			ListCategory = new ObservableCollection<Category>();

			ListCategory.Add(new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"));
			ListCategory.Add(new Category("Category 2", "Description 2", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"));
			ListCategory.Add(new Category("Category 3", "Description 3", "http://img.f30.vnecdn.net/2016/10/21/buonlau-3209-1477065005_180x108.jpg"));
			ListCategory.Add(new Category("Category 4", "Description 4", "http://img.f30.vnecdn.net/2016/10/21/buonlau-3209-1477065005_180x108.jpg"));

			//IFilePath fp = Mvx.Resolve<IFilePath>();
			var dbpath = fp.DBPath();
			System.Diagnostics.Debug.WriteLine("DB Path: " + dbpath);
			//imple
			//instance

			var TCDAL = new TCDAL();
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
			ShowViewModel<CategoryViewModel>();
		}

}
}
