using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UIKit;
using Foundation;
using MvvmCross.Binding.ExtensionMethods;

namespace ListViewSample.iOS.Views
{
    public class MultiSectionTableViewSource : GenericMvxTableViewSource
    {
        public delegate IList GetElementsFromSectionDelegate(object section);
        public delegate UIView HeaderDelegate(UITableView tableView, int section, object sectionItem);

        public GetElementsFromSectionDelegate GetElementsFromSection { get; set; }

        public HeaderDelegate CreateHeader { get; set; }
        public HeaderDelegate CreateFooter { get; set; }

        public MultiSectionTableViewSource(UITableView tableView, NSString cellIdentifier) : base(tableView, cellIdentifier)
        {
        }

        protected IList GetElements(object section)
        {
            var elements = section as IList;

            if (GetElementsFromSection != null)
                elements = GetElementsFromSection(section);

            return elements;
        } 

        protected override object GetItemAt(NSIndexPath indexPath)
        {
            return ItemsSource == null ? null : GetElements(ItemsSource.ElementAt(indexPath.Section)).ElementAt(indexPath.Row);
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return ItemsSource == null ? 0 : ItemsSource.Count();
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
			return ItemsSource == null ? 0 : GetElements(ItemsSource.ElementAt((int)section)).Count;
        }

        public override UIView GetViewForHeader(UITableView tableView, nint section) {
            if (CreateHeader == null)
                return null;

            var sectionItem = ItemsSource.Cast<object>().ElementAt((int)section);
            return CreateHeader(tableView, (int)section, sectionItem);
        }

        public override UIView GetViewForFooter(UITableView tableView, nint section) {
            if (CreateFooter == null)
                return null;

            var sectionItem = ItemsSource.Cast<object>().ElementAt((int)section);
            return CreateFooter(tableView, (int)section, sectionItem);
        }
    }

}