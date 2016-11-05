using System;

using Foundation;
using ListViewSample.Core.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace ListViewSample.iOS
{
	public partial class CategoryTableViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("CategoryTableViewCell");
		public static readonly UINib Nib;

		static CategoryTableViewCell()
		{
			Nib = UINib.FromName("CategoryTableViewCell", NSBundle.MainBundle);
		}

		protected CategoryTableViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
			this.DelayBind(() =>
			{
				var set = this.CreateBindingSet<CategoryTableViewCell, Category>();
				set.Bind(Title).To(item => item.Name);
				set.Bind(Desc).To(item => item.Desc);
				var pnlBackImageLoader = new MvxImageViewLoader(() => ImageIcon);
				set.Bind(pnlBackImageLoader).To(item => item.Icon);
				set.Apply();
			});

			LayoutMargins = UIEdgeInsets.Zero;
		}
	}
}
