using System;
using System.Collections.Generic;
using System.Linq; 
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

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
        public ViewResult New()//we have created viewmodel to bind two models
        {
            var genreIds = _context.GenreIds.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                GenreIds = genreIds
            };
            return View("NewMovie", viewModel);
        }

        [HttpPost]//this is to submit data to a specified resource
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)//change the flow
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    GenreIds = _context.GenreIds.ToList()
                };
                return View("NewMovie", viewModel);//if its not valid, it returns to the form again
            }
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Stock = movie.Stock;
            }
            _context.SaveChanges();//save to the Db

            return RedirectToAction("Index", "Movies");//redirected to the movies index view 
        }

        public ViewResult Index()//index: açılış sayfasında getmovies methodu return
        {
            return View();
        }

        public ActionResult MovieDetails(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                GenreIds = _context.GenreIds.ToList()
            };

            return View("NewMovie", viewModel);
        }

    }
}
        /*public ActionResult Random()//random döndürülecek
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
        }*/ 

    
