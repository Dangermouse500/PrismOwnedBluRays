using Prism.Commands;
using Prism.Navigation;
using PrismOwnedBluRays.Repositories;

namespace PrismOwnedBluRays.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public DelegateCommand GoToAddBluRayCmd { get; set; }
        public DelegateCommand GoToViewOwnedBluRaysCmd { get; set; }

        public MainPageViewModel(INavigationService navigationService, IBluRayRepository bluRayRepository)
            : base(navigationService, bluRayRepository)
        {
            Title = "Main Page";
            _navigationService = navigationService;

            GoToAddBluRayCmd = new DelegateCommand(GoToAddBluRay);
            GoToViewOwnedBluRaysCmd = new DelegateCommand(GoToViewOwnedBluRays);
        }

        private void GoToAddBluRay()
        {
            _navigationService.NavigateAsync("AddBluRay");
        }

        private void GoToViewOwnedBluRays()
        {
            _navigationService.NavigateAsync("ShowOwnedBluRays");
        }
    }    
}