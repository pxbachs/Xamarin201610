// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ListViewSample.iOS
{
	[Register ("CategoryTableViewCell")]
	partial class CategoryTableViewCell
	{
		[Outlet]
		UIKit.UILabel Desc { get; set; }

		[Outlet]
		UIKit.UIImageView ImageIcon { get; set; }

		[Outlet]
		UIKit.UILabel Title { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ImageIcon != null) {
				ImageIcon.Dispose ();
				ImageIcon = null;
			}

			if (Title != null) {
				Title.Dispose ();
				Title = null;
			}

			if (Desc != null) {
				Desc.Dispose ();
				Desc = null;
			}
		}
	}
}
