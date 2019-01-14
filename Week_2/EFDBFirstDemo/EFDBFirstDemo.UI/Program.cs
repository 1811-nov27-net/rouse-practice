using EFDBFirstDemo.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFDBFirstDemo.UI
{
    class Program
    {
        static DbContextOptions<MoviesDBContext> options = null;

        static void Main(string[] args)
        {
            var connectionString = SecretConfiguration.ConnectionString;

            var optionsBuilder = new DbContextOptionsBuilder<MoviesDBContext>();
            optionsBuilder.UseSqlServer(connectionString);
            options = optionsBuilder.Options;

            PrintMovies();
            AddAMovie();

            Console.WriteLine();

            PrintMovies();
        }

        static void PrintMovies()
        {
            var movies = new List<Movie>();

            using (var db = new MoviesDBContext(options))
            {
                // At this point we haven't connected to the database yet

                // This ends up getting read as "SELECT * FROM Movies.Movie" somewhere
                movies = db.Movie.ToList();
                // ^ This does not fetch the full "entity graph" of the movie - "navigation properties" like Genre are null

                // This ends up as a SELECT with a join
                movies = db.Movie.Include(m => m.Genre).ToList();
                // ^ With .Include, we fetch the related properties so they are not null

                // Entity Framework ...
                movies = db.Movie.Include(m => m.Genre).ToList();
            }

            foreach (var item in movies)
            {
                Console.WriteLine($"Movie ID: {item.Id}, Name: {item.Name}, Genre: {item.Genre.Name}");
            }
        }

        static void AddAMovie()
        {
            using (var db = new MoviesDBContext(options))
            {
                // Get first alphabetical name (no network access yet)
                var firstMovieQuery = db.Movie.Include(m => m.Genre).OrderBy(m => m.Name);

                // Fetches only the first movie, not all of them
                Movie movie = firstMovieQuery.First();

                Movie newMovie = new Movie { Name = movie.Name + " 2: Electric Boogaloo", Genre = movie.Genre };

                // There are a few different ways to add the new movie
                db.Add(newMovie);  // This one guesses which DbSet based on the type
                                   // db.Movie.Add(newMovie);

                // We can add the movie to the genre's navigation property "Movie" collection
                // movie.Genre.Movie.Add(newMovie);

                // After any of those, the database change is recorded in the DbContext, but not yet committed to the database

                // SaveChanges applies all the tracked changes in one transaction
                db.SaveChanges();

                // Extra properties on the new movie that we didn't set

                // (You can continue working and save changes multiplte times on one DbContext)
            }

            // Objects you get out of the DbSets are "tracked" by the context, any changes you make to them will be noticed ans applied to the database on the next SaveChanges

            // Objects you create yourself are NOT tracked - track them with db.Add, db.Update, or adding them to a tracked entity's navigation property
        }

        static void EditSomething()
        {
            using (var db = new MoviesDBContext(options))
            {
                // This will be executed right away
                Genre actionGenre = db.Genre.FirstOrDefault(g => g.Name == "Action");
                // First will throw an exception if it doesn't find anything, FirstOrDefault will return null

                if (actionGenre != null)
                {
                    actionGenre.Name = "Action/Adventure";

                    // Because actionGenre is tracked ...
                    db.SaveChanges();
                }
            }
        }
    }
}
