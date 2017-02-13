using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            //add using using System.Data.Entity; otherwise error
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);

        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            else
                return View(movie);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var movieFormViewModel = new MovieFormViewModel();
            movieFormViewModel.Genres = genres;
            var movie = new Movie
            {
                Id = 0
            };
            movieFormViewModel.Movie = movie;

            return View("MovieForm", movieFormViewModel);
        }

        public ActionResult Edit(int id)
        {
            var movieFormViewModel = new MovieFormViewModel();
            var movie = _context.Movies.SingleOrDefault(m => m.Id ==id);

            movieFormViewModel.Movie = movie;
            movieFormViewModel.Genres = _context.Genres.ToList();

            return View("MovieForm", movieFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieFormViewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()

                };
                return View("MovieForm", movieFormViewModel);
            }

            if (movie.Id == 0)  // new movie
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);

            }
            else  // update movie
            {
                Movie movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string sErr= string.Empty;
                foreach (DbEntityValidationResult r in ex.EntityValidationErrors)
                {
                    foreach (DbValidationError e in r.ValidationErrors)
                    {
                        sErr = sErr + e.ErrorMessage;
                    }
                }
  
                throw new Exception(sErr, ex);
            }
                


            return RedirectToAction("Index", "Movies");
        }
    }
}