using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CoreAnimation;
using Foundation;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Platform.Core;
using UIKit;

namespace ListViewSample.iOS.Views
{
    public class CollapsableSectionTableViewSource : MultiSectionTableViewSource
    {
        public abstract class CollapsableHeader: UIView
        {
            public abstract event EventHandler TouchUpInside;
        }

        public override IEnumerable ItemsSource
        {
            get { return base.ItemsSource; }
            set
            {
                if (CollapseSectionsByDefault && value != null)
                    _collapsedSections = value.Cast<object>().ToList();

                base.ItemsSource = value;
            }
        }

        public bool CollapseSectionsByDefault { get; set; }

        public delegate CollapsableHeader CreateHeaderDelegate(UITableView tableView, object sectionElement, int sectionIndex, bool collapsed);

        public new CreateHeaderDelegate CreateHeader { get; set; }

        private IList _collapsedSections = new List<object>();

        public CollapsableSectionTableViewSource(UITableView tableView, NSString cellIdentifier) : base(tableView, cellIdentifier)
        {
			
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            var rows = base.RowsInSection(tableview, section);

            var sectionElement = ItemsSource.ElementAt((int)section);
            if (_collapsedSections.Contains(sectionElement))
                rows = 0;

            return rows;
        }

        public void SetSectionCollapsed(int section, bool collapsed, bool animated = true) {
            var sectionElement = ItemsSource.ElementAt(section);
            if (sectionElement == null)
                return;

            if (collapsed)
                _collapsedSections.Add(sectionElement);
            else
                _collapsedSections.Remove(sectionElement);


			if (UseAnimations && animated)
			{
				CATransaction.Begin();
				TableView.BeginUpdates();
				CATransaction.CompletionBlock += () => { 
					ReloadTableData();
					System.Diagnostics.Debug.WriteLine("Tableview animation end!");
				};
				TableView.ReloadSections(new NSIndexSet((uint)section), UITableViewRowAnimation.Automatic);
				TableView.EndUpdates();
				CATransaction.Commit();
			} else
                ReloadTableData();

        }

        public void ToggleCollapseSection(int section) {
            var sectionElement = ItemsSource.ElementAt(section);
            if (sectionElement == null)
                return;

            var isCollapsed = _collapsedSections.Contains(sectionElement);
            SetSectionCollapsed(section, !isCollapsed);
        }
    }
}