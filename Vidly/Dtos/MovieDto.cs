using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        [Required]
        public byte GenreId { get; set; }//its the foreign key

        public DateTime? ReleaseDate { get; set; }//the release date of the movie

        public DateTime? AddDate { get; set; }//the addition date of the movie

        [Range(0, 20)]
        public int Stock { get; set; }//shows how many items are available in stock
    }
}