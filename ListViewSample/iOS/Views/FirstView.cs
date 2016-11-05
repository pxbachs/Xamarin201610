using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;

namespace ListViewSample.iOS.Views
{
    public partial class FirstView : MvxViewController
    {
		private readonly MvxImageViewLoader _loader;

        public FirstView() : base("FirstView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            //set.Bind(Label).To(vm => vm.Hello);
            //set.Bind(TextField).To(vm => vm.Hello);
            //set.Apply();


        }
    }
}
