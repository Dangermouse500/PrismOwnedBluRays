using Prism.Commands;
using Prism.Navigation;
using PrismOwnedBluRays.Models;
using PrismOwnedBluRays.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace PrismOwnedBluRays.ViewModels
{
    public class ShowOwnedBluRaysViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private IBluRayRepository _bluRayRepository;
        private ObservableCollection<BluRay> _ownedBluRays;

        public ObservableCollection<BluRay> OwnedBluRays
        {
            get { return _ownedBluRays; }
            set
            {
                SetProperty(ref _ownedBluRays, value);
            }
        }

        public DelegateCommand GoToMainMenuCmd { get; set; }
        public Command ShowAllBluRayDetailsCmd { get; set; }
        public Command DeleteBluRayCmd { get; set; }

        public ShowOwnedBluRaysViewModel(INavigationService navigationService,
                                         IBluRayRepository bluRayRepository)
            : base(navigationService, bluRayRepository)
        {
            _navigationService = navigationService;
            _bluRayRepository = bluRayRepository;

            GoToMainMenuCmd = new DelegateCommand(GoToMainMenu);
            ShowAllBluRayDetailsCmd = new Command(execute: (bluRay) =>
            {
                ShowAllBluRayDetails((BluRay)bluRay);
            });
            DeleteBluRayCmd = new Command(execute:(bluRay) =>
            {
                DeleteBluRay((BluRay)bluRay);
            });

            OwnedBluRays = new ObservableCollection<BluRay>(_bluRayRepository.GetOwnedBluRays());
        }

        private void ShowAllBluRayDetails(BluRay bluRay)
        {
            _navigationService.NavigateAsync("ShowBluRayDetails", new NavigationParameters { { "BluRayId", bluRay.BluRayId } });//useModalNavigation: true
        }

        private void DeleteBluRay(BluRay bluRay)
        {
            _bluRayRepository.DeleteBluRay(bluRay);
            OwnedBluRays.Remove(bluRay);
        }

        private void GoToMainMenu()
        {
            _navigationService.NavigateAsync("MainPage");
        }
    }
}