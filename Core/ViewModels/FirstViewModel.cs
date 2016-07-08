using MvvmCross.Core.ViewModels;

namespace Presenter.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        public IMvxCommand LoadSecondViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<SecondViewModel>());
            }
        }
    }
}
