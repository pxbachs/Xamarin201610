using System;
using Foundation;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Platform.Core;
using UIKit;

namespace ListViewSample.iOS.Views
{
	public class GroupedListTableViewSource : CollapsableSectionTableViewSource
	{
		public GroupedListTableViewSource(UITableView tableView, NSString cellIdentifier) : base(tableView, cellIdentifier)
        {
			tableView.RegisterNibForCellReuse(UINib.FromName(cellIdentifier, NSBundle.MainBundle), cellIdentifier);
			tableView.RegisterNibForCellReuse(UINib.FromName(HeaderTableViewCell.Key, NSBundle.MainBundle), HeaderTableViewCell.Key);

			UseAnimations = true;
		}


		//Define height of Cell follow by type data for cell view
		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			var item = GetItemAt(indexPath);
			return 100;
		}
		public override nfloat GetHeightForHeader(UITableView tableView, nint section)
		{
			return 40;
		}

		public override nfloat GetHeightForFooter(UITableView tableView, nint section)
		{
			//return base.GetHeightForFooter(tableView, section);
			return 0;
		}

		public override UIView GetViewForHeader(UITableView tableView, nint section)
		{
			var reuse = tableView.DequeueReusableCell(HeaderTableViewCell.Key);
			var item = ItemsSource.ElementAt((int)section);

			var bindable = reuse as IMvxDataConsumer;
			if (bindable != null)
				bindable.DataContext = item;

			((UIButton)reuse.ViewWithTag(100)).TouchUpInside += (sender, e) =>
			{
				ToggleCollapseSection((int)section);
			};

			return reuse;

			//if (CreateHeader == null)
			//    return null;

			//var sectionElement = ItemsSource.ElementAt((int)section);
			//var isCollapsed = _collapsedSections.Contains(sectionElement);
			//var header = CreateHeader(tableView, sectionElement, (int)section, isCollapsed);
			//header.TouchUpInside += (sender, args) => ToggleCollapseSection((int)section);

			//return header;
		}
	}
}
