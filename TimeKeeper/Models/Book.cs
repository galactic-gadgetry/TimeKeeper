using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeKeeper.Models
{
    public enum BookStatus
    {
        Active,
        Archived,
    }



    public class Book
    {
        public bool IsBookVoid = false;
    }
}
