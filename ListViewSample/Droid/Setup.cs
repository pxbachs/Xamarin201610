using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using ListViewSample.Plugins;
using ListViewSample.Droid.Plugins;

namespace ListViewSample.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

		protected override void InitializeFirstChance()
		{
			base.InitializeFirstChance();

			//register dependancies
			Mvx.RegisterType<IFilePath, FilePath_Android>();
		}
    }
}
