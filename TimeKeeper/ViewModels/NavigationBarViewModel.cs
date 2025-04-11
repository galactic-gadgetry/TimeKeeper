using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TimeKeeper.Commands;
using TimeKeeper.Services;
using TimeKeeper.Stores;
using TimeKeeper.Utilities;

namespace TimeKeeper.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {

        private readonly INavigate _dailyTimesheetNavigationService;


        private readonly INavigate _projectsNavigationService;


        private readonly NavigationStore _navigationStore;


        public ICommand DailyTimesheetButtonClickedCommand { get; }


        public ICommand ProjectsButtonClickedCommand { get; }



        public NavigationBarViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _dailyTimesheetNavigationService =
                ServiceFactory.CreateNavigationService(
                    "daily timesheet",
                    _navigationStore);
            _projectsNavigationService =
                ServiceFactory.CreateNavigationService(
                    "projects",
                    _navigationStore);

            DailyTimesheetButtonClickedCommand =
                new NavigateCommand(_dailyTimesheetNavigationService);
            ProjectsButtonClickedCommand =
                new NavigateCommand(_projectsNavigationService);
        }



        private void OnDailyTimesheetButtonClicked(object? obj)
        {
            _dailyTimesheetNavigationService.Navigate();
        }


        private void OnProjectsButtonClicked(object? obj)
        {
            throw new NotImplementedException();
        }
    }
}
