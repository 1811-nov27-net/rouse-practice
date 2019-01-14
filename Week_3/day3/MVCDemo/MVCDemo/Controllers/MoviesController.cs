using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using MVCDemo.Repositories;

namespace MVCDemo.Controllers
{
    // We can set attribute routing on whole controllers as well
    // The syntax for attribute routing templates is a little different from that for convention-based routing in Startup.cs
    [Route("Movie")]
    public class MoviesController : Controller
    {
        // we get a new Controller constructed for every request

        // Making this static is the quickest way to - 
        // public static MovieRepo Repo { get; set; } = new MovieRepo();

        public IMovieRepo Repo { get; set; }

        public MoviesController(IMovieRepo repo)
        {
            Repo = repo;
        }

        // GET: Movies
        // Show a table of all the movies
        // These attribute routes are appended to the controller's attribute route (with "/")
        [Route("Index")]
        [Route("")]
        public ActionResult Index()
        {

            // "View()" is a method on the base controller class which looks a view with the same name as this method and constructs it with the given parameter, if any
            return View(Repo.GetAll());
        }

        // GET: Movies/Details/5
        // Actions methods get their parameters from route parameters, query string, request body
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = Repo.GetById(id);
            return View(movie);
        }

        // GET: Movies/Create

        // We have attribues that specify which "HTTP method" this action responds to:
        // [HttpGet] (GET method - default)
        // [HttpPost] (Post method - default for form submissions)
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie newMovie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repo.CreateMovie(newMovie);
                }
                else
                {
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Id", ex.Message);
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Edit/5
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var movie = Repo.GetById(id);
            if (movie != null)
            {
                return View(movie);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Movies/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                if (id != movie.Id)
                {
                    ModelState.AddModelError("id", "should match the route id");
                    return View();
                }

                if (ModelState.IsValid)
                {
                    Repo.EditMovie(movie);
                }
                else
                {
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var movie = Repo.GetById(id);
            if (movie != null)
            {
                return View(movie);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Movies/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var success = Repo.DeleteMovie(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}