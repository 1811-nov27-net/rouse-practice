using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Data = MVCDemo.DataAccess;
using MVCDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCDemo.Repositories
{
    public class MovieRepoDB : IMovieRepo
    {
        private readonly Data.MovieDBContext _db;

        public MovieRepoDB(Data.MovieDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            db.Database.EnsureCreated();
        }

        public void CreateMovie(Movie movie)
        {
            // Ignores cast members
            _db.Add(Map(movie));
            _db.SaveChanges();
        }


        public bool DeleteMovie(int id)
        {
            try
            {
                var movie = _db.Movie.Include(m => m.CastMemberJunctions).First(m => m.Id == id);
                _db.Remove(_db.Movie.Find(id));

                foreach (var item in )
                _db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        // Adds if ID is set to 0
        public void EditMovie(Movie movie)
        {
            _db.Update(Map(movie));
            _db.SaveChanges();
        }

        public IEnumerable<Movie> GetAll()
        {
            return _db.Movie.Include(m => m.CastMemberJunctions).ThenInclude(j => j.CastMember).Select(Map);
        }

        public IEnumerable<Movie> GetAllByCastMember(string cast)
        {
            return _db.CastMember
                .Include(c => c.MovieJunctions)
                    .ThenInclude(j => j.Movie) // Fills in navigation property of a navigation property
                        .ThenInclude(m => m.CastMemberJunctions)
                            .ThenInclude(j => j.CastMember)
                .Where(c => c.Name == cast)
                .ToList()
                .SelectMany(c => c.MovieJunctions.Select(j => Map(j.Movie)));
            // SelectMany is a version of Select that produces multiple things from each element - 
        }

        public Movie GetById(int id)
        {
            return Map(_db.Movie
                    .Include(m => m.CastMemberJunctions)
                        .ThenInclude(j => j.CastMember)
                    .First(m => m.Id == id));
        }

        public static Movie Map(Data.Movie data)
        {
            return new Movie
            {
                Id = data.Id,
                Title = data.Title,
                ReleaseDate = data.ReleaseDate,
                Cast = data.CastMemberJunctions.Select(j => j.CastMember.Name).ToList()
            };
        }

        public static Data.Movie Map(Movie ui)
        {
            return new Data.Movie
            {
                Id = ui.Id,
                Title = ui.Title,
                ReleaseDate = ui.ReleaseDate
            };
        }
    }
}
