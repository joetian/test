﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // get /api/movies
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();

        }

        // get /api/movies/1
        public Movie GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return movie;
        }

        // post /api/movies
        [HttpPost]   // this will make only post trigger this action, if you name PostMovie, MS will by default add, no need to add [HttpPost]
        public Movie CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie; 
        }

        // put /api/moivie/1
        [HttpPut]
        public void UpdateMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            movieInDb.Name = movie.Name;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.DateAdded = movie.DateAdded;
            _context.SaveChanges();
        }

        // delete /api/movie/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }





    }
}
