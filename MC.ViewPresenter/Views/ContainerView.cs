using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using Presenter.Core.ViewModels;

namespace Presenter.Droid.Views
{
    [Activity(Label = "View Presenter", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    public class ContainerView : MvxAppCompatActivity<ContainerViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.container);

            var presenter = (DroidPresenter) Mvx.Resolve<IMvxAndroidViewPresenter>();
            presenter.RegisterFragmentManager(SupportFragmentManager);

            this.ViewModel.LoadFirstScreen();
        }
    }
}

