using System;
using System.Collections.Generic;
using System.Linq; 
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()//index: açılış sayfasında getmovies methodu return
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();

            return View(movies);
        }

        public ActionResult MovieDetails(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if(movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
     /*   private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie{ Id=1,Name="Shrek"},
                new Movie{Id=2,Name="Wall-e"}
            };
        }*/ 
        //GET: Movies/Random 
        public ActionResult Random()//random döndürülecek
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer{Name="Customer 1"},
                new Customer{Name="Customer 2"}
            };
            var ViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(ViewModel);
        }

    }
}