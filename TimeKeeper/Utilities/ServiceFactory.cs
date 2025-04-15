using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeKeeper.Services;
using TimeKeeper.Stores;
using TimeKeeper.ViewModels;

namespace TimeKeeper.Utilities
{
    public static class ServiceFactory
    {

        public static INavigate CreateNavigationService(
            string type, NavigationStore navigationStore)
        {
            switch (type.ToLower())
            {
                case "daily timesheet":
                    return new LayoutNavigationService<DailyTimesheetViewModel>(
                        navigationStore,
                        () => new DailyTimesheetViewModel());
                case "layout":
                    return new NavigationService<LayoutViewModel>(
                        navigationStore,
                        () => new LayoutViewModel(navigationStore));
                case "navigation bar":
                    return new NavBarNavigationService<NavigationBarViewModel>(
                        navigationStore,
                        () => new NavigationBarViewModel(navigationStore));
                case "null side content":
                    return new SideContentNavigationService<ViewModelBase>(
                        navigationStore,
                        () => null);
                case "project details":
                    return new LayoutNavigationService<ProjectDetailsViewModel>(
                        navigationStore,
                        () => new ProjectDetailsViewModel());
                case "projects":
                    return new LayoutNavigationService<ProjectsViewModel>(
                        navigationStore,
                        () => new ProjectsViewModel(navigationStore));
                case "settings navigation bar":
                    return new NavBarNavigationService<SettingsNavigationBarViewModel>(
                        navigationStore,
                        () => new SettingsNavigationBarViewModel());
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
