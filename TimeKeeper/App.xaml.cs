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

        private readonly NavigationStore _navigationStore;



        public App()
        {
            _navigationStore =
                (NavigationStore)StoreFactory.CreateNavigationStore();
        }



        protected override void OnStartup(StartupEventArgs e)
        {
            INavigate layoutNavigationService =
                ServiceFactory.CreateNavigationService("layout", _navigationStore);
            INavigate projectsNavigationService =
                ServiceFactory.CreateNavigationService("projects", _navigationStore);
            layoutNavigationService.Navigate();
            projectsNavigationService.Navigate();
                

            MainViewModel mainViewModel = new(_navigationStore);
            MainWindow = new MainView()
            {
                DataContext = mainViewModel,
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
