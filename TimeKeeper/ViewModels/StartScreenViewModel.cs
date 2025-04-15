using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TimeKeeper.Commands;
using TimeKeeper.Services;

namespace TimeKeeper.ViewModels
{
    public class StartScreenViewModel : ViewModelBase
    {

        public ICommand LoadExistingLogBookButtonClickedCommand { get; }


        public ICommand NewLogBookButtonClickedCommand { get; }



        public StartScreenViewModel()
        {
            LoadExistingLogBookButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnLoadExistingLogBookButtonClicked));
            NewLogBookButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnNewLogBookButtonClicked));
        }



        private void OnLoadExistingLogBookButtonClicked(object? obj)
        {
            throw new NotImplementedException();
        }


        private void OnNewLogBookButtonClicked(object? obj)
        {
            throw new NotImplementedException();
        }
    }
}
