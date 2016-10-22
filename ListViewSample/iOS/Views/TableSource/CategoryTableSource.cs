using System;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace ListViewSample.iOS.Views
{
	public class CategoryTableSource : MvxTableViewSource
	{

		public CategoryTableSource(UITableView tableView) : base(tableView)
		{
			tableView.RegisterNibForCellReuse(UINib.FromName("CategoryTableViewCell", NSBundle.MainBundle), CategoryTableViewCell.Key);
		}

		protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
		{
			NSString identifier = CategoryTableViewCell.Key;
			var cell = (UITableViewCell)tableView.DequeueReusableCell(identifier, indexPath);
			return cell;

			//throw new NotImplementedException();
		}
	}
}
