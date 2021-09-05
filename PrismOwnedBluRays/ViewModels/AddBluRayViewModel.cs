using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismOwnedBluRays.API;
using PrismOwnedBluRays.Models;
using PrismOwnedBluRays.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PrismOwnedBluRays.ViewModels
{
    public class AddBluRayViewModel : BindableBase
    {
        private INavigationService _navigationService;
        private IBluRayRepository _bluRayRepository;
        private DelegateCommand _navigateCommand;

        //private List<BluRay> _bluRayTitlesReturnedFromSearch;
        //public List<BluRay> BluRayTitlesReturnedFromSearch
        //{
        //    get { return _bluRayTitlesReturnedFromSearch; }
        //    set
        //    {
        //        _bluRayTitlesReturnedFromSearch = value;
        //        //OnPropertyChanged("BluRays");
        //    }
        //}

        public BluRay BluRayTitleReturnedFromSearch { get; set; }

        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        public AddBluRayViewModel(INavigationService navigationService,
                                  IBluRayRepository bluRayRepository)
        {
            _navigationService = navigationService;
            _bluRayRepository = bluRayRepository;

            // This needs changing to a button search event click
            SearchForBluRayTitles();
        }

        private async void SearchForBluRayTitles()
        {
            BluRayTitleReturnedFromSearch = await OmdbApi.GetBluRayTitle("Joker");
        }

        private async void ExecuteNavigateCommand()
        {
            await _navigationService.GoBackAsync();
        }
    }
}