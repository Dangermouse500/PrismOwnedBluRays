using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismOwnedBluRays.Models;
using PrismOwnedBluRays.Repositories;
using System.Collections.ObjectModel;

namespace PrismOwnedBluRays.ViewModels
{
    public class ShowOwnedBluRaysViewModel : BindableBase
    {
        private INavigationService _navigationService;
        private IBluRayRepository _bluRayRepository;
        private ObservableCollection<BluRay> _ownedBluRays;

        public ObservableCollection<BluRay> OwnedBluRays
        {
            get { return _ownedBluRays; }
            set {
                _ownedBluRays = value;
                //OnPropertyChanged("BluRays");
            }
        }

        public DelegateCommand GoToMainMenuCmd { get; set; }
        //public DelegateCommand DeleteBluRayCmd { get; set; }

        public ShowOwnedBluRaysViewModel(INavigationService navigationService,
                                         IBluRayRepository bluRayRepository)
        {
            _navigationService = navigationService;
            _bluRayRepository = bluRayRepository;

            GoToMainMenuCmd = new DelegateCommand(GoToMainMenu);

            OwnedBluRays = new ObservableCollection<BluRay>(_bluRayRepository.GetOwnedBluRays());
        }

        private void GoToMainMenu()
        {
            _navigationService.NavigateAsync("MainPage");
        }
    }
}