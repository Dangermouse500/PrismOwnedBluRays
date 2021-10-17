using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;
using PrismOwnedBluRays.API;
using PrismOwnedBluRays.Models;
using PrismOwnedBluRays.Repositories;
using System;

namespace PrismOwnedBluRays.ViewModels
{
    public class AddBluRayViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private IBluRayRepository _bluRayRepository;
        private readonly IDialogService _dialogService;
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

        public Action<string> ShowMessage;

        public AddBluRayViewModel(INavigationService navigationService,
                                  IBluRayRepository bluRayRepository,
                                  IDialogService dialogService)
            : base(navigationService, bluRayRepository)
        {
            _navigationService = navigationService;
            _bluRayRepository = bluRayRepository;
            _dialogService = dialogService;

            GoToMainMenuCmd = new DelegateCommand(GoToMainMenu);

            SearchForBluRayTitleCmd = new DelegateCommand(SearchForBluRayTitles);
        }

        private async void SearchForBluRayTitles()
        {
            BluRayTitleReturnedFromSearch = await OmdbApi.GetBluRayTitle(BluRayTitleEnteredByUser);
            if (BluRayTitleReturnedFromSearch.BluRayTitle == null)
            {
                _dialogService.ShowDialog("OkDialogView", new DialogParameters
                {
                    { "Question", "No Blu-Ray found, please try again." },
                    { "CloseOnTap", true }
                });
            }
            else
            {                
                await _navigationService.NavigateAsync("ShowBluRayDetails", new NavigationParameters { { "BluRay", BluRayTitleReturnedFromSearch } });
            }
            //useModalNavigation: true
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