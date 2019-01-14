using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCDemo.DataAccess;
using MVCDemo.Models;
using MVCDemo.Repositories;

namespace MVCDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Here we provide "services" to be injected to classes that require them at runtime

            services.AddScoped<IMovieRepo, MovieRepoDB>();

            // Three liftimes for a service
            //  Scoped (AddScoped)           one instance of this object will be shared to all who need it wirhing the spam of this rquest
            //  Transient (AddTransient)     a new instance of the object every time, for every new object who wants one
            //  Singleton (AddSingleton)     only one instance ever, across however many requests

            // Keep dependencies in mind when assigning lifetimes



            services.AddDbContext<MovieDBContext>(optionsBuilder =>
                optionsBuilder.UseSqlServer(
                    Configuration.GetConnectionString("CodeFirstTest_2")));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            // Here is our global convention routing
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "cast",
                    template: "Actors/{name}",
                    defaults: new { controller = "Cast", action = "Index" });
            
                // V Generated Routes V
                // One route is defined: Controller name (via built-in 'controller' variable) / Action name (method, via built-in 'action' variable) / Route parameter called id (optional)
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                // ?: optional (ex: 'id' is optional)
                // =[name]: defaults to object with given name (ex: controller defaults to 'Home' if not given a name)
            });
        }
    }
}
