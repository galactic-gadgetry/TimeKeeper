using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeKeeper.Stores;

namespace TimeKeeper.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Used by the view-model to determine the main view's
        /// content.
        /// </summary>
        private NavigationStore _navigationStore;


        /// <summary>
        /// Returns the current main content view-model from the
        /// <seealso cref="_navigationStore"/>.
        /// </summary>
        public ViewModelBase? CurrentMainContentViewModel =>
            _navigationStore.CurrentMainContentViewModel;



        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentMainContentViewModelChanged +=
                OnCurrentMainContentViewModelChanged;
        }



        private void OnCurrentMainContentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentMainContentViewModel));
        }
    }
}
