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
                case "projects":
                    return new LayoutNavigationService<ProjectsViewModel>(
                        navigationStore,
                        () => new ProjectsViewModel());
                case "null side content":
                    return new SideContentNavigationService<ViewModelBase>(
                        navigationStore,
                        () => null);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
