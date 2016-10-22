using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using ListViewSample.Core.Models;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views;

namespace ListViewSample.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);

			//TODO: custom adapter
			CategoryListView catListView = FindViewById<CategoryListView>(Resource.Layout.FirstView);


        }
    }

	public class CategoryListView : MvxListView
	{
		public CategoryListView(Context context, IAttributeSet attrs) :
			base(context, attrs, new CategoryAdapter(context))
		{
		}
	}

	class CategoryAdapter : MvxAdapter
	{
		FirstView firstView;

		public CategoryAdapter(Context context, IMvxAndroidBindingContext BindingContext)
				: base(context, BindingContext)
		{

		}
		public CategoryAdapter(Context context)
				: base(context, MvxAndroidBindingContextHelpers.Current())
		{

		}

		public override int GetItemViewType(int position)
		{
			return position % 2;
		}

		public override int ViewTypeCount
		{
			get { return 2; }
		}

		protected override global::Android.Views.View GetBindableView(global::Android.Views.View convertView, object dataContext, int templateId)
		{
			var cat = dataContext as Category;
			if (cat.Id % 2 == 0)
				return base.GetBindableView(convertView, dataContext, Resource.Layout.category_item);
			else
				return base.GetBindableView(convertView, dataContext, Resource.Layout.category_item_2);
		}
	}
}
