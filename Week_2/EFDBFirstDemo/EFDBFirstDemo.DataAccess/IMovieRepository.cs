using EFDBFirstDemo.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDBFirstDemo.DataAccess
{
    public interface IMovieRepository
    {
        // The repository pattern abstracts the details of data access to its consumers and provides simple "CRUD" type methods:
        //  Create
        //  Read
        //  Update
        //  Delete
        // And hide the details of which database, even if it is a database, are we using ADO.NET, are we using Entity Framework, etc

        IList<Movie> GetAllMovies();

        IList<Movie> GetAllMoviesWithGenres();

        Movie GetMovieById(int id);

        Movie GetMovieByName(string name);

        void DeleteMovie(Movie movie);

        void EditMovie(Movie movie);

        void CreateMovie(Movie movie);
    }
}
