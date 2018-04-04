using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel//now we have binded movie and genre
    {
        public IEnumerable<Genre> GenreIds { get; set;}
        public Movie Movie { get; set; }
        public int? Id { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
    }
   
}