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
            set { _ownedBluRays = value; }
        }

        //private DelegateCommand _navigateCommand;

        //public DelegateCommand NavigateCommand =>
        //    _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        public ShowOwnedBluRaysViewModel(INavigationService navigationService,
                                         IBluRayRepository bluRayRepository)
        {
            _navigationService = navigationService;
            _bluRayRepository = bluRayRepository;

            OwnedBluRays = new ObservableCollection<BluRay>(_bluRayRepository.GetOwnedBluRays());
        }

        //private async void ExecuteNavigateCommand()
        //{
        //    await _navigationService.GoBackAsync();
        //}
    }
}