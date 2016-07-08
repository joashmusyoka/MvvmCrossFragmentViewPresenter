using MvvmCross.Core.ViewModels;

namespace Presenter.Core.ViewModels
{
    public class ContainerViewModel : MvxViewModel
    {
        public void LoadFirstScreen()
        {
            this.ShowViewModel<FirstViewModel>();
        }
    }
}
