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
        /// <summary>
        /// Used by the view-model to navigate to the Daily Timesheet
        /// view.
        /// </summary>
        private readonly INavigate _dailyTimesheetNavigationService;

        /// <summary>
        /// Used by the view-model to determine the app's navigation
        /// state.
        /// </summary>
        private readonly NavigationStore _navigationStore;

        /// <summary>
        /// Used by the view-model to navigate to the Projects view.
        /// </summary>
        private readonly INavigate _projectsNavigationService;


        // Backing Fields
        private bool isDailyTimesheetTabSelected = false;
        private bool isProjectsTabSelected = false;


        /// <summary>
        /// True if the <seealso cref="_navigationStore"/>'s
        /// <see cref="NavigationStore.CurrentLayoutContentViewModel"/> is
        /// set to an instance of <see cref="DailyTimesheetViewModel"/>,
        /// false otherwise.
        /// </summary>
        public bool IsDailyTimesheetTabSelected
        {
            get => isDailyTimesheetTabSelected;
            set
            {
                isDailyTimesheetTabSelected = value;
                OnPropertyChanged(nameof(IsDailyTimesheetTabSelected));
            }
        }

        /// <summary>
        /// True if the <seealso cref="_navigationStore"/>'s
        /// <see cref="NavigationStore.CurrentLayoutContentViewModel"/> is
        /// set to an instance of <see cref="ProjectsViewModel"/>,
        /// false otherwise.
        /// </summary>
        public bool IsProjectsTabSelected
        {
            get => isProjectsTabSelected;
            set
            {
                isProjectsTabSelected = value;
                OnPropertyChanged(nameof(IsProjectsTabSelected));
            }
        }


        /// <summary>
        /// Executed when the Daily Timesheet button is clicked.
        /// </summary>
        public ICommand DailyTimesheetButtonClickedCommand { get; }

        /// <summary>
        /// Navigates to the Daily Timesheet view.
        /// </summary>
        public ICommand NavigateDailyTimesheetButtonClickedCommand { get; }

        /// <summary>
        /// Navigates to the Projects view.
        /// </summary>
        public ICommand NavigateProjectsButtonClickedCommand { get; }

        /// <summary>
        /// Executed when the Projects button is clicked.
        /// </summary>
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

            DailyTimesheetButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnDailyTimesheetButtonClicked));
            ProjectsButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnProjectsButtonClicked));


            NavigateDailyTimesheetButtonClickedCommand =
                new NavigateCommand(_dailyTimesheetNavigationService);
            NavigateProjectsButtonClickedCommand =
                new NavigateCommand(_projectsNavigationService);

            _navigationStore.CurrentLayoutContentViewModelChanged +=
                OnCurrentLayoutContentViewModelChanged;

            SetSelectedTab();
        }


        private void DeselectAllTabs()
        {
            IsDailyTimesheetTabSelected = false;
            IsProjectsTabSelected = false;
        }

        /// <summary>
        /// Handles the setting of the current layout content
        /// view-model.
        /// </summary>
        private void OnCurrentLayoutContentViewModelChanged()
        {
            SetSelectedTab();
        }

        /// <summary>
        /// Handles the Daily Timesheet button tab clicked event.
        /// </summary>
        /// <param name="obj"></param>
        private void OnDailyTimesheetButtonClicked(object? obj)
        {
            NavigateDailyTimesheetButtonClickedCommand?.Execute(obj);
        }

        /// <summary>
        /// Handles the Projects button tab clicked event.
        /// </summary>
        /// <param name="obj"></param>
        private void OnProjectsButtonClicked(object? obj)
        {
            NavigateProjectsButtonClickedCommand?.Execute(obj);
        }


        private void SetSelectedTab()
        {
            DeselectAllTabs();

            switch (_navigationStore.CurrentLayoutContentViewModel)
            {
                case DailyTimesheetViewModel:
                    IsDailyTimesheetTabSelected = true;
                    break;
                case ProjectsViewModel:
                    IsProjectsTabSelected = true;
                    break;
                default:
                    return;
            }
        }
    }
}
