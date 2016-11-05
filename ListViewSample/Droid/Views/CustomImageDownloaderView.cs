
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Plugins.DownloadCache;

namespace ListViewSample.Droid.Views
{
	[Activity(Label = "CustomImageDownloaderView")]
	public class CustomImageDownloaderView : MvxActivity
	{
		IMvxHttpFileDownloader downloader;
		IMvxFileDownloadCache cacheDownloader;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.CustomImageDownloaderView);

			downloader = Mvx.Resolve<IMvxHttpFileDownloader>();

			downloader.RequestDownload("http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg", 
			                           "/sdcard/Download/anhmoi2-3086-1477115773_490x294.jpg", () => {
										   System.Diagnostics.Debug.WriteLine("Downloaded!");
									}, (e) => { 
												System.Diagnostics.Debug.WriteLine("Download Error: " + e.Message);
										});

			cacheDownloader = Mvx.Resolve<IMvxFileDownloadCache>();
			cacheDownloader.RequestLocalFilePath("http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg",
									    (path) =>
									   {
										   System.Diagnostics.Debug.WriteLine("Downloaded: " + path);
									   }, (e) =>
									   {
										   System.Diagnostics.Debug.WriteLine("Download Error: " + e.Message);
									   });
		}
	}
}
