using System;
using Android.Support.V4.App;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views;

namespace Presenter.Droid
{
    public class DroidPresenter : MvxAndroidViewPresenter
    {
        private readonly IMvxViewModelLoader _viewModelLoader;
        private readonly IFragmentTypeLookup _fragmentTypeLookup;
        private FragmentManager _fragmentManager;

        public DroidPresenter(IMvxViewModelLoader viewModelLoader, IFragmentTypeLookup fragmentTypeLookup)
        {
            _fragmentTypeLookup = fragmentTypeLookup;
            _viewModelLoader = viewModelLoader;
        }

        public override void Show(MvxViewModelRequest request)
        {
            Type fragmentType;
            if (_fragmentManager == null || !_fragmentTypeLookup.TryGetFragmentType(request.ViewModelType, out fragmentType))
            {
                base.Show(request);

                return;
            }

            var fragment = (MvxFragment)Activator.CreateInstance(fragmentType);
            fragment.ViewModel = _viewModelLoader.LoadViewModel(request, null);

            ShowFragment(fragment);
        }

        public override void Close(IMvxViewModel viewModel)
        {
            var currentFragment = _fragmentManager.FindFragmentById(Resource.Id.contentFrame) as MvxFragment;
            if (currentFragment != null && currentFragment.ViewModel == viewModel)
            {
                _fragmentManager.PopBackStackImmediate();

                return;
            }

            base.Close(viewModel);
        }

        public void RegisterFragmentManager(FragmentManager fragmentManager)
        {
            _fragmentManager = fragmentManager;
        }

        private void ShowFragment(MvxFragment fragment)
        {
            var transaction = _fragmentManager.BeginTransaction();

            transaction
                .Replace(Resource.Id.contentFrame, fragment)
                .Commit();
        }
    }
}