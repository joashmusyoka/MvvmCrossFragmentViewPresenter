using MvvmCross.Core.ViewModels;

namespace Presenter.Core.ViewModels
{
    public class SecondViewModel : MvxViewModel
    {
        public IMvxCommand LoadFirstViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<FirstViewModel>());
            }
        }
    }
}