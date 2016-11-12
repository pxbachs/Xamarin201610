using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using ListViewSample.Core.DAL;
using ListViewSample.Core.Models;

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
			
			Mvx.RegisterType<IBaseRepository<Category>, BaseRepository<Category>>();
			Mvx.RegisterType<ICategoryRepository, CategoryRepository>();


			RegisterAppStart<Core.ViewModels.FirstViewModel>();
        }
    }
}
