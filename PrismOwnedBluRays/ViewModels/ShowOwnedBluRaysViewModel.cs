using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismOwnedBluRays.Models;
using PrismOwnedBluRays.Repositories;
using System;
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

        private void OnSelectedPhotosChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e);
        }

        public DelegateCommand GoToMainMenuCmd { get; set; }
        public Command DeleteBluRayCmd { get; set; }

        public ShowOwnedBluRaysViewModel(INavigationService navigationService,
                                         IBluRayRepository bluRayRepository)
            : base(navigationService, bluRayRepository)
        {
            _navigationService = navigationService;
            _bluRayRepository = bluRayRepository;

            GoToMainMenuCmd = new DelegateCommand(GoToMainMenu);
            DeleteBluRayCmd = new Command(execute:(bluRay) =>
            {
                DeleteBluRay((BluRay)bluRay);
            });

            OwnedBluRays = new ObservableCollection<BluRay>(_bluRayRepository.GetOwnedBluRays());
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