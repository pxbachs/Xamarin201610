using MvvmCross.Platform.IoC;

namespace ListViewSample.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

			RegisterAppStart<Core.ViewModels.FirstViewModel>();
        }
    }
}
