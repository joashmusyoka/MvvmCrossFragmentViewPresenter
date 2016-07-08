using MvvmCross.Core.ViewModels;
using Presenter.Core.ViewModels;

namespace Presenter.Core
{
    public class App : MvxApplication
    {
        public App()
        {
            RegisterAppStart<ContainerViewModel>();
        }
    }
}
