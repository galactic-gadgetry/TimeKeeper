﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeKeeper.ViewModels;

namespace TimeKeeper.Stores
{
    public class NavigationStore
    {
        // Backing Fields
        private ViewModelBase? currentLayoutContentViewModel;
        private ViewModelBase? currentMainContentViewModel;
        private ViewModelBase? currentNavigationBarViewModel;
        private ViewModelBase? currentSideContentViewModel;


        /// <summary>
        /// View-model used to determine the <see cref="Layout"/>'s
        /// content.
        /// </summary>
        public ViewModelBase? CurrentLayoutContentViewModel
        {
            get => currentLayoutContentViewModel;
            set
            {
                currentLayoutContentViewModel = value;
                OnCurrentLayoutContentViewModelChanged();
            }
        }

        /// <summary>
        /// View-model used to determine the <see cref="MainView"/>'s
        /// content.
        /// </summary>
        public ViewModelBase? CurrentMainContentViewModel
        {
            get => currentMainContentViewModel;
            set
            {
                currentMainContentViewModel = value;
                OnCurrentMainContentViewModelChanged();
            }
        }

        /// <summary>
        /// View-model used to determine the Navigation Bar's content.
        /// </summary>
        public ViewModelBase? CurrentNavigationBarViewModel
        {
            get => currentNavigationBarViewModel;
            set
            {
                currentNavigationBarViewModel = value;
                OnCurrentNavigationBarViewModelChanged();
            }
        }

        /// <summary>
        /// View-model used to determine the Side Content area's
        /// content.
        /// </summary>
        public ViewModelBase? CurrentSideContentViewModel
        {
            get => currentSideContentViewModel;
            set
            {
                currentSideContentViewModel = value;
                OnCurrentSideContentViewModelChanged();
            }
        }


        /// <summary>
        /// Raised when the <seealso cref="CurrentLayoutContentViewModel"/>
        /// is set.
        /// </summary>
        public Action? CurrentLayoutContentViewModelChanged;

        /// <summary>
        /// Raised when the <seealso cref="CurrentMainContentViewModel"/>
        /// is set.
        /// </summary>
        public Action? CurrentMainContentViewModelChanged;

        /// <summary>
        /// Raised when the <seealso cref="CurrentNavigationBarViewModel"/>
        /// is set.
        /// </summary>
        public Action? CurrentNavigationBarViewModelChanged;

        /// <summary>
        /// Raised when the <seealso cref="CurrentSideContentViewModel"/>
        /// is set.
        /// </summary>
        public Action? CurrentSideContentViewModelChanged;

        /// <summary>
        /// Raised when the <seealso cref="ViewModelBase.OnInfoUpdated(string)"/>
        /// event is raised.
        /// </summary>
        public event EventHandler<string>? InfoUpdated;


        /// <summary>
        /// Handles the setting of the current layout content
        /// view-model.
        /// </summary>
        private void OnCurrentLayoutContentViewModelChanged()
        {
            if (CurrentLayoutContentViewModel != null)
            {
                CurrentLayoutContentViewModel.InfoUpdated +=
                    OnInfoUpdated;
            }
            CurrentLayoutContentViewModelChanged?.Invoke();
        }

        /// <summary>
        /// Handles the setting of the current main content
        /// view-model.
        /// </summary>
        private void OnCurrentMainContentViewModelChanged()
        {
            if (CurrentMainContentViewModel != null)
            {
                CurrentMainContentViewModel.InfoUpdated +=
                    OnInfoUpdated;
            }
            CurrentMainContentViewModelChanged?.Invoke();
        }

        /// <summary>
        /// Handles the setting of the current navigation bar content
        /// view-model.
        /// </summary>
        private void OnCurrentNavigationBarViewModelChanged()
        {
            CurrentNavigationBarViewModelChanged?.Invoke();
        }

        /// <summary>
        /// Handles the setting of the current side content
        /// view-model.
        /// </summary>
        private void OnCurrentSideContentViewModelChanged()
        {
            CurrentSideContentViewModelChanged?.Invoke();
        }

        /// <summary>
        /// Handles the content view-models'
        /// <see cref="ViewModelBase.InfoUpdated"/> event being
        /// raised.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="info"></param>
        private void OnInfoUpdated(object? sender, string info)
        {
            InfoUpdated?.Invoke(this, info);
        }
    }
}
