﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeKeeper.Stores;
using TimeKeeper.ViewModels;

namespace TimeKeeper.Services
{
    public class LayoutNavigationService<TViewModel> : INavigate
        where TViewModel : ViewModelBase
    {
        /// <summary>
        /// Used by the navigation service to determine the app's
        /// navigation state.
        /// </summary>
        private readonly NavigationStore _navigationStore;

        /// <summary>
        /// Callback used to create the new view-model.
        /// </summary>
        private readonly Func<TViewModel> _createViewModel;


        /// <summary>
        /// Initializes a new instance of the
        /// <seealso cref="LayoutNavigationService"/>
        /// class.
        /// </summary>
        /// <param name="navigationStore"></param>
        /// <param name="createViewModel"></param>
        public LayoutNavigationService(
            NavigationStore navigationStore,
            Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }


        /// <summary>
        /// Sets the <seealso cref="_navigationStore"/>'s
        /// layout content view-model to the view-model
        /// created by the <seealso cref="_createViewModel"/>
        /// callback.
        /// </summary>
        public void Navigate()
        {
            _navigationStore.CurrentLayoutContentViewModel = _createViewModel();
        }
    }
}
