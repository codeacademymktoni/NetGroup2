using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyRecipes.Repositories;
using MyRecipes.Repositories.Interfaces;
using MyRecipes.Services;
using MyRecipes.Services.Interfaces;

namespace MyRecipes
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
            //Install ef core
            //Install ef core sql server
            //Install ef core tools 

            //create db context class that inherits from DbContext
            //add constructor in db context class
            //    public MyRecipesDbContext(DbContextOptions<MyRecipesDbContext> options): base(options)
            //{ }

            //configure in startup
            //see configuration below 
            services.AddDbContext<MyRecipesDbContext>(
                    x => x.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MyRecipes;Trusted_Connection=True;")
                );

            services.AddControllersWithViews();
            services.AddTransient<IRecipesService, RecipesService>();
            services.AddTransient<IRecipesRepository, RecipesRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Recipes}/{action=Overview}/{id?}");
            });
        }
    }
}
