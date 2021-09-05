using Prism.Mvvm;
using Prism.Navigation;
using PrismOwnedBluRays.Repositories;

namespace PrismOwnedBluRays.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        protected IBluRayRepository BluRayRepositoryService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService,
                             IBluRayRepository bluRayRepositoryService
            )
        {
            NavigationService = navigationService;
            BluRayRepositoryService = bluRayRepositoryService;

            // Set page title dynamically here if possible?
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}