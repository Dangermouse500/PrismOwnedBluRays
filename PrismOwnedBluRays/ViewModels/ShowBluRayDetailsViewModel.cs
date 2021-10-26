using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;
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
        private readonly IDialogService _dialogService;
        private BluRay bluRayDetail;
        private bool saveModeVisibility;

        public bool SaveModeVisible
        {
            get => saveModeVisibility;
            set => SetProperty(ref saveModeVisibility, value);
        }

        public DelegateCommand SaveBluRayCmd { get; set; }
        public DelegateCommand ReturnToAddBluRayCmd { get; set; }
        public DelegateCommand GoToMainMenuCmd { get; set; }
        public BluRay BluRayDetail
        {
            get => bluRayDetail;
            set => SetProperty(ref bluRayDetail, value);
        }

        public ShowBluRayDetailsViewModel(INavigationService navigationService,
                                          IBluRayRepository bluRayRepository,
                                          IDialogService dialogService)
            : base(navigationService, bluRayRepository)
        {
            _navigationService = navigationService;
            _bluRayRepository = bluRayRepository;
            _dialogService = dialogService;

            SaveBluRayCmd = new DelegateCommand(SaveBluRay);
            ReturnToAddBluRayCmd = new DelegateCommand(ReturnToAddBluRay);

            GoToMainMenuCmd = new DelegateCommand(GoToMainMenu);

            Title = "Blu-Ray details";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var bluRayId = parameters.GetValues<int>("BluRayId").ToList().FirstOrDefault();

            SaveModeVisible = (bluRayId == 0);

            // If a blu-ray exists in our database then show it
            if (bluRayId > 0)
            {
                BluRayDetail = _bluRayRepository.GetBluRayDetailsById(bluRayId);
            }
            else
            {
                // This is a blu-ray that the user searched for
                BluRayDetail = parameters.GetValues<BluRay>("BluRay").ToList().FirstOrDefault();
            }
        }

        private void SaveBluRay()
        {
            _bluRayRepository.AddBluRay(BluRayDetail);
            _dialogService.ShowDialog("OkDialogView", new DialogParameters
                {
                    { "Question", "Blu-Ray added successfully." },
                    { "CloseOnTap", true }
                });
            _navigationService.NavigateAsync("ShowOwnedBluRays", new NavigationParameters { { "Title", "Owned Blu-Rays" } });
        }

        private void ReturnToAddBluRay()
        {
            _navigationService.NavigateAsync("AddBluRay", new NavigationParameters { { "Title", "Add Blu-Ray" } });
        }

        private void GoToMainMenu()
        {
            _navigationService.GoBackToRootAsync();
        }
    }
}