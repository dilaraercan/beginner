 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Customers" };
            var customers = new List<Customer>
            {
                new Customer{ Name= "John Smith"},
                new Customer{ Name= "Mary Williams"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel); //instead of just sending movie, we send viewModel with movie and customers
        }
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
        public ActionResult Lol()
        {
             return View("~/Views/Movies/Another.cshtml");
        }
        //movies 
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex ={0}&sortBy={1}", pageIndex, sortBy));
        }
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]//new way of routing
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/"+month);
        }

    }
}