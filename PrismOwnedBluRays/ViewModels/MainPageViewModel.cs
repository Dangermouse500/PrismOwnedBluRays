using Prism.Commands;
using Prism.Navigation;
using PrismOwnedBluRays.Repositories;

namespace PrismOwnedBluRays.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private IBluRayRepository _bluRayRepository;

        public MainPageViewModel(INavigationService navigationService, IBluRayRepository bluRayRepository)
            : base(navigationService, bluRayRepository)
        {
            Title = "Main Page";
            _navigationService = navigationService;
            _bluRayRepository = bluRayRepository;
        }
    }    
}