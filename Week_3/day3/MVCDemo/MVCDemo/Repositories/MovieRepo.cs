using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data = MVCDemo.DataAccess;
using MVCDemo.Models;

namespace MVCDemo.Repositories
{
    public class MovieRepo : IMovieRepo
    {
        private List<Movie> _movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "Star Wars",
                ReleaseDate = new DateTime(1983, 1, 1),
                Cast = { "Mark Hamill", "Carrie Fisher", "Harrison Ford", "James Earl Jones"}
            },
            new Movie
            {
                Id = 2,
                Title = "Lord of the Rings: Fellowship of the Ring",
                ReleaseDate = new DateTime(2001, 1, 1),
                Cast = { "Elijah Wood", "Sean Astin", "Orlando Bloom", "Ian McKellen", "Christopher Lee"}
            }
        };

        public IEnumerable<Movie> GetAll()
        {
            return _movies;
        }

        public Movie GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.Id == id);
        }

        public bool DeleteMovie(int id)
        {
            var movie = GetById(id);
            return _movies.Remove(movie);
        }

        public void CreateMovie(Movie movie)
        {
            if (_movies.Any(m => m.Id == movie.Id))
            {
                throw new ArgumentException($"duplicate ID {movie.Id}");
            }
            _movies.Add(movie);
        }

        public void EditMovie(Movie movie)
        {
            DeleteMovie(movie.Id);
            CreateMovie(movie);
        }

        public IEnumerable<Movie> GetAllByCastMember(string cast)
        {
            throw new NotImplementedException();
        }
    }
}
