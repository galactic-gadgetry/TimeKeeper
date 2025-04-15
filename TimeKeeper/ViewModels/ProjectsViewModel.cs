using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TimeKeeper.Commands;
using TimeKeeper.Models;
using TimeKeeper.Models.DTOs;
using TimeKeeper.Services;
using TimeKeeper.Stores;
using TimeKeeper.UIComponents.Dialogs;
using TimeKeeper.Utilities;

namespace TimeKeeper.ViewModels
{
    public class ProjectsViewModel : DefaultViewModelBase
    {
        /// <summary>
        /// Used by the view-model to determine the app's navigation
        /// state.
        /// </summary>
        private readonly NavigationStore _navigationStore;

        /// <summary>
        /// Used by the view-model to navigate to the Project Details
        /// view.
        /// </summary>
        private readonly INavigate _projectDetailsNavigationService;


        // The "{ get; set;}" can be removed when this property
        // is return the BookStore's CurrentBook's Projects property
        // (because it implements the public property's getter/setter.
        public ObservableCollection<Project> Projects { get; set; } = new();


        /// <summary>
        /// Executed when the Create Project button is clicked.
        /// </summary>
        public ICommand CreateProjectButtonClickedCommand { get; }

        /// <summary>
        /// Executed when the project card's Edit button is clicked.
        /// </summary>
        public ICommand ProjectCardEditButtonClickedCommand { get; }

        /// <summary>
        /// Executed when the project card's Name hyperlink is clicked.
        /// </summary>
        public ICommand ProjectCardNameHyperlinkClickedCommand { get; }



        public ProjectsViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            CreateProjectButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnCreateProjectButtonClicked));
            ProjectCardEditButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnProjectCardEditButtonClicked));
            ProjectCardNameHyperlinkClickedCommand = new RelayCommand(
                new Action<object?>(OnProjectCardNameHyperlinkClicked));

            _projectDetailsNavigationService =
                ServiceFactory.CreateNavigationService(
                    "project details",
                    _navigationStore);
        }



        private void CreateNewProjectRequested(CreateNewProject dlg)
        {
            // Create a new Project from the dialog inputs.
            ProjectDTO dto = new()
            {
                Code = dlg.CodeText,
                Name = dlg.NameText,
                Wbs = dlg.WbsText,
            };

            // If the project not be created or added, display an error message.
            Project project = new()
            {
                Code = dto.Code,
                Name = dto.Name,
                Wbs = dto.Wbs,
            };

            Projects.Add(project);
        }


        private void OnCreateProjectButtonClicked(object? obj)
        {
            CreateNewProject dlg = DialogService.PromptUserWithCreateNewProjectDialog();

            if (dlg.DialogResult == true)
            {
                CreateNewProjectRequested(dlg);
            }
        }


        private void OnProjectCardEditButtonClicked(object? obj)
        {
            throw new NotImplementedException();
        }


        private void OnProjectCardNameHyperlinkClicked(object? obj)
        {
            _projectDetailsNavigationService.Navigate();
        }
    }
}
