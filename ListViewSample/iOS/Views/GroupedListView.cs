using System;
using ListViewSample.Core.Models;
using ListViewSample.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.Platform.Core;
using UIKit;

namespace ListViewSample.iOS.Views
{
	public partial class GroupedListView : MvxTableViewController
	{
		public GroupedListView() : base( )//"GroupedListView"
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			var TableSource = new GroupedListTableViewSource(this.TableView, CategoryTableViewCell.Key);
			TableSource.CellModifier = (cell, indexPath, item) => { 
				cell.BackgroundColor = UIColor.LightGray;
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			};
			TableSource.OnScrolled += (sender, e) => {
				//System.Diagnostics.Debug.WriteLine("TableSource.OnScrolled");
			};


			this.CreateBinding(TableSource).To<GroupedListViewModel>(vm => vm.ListGroup).Apply();

			TableSource.SelectedItemChanged += (sender, e) => {
				((GroupedListViewModel)base.ViewModel)[0, ""] = "sdafsdfewqfsafs";
				((GroupedListViewModel)base.ViewModel).ListGroup[0].Add(new Category("Category sdafsdafsd1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"));
				TableSource.ReloadTableData();
				//((GroupedListViewModel)base.ViewModel).ListGroup[0].Name = "ljsdlfajlsdf";
				//((GroupedListViewModel)base.ViewModel).ListGroup[0][0].Name = "wrqwyvbxczvdsa";


				//((GroupedListViewModel)base.ViewModel).ListGroup.Add(new Group("Group 23") {
				//		new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"),
				//		new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"),
				//		new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"),
				//		new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg")
				//});
			};
			this.TableView.Source = TableSource;


		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}

	public partial class HeaderView : CollapsableSectionTableViewSource.CollapsableHeader
	{
		Group sectionElement;

		public override event EventHandler TouchUpInside;


		public HeaderView(object sectionElement)
		{
			this.sectionElement = (Group)sectionElement;

			UIButton b = new UIButton(new CoreGraphics.CGRect(0, 0, 100, 30));
			//b.SetTitle(this.sectionElement.Name, UIControlState.Normal);

			this.BackgroundColor = UIColor.Green;
			this.AddSubview(b);

			b.TouchUpInside += (sender, e) =>
			{
				TouchUpInside(sender, e);
			};

			var bindable = b as IMvxDataConsumer;
			if (bindable != null)
				bindable.DataContext = this.sectionElement;
		}
	}
}

