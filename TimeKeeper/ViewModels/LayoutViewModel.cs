using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeKeeper.Services;
using TimeKeeper.Stores;
using TimeKeeper.Utilities;

namespace TimeKeeper.ViewModels
{
    public class LayoutViewModel : ViewModelBase
    {

        private readonly BookStore _bookStore;

        /// <summary>
        /// Used by the view-model to determine the app's
        /// navigation state.
        /// </summary>
        private readonly NavigationStore _navigationStore;


        public ViewModelBase? CurrentContentViewModel =>
            _navigationStore.CurrentLayoutContentViewModel;

        /// <summary>
        /// Returns the current navigation bar view-model from the
        /// <seealso cref="_navigationStore"/>.
        /// </summary>
        public ViewModelBase? CurrentNavBarViewModel =>
            _navigationStore.CurrentNavigationBarViewModel;

        /// <summary>
        /// Returns the current side content view-model from the
        /// <seealso cref="_navigationStore"/>.
        /// </summary>
        public ViewModelBase? CurrentSideContentViewModel =>
            _navigationStore.CurrentSideContentViewModel;



        public LayoutViewModel(BookStore bookStore, NavigationStore navigationStore)
        {
            _bookStore = bookStore;
            _navigationStore = navigationStore;

            _navigationStore.CurrentLayoutContentViewModelChanged +=
                OnCurrentLayoutContentViewModelChanged;
            _navigationStore.CurrentNavigationBarViewModelChanged +=
                OnCurrentNavigationBarViewModelChanged;
            _navigationStore.CurrentSideContentViewModelChanged +=
                OnCurrentSideContentViewModelChanged;
        }



        private void NavigateDefaultView()
        {
            /// This is the view-model that will be created in the
            /// case that the <seealso cref="CurrentContentViewModel"/>
            /// is set to null.
            INavigate projectsNavigationService =
                ServiceFactory.CreateNavigationService(
                    "projects",
                    _bookStore,
                    _navigationStore);

            projectsNavigationService.Navigate();
        }


        private void NavigateDefaultViewConstituents()
        {
            INavigate navBarNavigationService =
                ServiceFactory.CreateNavigationService(
                    "navigation bar",
                    _bookStore,
                    _navigationStore);
            INavigate sideContentNavigationService =
                ServiceFactory.CreateNavigationService(
                    "null side content",
                    _bookStore,
                    _navigationStore);

            navBarNavigationService.Navigate();
            sideContentNavigationService.Navigate();
        }


        private void NavigateSettingsViewConstituents()
        {
            INavigate settingsNavBarNavigationService =
                ServiceFactory.CreateNavigationService(
                    "settings navigation bar",
                    _bookStore,
                    _navigationStore);
            INavigate sideContentNavigationService =
                ServiceFactory.CreateNavigationService(
                    "null side content",
                    _bookStore,
                    _navigationStore);

            settingsNavBarNavigationService.Navigate();
            sideContentNavigationService.Navigate();
        }



        private void OnCurrentLayoutContentViewModelChanged()
        {
            if (CurrentContentViewModel is DefaultViewModelBase)
            {
                NavigateDefaultViewConstituents();
            }
            else if (CurrentContentViewModel is SettingsViewModelBase)
            {
                NavigateSettingsViewConstituents();
            }
            else if (CurrentContentViewModel is null)
            {
                NavigateDefaultView();
            }

            OnPropertyChanged(nameof(CurrentContentViewModel));
        }


        /// <summary>
        /// Handles the setting of the current navigation bar
        /// view-model.
        /// </summary>
        private void OnCurrentNavigationBarViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentNavBarViewModel));
        }

        /// <summary>
        /// Handles the setting of the current side content
        /// view-model.
        /// </summary>
        private void OnCurrentSideContentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentSideContentViewModel));
        }
    }
}
