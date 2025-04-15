using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeKeeper.Models;

namespace TimeKeeper.Stores
{
    public class BookStore
    {
        // Backing Fields
        private Book currentBook;



        public Book CurrentBook
        {
            get => currentBook;
            set
            {
                currentBook = value;
                OnCurrentBookChanged();
            }
        }



        public event Action? CurrentBookChanged;



        public BookStore()
        {
            currentBook = new Book() { IsBookVoid = true };
        }



        private void OnCurrentBookChanged()
        {
            CurrentBookChanged?.Invoke();
        }
    }
}
