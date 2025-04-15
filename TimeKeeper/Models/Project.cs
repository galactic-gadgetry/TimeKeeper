using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeKeeper.Models
{
    public enum ProjectStatus
    {
        Active,
        Archived,
    }


    public class Project : INotifyPropertyChanged
    {
        // Backing Fields
        private string code = string.Empty;
        private string name = string.Empty;
        private ProjectStatus status;
        private string wbs = string.Empty;


        /// <summary>
        /// The alpha-numeric code for this record.
        /// </summary>
        public string Code
        {
            get => code;
            set
            {
                code = value;
                OnPropertyChanged(nameof(code));
            }
        }

        /// <summary>
        /// Date and Time that this record was created.
        /// </summary>
        public DateTime CreatedDateTime { get; init; }

        /// <summary>
        /// Returns the day, month, and year string (dd Month year) of the
        /// <seealso cref="CreatedDateTime"/> property.
        /// </summary>
        public string CreateDateString =>
            CreatedDateTime.ToString("dd MMMM yyyy");

        /// <summary>
        /// Unique identifier for this record.
        /// </summary>
        public Guid ID { get; init; }

        /// <summary>
        /// Name for this record.
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Status of this record.
        /// </summary>
        public ProjectStatus Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        /// <summary>
        /// Returns the string of the
        /// <seealso cref="Status"/> property.
        /// </summary>
        public string StatusText => Status.ToString();


        /// <summary>
        /// Unique WBS code from this record.
        /// </summary>
        public string Wbs
        {
            get => wbs;
            set
            {
                wbs = value;
                OnPropertyChanged(nameof(Wbs));
            }
        }


        
        public event PropertyChangedEventHandler? PropertyChanged;



        public Project()
        {
            CreatedDateTime = DateTime.Now;
            ID = Guid.NewGuid();
            Status = ProjectStatus.Active;
        }


        /// <summary>
        /// Handles the <seealso cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName"></param>
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
