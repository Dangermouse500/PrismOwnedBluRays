using Prism;
using Prism.Ioc;
using PrismOwnedBluRays.Dialogs;
using PrismOwnedBluRays.Repositories;
using PrismOwnedBluRays.ViewModels;
using PrismOwnedBluRays.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace PrismOwnedBluRays
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterSingleton<IBluRayRepository, BluRayRepository>();

            containerRegistry.RegisterDialog<OkDialogView>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ShowOwnedBluRays, ShowOwnedBluRaysViewModel>();
            containerRegistry.RegisterForNavigation<AddBluRay, AddBluRayViewModel>();
            containerRegistry.RegisterForNavigation<ShowBluRayDetails, ShowBluRayDetailsViewModel>();
        }
    }
}