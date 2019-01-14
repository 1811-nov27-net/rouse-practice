using Microsoft.EntityFrameworkCore;
using System;

namespace MVCDemo.DataAccess
{
    public class MovieDBContext : DbContext
    {
        // With EF database-first, when our data model needs to change, we make changes to the SQL, then scaffold again overwriting our old C# classes, we do not manually change our C# classes

        // With EF code-first, when our data model needs to change, we make changes the the classes/framework, then run migrations to update the database without destroying it
        // To run migrations:
        //  > Starup project needs Microsoft.EntityFrameworkCore.Tools
        //  > Then run in Package Manage Console, with "default project" set to the project with your DbContext in it, - 

        // If we used EnsuredCreated, we can't use migrations, have to start over
        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options) { }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<CastMember> CastMember { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
