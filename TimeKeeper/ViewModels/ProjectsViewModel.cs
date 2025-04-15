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

namespace TimeKeeper.ViewModels
{
    public class ProjectsViewModel : DefaultViewModelBase
    {
        // The "{ get; set;}" can be removed when this property
        // is return the BookStore's CurrentBook's Projects property
        // (because it implements the public property's getter/setter.
        public ObservableCollection<Project> Projects { get; set; } = new();



        public ICommand CreateProjectButtonClickedCommand { get; }



        public ProjectsViewModel()
        {
            CreateProjectButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnCreateProjectButtonClicked));
            
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
    }
}
