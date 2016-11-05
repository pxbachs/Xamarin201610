using System;
using System.Linq;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace ListViewSample.iOS.Views
{

    public class GenericMvxTableViewSource : MvxTableViewSource, ITableViewEventSource
    {
        public delegate MvxTableViewCell CreateCellDelegate(UITableView tableView, NSIndexPath indexPath, object item);
        public delegate void CellModifierDelegate(UITableViewCell cell, NSIndexPath indexPath, object item);

        protected virtual NSString CellIdentifier { get; private set; }
        public CreateCellDelegate CreateCell { get; set; }
        public CellModifierDelegate CellModifier { get; set; }

        public GenericMvxTableViewSource(UITableView tableView, NSString cellIdentifier) : base(tableView)
        {
            CellIdentifier = cellIdentifier;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var reuse = tableView.DequeueReusableCell(CellIdentifier);
            var cell = reuse ?? CreateDefaultBindableCell(tableView, indexPath, item);
            if (CellModifier != null)
                CellModifier(cell, indexPath, item);
            return cell;
        }

        protected virtual MvxTableViewCell CreateDefaultBindableCell(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return CreateCell != null ? CreateCell(tableView, indexPath, item) : null;
        }

        public new object SelectedItem { 
            get { return base.SelectedItem; }
            set
            {
                base.SelectedItem = value;

                if (value != null)
                {
                    var index = IndexForElement(value);
                    if (index != null)
                        TableView.SelectRow(index, false, UITableViewScrollPosition.None);
                }
                else
                {
                    var index = TableView.IndexPathForSelectedRow;
                    if (index != null && index.Row >= 0)
                        TableView.DeselectRow(index, false);
                }
            }
        }

        public virtual NSIndexPath IndexForElement(object element) {
            if (ItemsSource == null || element == null)
                return null;

            return NSIndexPath.FromRowSection(ItemsSource.Cast<object>().ToList().IndexOf(element), 0);
        }

        #region ITableViewEventSource implementation

        public event EventHandler OnDecelerationEnded;
        public event EventHandler OnDecelerationStarted;
        public event EventHandler OnDidZoom;
        public event EventHandler OnDraggingStarted;
        public event EventHandler OnScrollAnimationEnded;
        public event EventHandler OnScrolled;
        public event EventHandler OnScrolledToTop;

        public override void DecelerationEnded(UIScrollView scrollView)
        {
            if (OnDecelerationEnded != null)
                OnDecelerationEnded(scrollView, null);
        }
        public override void DecelerationStarted(UIScrollView scrollView)
        {
            if (OnDecelerationStarted != null)
                OnDecelerationStarted(scrollView, null);
        }
        public override void DidZoom(UIScrollView scrollView)
        {
            if (OnDidZoom != null)
                OnDidZoom(scrollView, null);
        }
        public override void DraggingStarted(UIScrollView scrollView)
        {
            if (OnDraggingStarted != null)
                OnDraggingStarted(scrollView, null);
        }
        public override void ScrollAnimationEnded(UIScrollView scrollView)
        {
            if (OnScrollAnimationEnded != null)
                OnScrollAnimationEnded(scrollView, null);
        }
        public override void Scrolled(UIScrollView scrollView)
        {
            if (OnScrolled != null)
                OnScrolled(scrollView, null);
        }
        public override void ScrolledToTop(UIScrollView scrollView)
        {
            if (OnScrolledToTop != null)
                OnScrolledToTop(scrollView, null);
        }

        #endregion

    }
}
