using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.Repositories;

namespace MVCDemo.Controllers
{
    public class CastController : Controller
    {
        public IMovieRepo Repo { get; set; }

        // Dependency injection, based in Startup.ConfigureServices
        public CastController(IMovieRepo repo)
        {
            Repo = repo;
        }

        // We have two basic types of routing in ASP.NET

        // 1: Convention Routing - defined globally in Startup.cs
        // 2: Attribute Routing - 

        // Routing is how ASP.NET decides, based on the URL (and the HTTP method) which controller to construct and which action method to call

        // Route parameter "name" defined in my route will end up here
        [Route("MoviesWithActor/{name}"), Name = "cast_attr"]
        public IActionResult Index(string name)
        {
            var movies = Repo.GetAllByCastMember(name).ToList();
            // ^ A ToList here would enable me to debug the LINQ stuff since the iteration happens in my code and not in the View redering code
            return View(movies);
        }
    }
}