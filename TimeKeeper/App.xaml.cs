using System.Configuration;
using System.Data;
using System.Windows;
using TimeKeeper.Services;
using TimeKeeper.Stores;
using TimeKeeper.Utilities;
using TimeKeeper.ViewModels;
using TimeKeeper.Views;

namespace TimeKeeper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly BookStore _bookStore;


        private readonly NavigationStore _navigationStore;



        public App()
        {
            _bookStore = InitializeBookStore();
            _navigationStore =
                (NavigationStore)StoreFactory.CreateNavigationStore();
        }



        protected override void OnStartup(StartupEventArgs e)
        {
            // If the book store's current book is void state, navigate to
            // the Start Screen, otherwise navigate to the Book Details view.
            if (_bookStore.CurrentBook.IsBookVoid)
            {
                INavigate startScreenNavigationService =
                    ServiceFactory.CreateNavigationService(
                        "start screen",
                        _bookStore,
                        _navigationStore);
                startScreenNavigationService.Navigate();
            }
            else
            {
                INavigate layoutNavigationService =
                    ServiceFactory.CreateNavigationService(
                        "layout",
                        _bookStore,
                        _navigationStore);
                INavigate projectsNavigationService =
                    ServiceFactory.CreateNavigationService(
                        "projects",
                        _bookStore,
                        _navigationStore);
                layoutNavigationService.Navigate();
                projectsNavigationService.Navigate();
            }
                

            MainViewModel mainViewModel = new(_navigationStore);
            MainWindow = new MainView()
            {
                DataContext = mainViewModel,
            };
            MainWindow.Show();

            base.OnStartup(e);
        }



        private BookStore InitializeBookStore()
        {
            return StoreFactory.CreateBookStore();
        }
    }

}
