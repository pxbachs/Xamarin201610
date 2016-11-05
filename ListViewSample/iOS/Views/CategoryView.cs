using System;
using ListViewSample.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace ListViewSample.iOS.Views
{
	public partial class CategoryView : MvxViewController, IUITableViewDelegate
	{
		public CategoryView() : base("CategoryView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			var CategoryTableSource = new CategoryTableSource(TableView);
			this.CreateBinding(CategoryTableSource).To<CategoryViewModel>(vm => vm.ListCategory).Apply();
			//this.CreateBinding(CategoryTableSource).For(s => s.SelectionChangedCommand).To<CategoryViewModel>(vm => vm.Cmd).Apply();
			TableView.Source = CategoryTableSource;

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

