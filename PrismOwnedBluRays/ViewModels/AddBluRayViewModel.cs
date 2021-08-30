using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismOwnedBluRays.ViewModels
{
    public class AddBluRayViewModel : BindableBase
    {
        private INavigationService _navigationService;
        private DelegateCommand _navigateCommand;

        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        public AddBluRayViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private async void ExecuteNavigateCommand()
        {
            await _navigationService.GoBackAsync();
        }
    }
}