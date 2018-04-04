using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie 
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Genre Genre { get; set; }//binded genre and movie classes

        [Display(Name = "Genre Type")]
        public byte GenreId { get; set; }//its the foreign key

        [Display(Name = "Date of Release")] 
        public DateTime? ReleaseDate { get; set; }//the release date of the movie

        [Display(Name = "Date of Addition")]
        public DateTime? AddDate { get; set; }//the addition date of the movie
        public int Stock { get; set; }//shows how many items are available in stock

    }
}