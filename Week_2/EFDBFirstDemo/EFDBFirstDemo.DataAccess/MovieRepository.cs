using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDBFirstDemo.DataAccess
{
    public class MovieRepository : IMovieRepository
    {
        public MoviesDBContext Db { get; }

        public IList<Movie> GetAllMovies()
        {


        }

        public IList<Movie> GetAllMoviesWithGenres()
        {

        }

        public Movie GetMovieById(int id)
        {

        }

        public Movie GetMovieByName(string name)
        {

        }

        public void DeleteMovie(Movie movie)
        {

        }

        public void EditMovie(Movie movie)
        {

        }

        public void CreateMovie(Movie movie)
        {
            Db.Add(movie);
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }
    }
}
