using Moq;
using MVCDemo.Controllers;
using data = MVCDemo.DataAccess;
using MVCDemo.Models;
using MVCDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MVCDemo.Testing.MVC.Controllers
{
    // Unit testing with fakes is correct, but cumbersome; consider using mocks instead
    //public class FakeMovieRepo : IMovieRepo
    //{
    //    public void CreateMovie(Models.Movie movie)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool DeleteMovie(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void EditMovie(Models.Movie movie)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Models.Movie> GetAll()
    //    {
    //        return new List<Movie>
    //        {
    //            new Movie {}
    //        }
    //    }

    //    public IEnumerable<Models.Movie> GetAllByCastMember(string cast)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Models.Movie GetById(int id)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class MoviesControllerTests
    {
        // tests that when the movie has repositories to give, we'll get an index view with a model (IEnumerable<movie>) containing those movies
        [Fact]
        public void IndexWithMoviesHasMovies()
        {
            // Arrange
            //var db = new MovieDBContext();
            //var repo = new MovieRepoDB();
            //var controller = new MoviesController(repo);
            // At this point we are not really doing a unit test, this is really more of an integration test
            // To unit test something like MVC, that uses dependency injection (or really in general), with complex (or any) dependencies we will use mocking (with the Moq framework)

            // If we didn't having a mocking framework, we would use fakes like this
            //var fakeRepo = new FakeMovieRepo();
            //var controller = new MoviesController(fakeRepo);
            // Because dependcy inversion is used (controller depends on an interface, not a concrete class), we can provide a different implementation without breaking or chagning the controller
            // Dependency injection is when a framework automatically constructs objects requested (e.g. as constructor parameters) instead of YOUR objects constructing them themselves

            var data = new List<Movie> { new Movie { Id = 1, Title = "Star Wars" } };
        
            var mockRepo = new Mock<IMovieRepo>();
            mockRepo
                .Setup(repo => repo.GetAll())
                .Returns(data);

            mockRepo
                .Setup(repo => repo.GetById(1))
                .Returns(data[0]);
            // You mock the methods that you expect the SUT's (Subject Under Test) code to call, you don't need to mock the other ones unless you're truly blind-testing the implementation of the controller

            // It's possible to setup a mock so it verifies that certain methods have been called, if you just want a method to be callable without throwing an exception

            mockRepo
                .Setup(repo => repo.CreateMovie(It.IsAny<int>()));


            var controller = new MoviesController(mockRepo.Object);


            // Act

            // Need package reference Microsoft.AspNetCore.Mvc.ViewFeatures
            ActionResult result = controller.Index();

            // Assert

            // Simple way to cast - throws exception if failure
            //ViewResult = (ViewResult)result;

            // This asserts that the cast succeed and also returns the casted value
            ViewResult viewResult = Assert.IsAssignableFrom<ViewResult>(result);

            var movies = Assert.IsAssignableFrom<IEnumerable<movie>>(viewResult.result);
            var moviesList = movies.ToList();

            Assert.Equal(data.Count, moviesList.Count);

            for (int i = 0; i < data.Count; i++)
            {
                Assert.Equal(data[i].Id, moviesList[i].Id);
            }
        }
    }
}
