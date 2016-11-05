using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace ListViewSample.iOS
{
	public partial class HeaderTableViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("HeaderTableViewCell");
		public static readonly UINib Nib;

		static HeaderTableViewCell()
		{
			Nib = UINib.FromName("HeaderTableViewCell", NSBundle.MainBundle);
		}

		protected HeaderTableViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
			this.DelayBind(() =>
			{
				var set = this.CreateBindingSet<HeaderTableViewCell, Group>();
				set.Bind(Title).To(item => item.Name);
				set.Apply();
			});

			LayoutMargins = UIEdgeInsets.Zero;
		}
	}
}
