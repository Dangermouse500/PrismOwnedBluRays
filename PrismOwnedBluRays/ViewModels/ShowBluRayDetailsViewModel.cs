using Prism.Commands;
using Prism.Navigation;
using PrismOwnedBluRays.Models;
using PrismOwnedBluRays.Repositories;
using System.Linq;
using Xamarin.Forms;

namespace PrismOwnedBluRays.ViewModels
{
    public class ShowBluRayDetailsViewModel : ViewModelBase, INavigationAware
    {
        private INavigationService _navigationService;
        private IBluRayRepository _bluRayRepository;
        private BluRay bluRayDetail;

        public DelegateCommand SaveBluRayCmd { get; set; }
        public DelegateCommand ReturnToAddBluRayCmd { get; set; }
        public DelegateCommand GoToMainMenuCmd { get; set; }
        public BluRay BluRayDetail
        {
            get => bluRayDetail;
            set => SetProperty(ref bluRayDetail, value);
        }

        public ShowBluRayDetailsViewModel(INavigationService navigationService,
                                          IBluRayRepository bluRayRepository)
            : base(navigationService, bluRayRepository)
        {
            _navigationService = navigationService;
            _bluRayRepository = bluRayRepository;

            SaveBluRayCmd = new DelegateCommand(SaveBluRay);
            ReturnToAddBluRayCmd = new DelegateCommand(ReturnToAddBluRay);

            GoToMainMenuCmd = new DelegateCommand(GoToMainMenu);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var bluRayId = parameters.GetValues<int>("BluRayId").ToList().FirstOrDefault();

            if (bluRayId > 0)
            {
                BluRayDetail = _bluRayRepository.GetBluRayDetailsById(bluRayId);
            }
            else
            {
                BluRayDetail = parameters.GetValues<BluRay>("BluRay").ToList().FirstOrDefault();
            }
        }

        // TODO - some type of OnAppearing method which checks - If BluRayDetails.Title Is null then no blu ray found
        // Also make visible / invisible buttons etc

        private void SaveBluRay()
        {
            _bluRayRepository.AddBluRay(BluRayDetail);
            _navigationService.NavigateAsync("ShowOwnedBluRays", new NavigationParameters { { "Title", "Owned BluRays" } });
        }

        private void ReturnToAddBluRay()
        {
            _navigationService.NavigateAsync("AddBluRay", new NavigationParameters { { "Title", "Add BluRay" } });
        }

        private void GoToMainMenu()
        {
            _navigationService.NavigateAsync("MainPage");
        }
    }
}