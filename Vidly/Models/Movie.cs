using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie 
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Genre Genre { get; set; }//binded genre and movie classes
        public byte GenreId { get; set; }//its the foreign key
        public DateTime? ReleaseDate { get; set; }//the release date of the movie
        public DateTime? AddDate { get; set; }//the addition date of the movie
        public int Stock { get; set; }//shows how many items are available in stock

    }
}