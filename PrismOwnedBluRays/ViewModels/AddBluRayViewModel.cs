using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismOwnedBluRays.API;
using PrismOwnedBluRays.Models;
using PrismOwnedBluRays.Repositories;

namespace PrismOwnedBluRays.ViewModels
{
    public class AddBluRayViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private IBluRayRepository _bluRayRepository;
        private string _bluRayTitleEnteredByUser;
        public string BluRayTitleEnteredByUser
        {
            get { return _bluRayTitleEnteredByUser; }
            set
            {
                SetProperty(ref _bluRayTitleEnteredByUser, value);
            }
        }

        public DelegateCommand GoToMainMenuCmd { get; set; }
        public DelegateCommand SearchForBluRayTitleCmd { get; set; }

        public BluRay BluRayTitleReturnedFromSearch { get; set; }

        public AddBluRayViewModel(INavigationService navigationService,
                                  IBluRayRepository bluRayRepository)
            : base(navigationService, bluRayRepository)
        {
            _navigationService = navigationService;
            _bluRayRepository = bluRayRepository;

            GoToMainMenuCmd = new DelegateCommand(GoToMainMenu);

            SearchForBluRayTitleCmd = new DelegateCommand(SearchForBluRayTitles);
        }

        private async void SearchForBluRayTitles()
        {
            BluRayTitleReturnedFromSearch = await OmdbApi.GetBluRayTitle(BluRayTitleEnteredByUser);
            await _navigationService.NavigateAsync("ShowBluRayDetails", new NavigationParameters { { "BluRay", BluRayTitleReturnedFromSearch } });//useModalNavigation: true
        }

        /// <summary>
        /// 
        /// </summary>
        private void GoToMainMenu()
        {
            _navigationService.NavigateAsync("MainPage");
        }
    }
}