using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyRecipes.Common.Options;
using MyRecipes.Common.Services;
using MyRecipes.Custom;
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
            services.AddDbContext<MyRecipesDbContext>(
                    x => x.UseSqlServer(Configuration.GetConnectionString("MyRecipes"))
                );

            //var cookieExprrTime = Configuration.GetValue<int>("CookieExpirationPeriod");
            //var topRecipesCount = Configuration["SidebarConfig:TopRecipesCount"];

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                    options => {
                        options.ExpireTimeSpan = TimeSpan.FromDays(int.Parse(Configuration["CookieExpirationPeriod"]));
                        options.LoginPath = "/Auth/SignIn";
                        options.AccessDeniedPath = "/Auth/AccessDenied";
                    }
                );

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("IsAdmin", policy =>
            //    {
            //        policy.RequireClaim("IsAdmin", "True");
            //    });
            //});

            //configure options
            services.Configure<SidebarConfig>(Configuration.GetSection("SidebarConfig"));

            //register services
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddTransient<IRecipesService, RecipesService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<ISidebarService, SidebarService>();
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<IRecipeTypesService, RecipeTypesService>();
            services.AddTransient<IRecipeLikesService, RecipeLikesService>();

            //register repositories
            services.AddTransient<IRecipesRepository, RecipesRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<ICommentsRepository, CommentsRepository>();
            services.AddTransient<IRecipeTypesRepository, RecipeTypesRepository>();
            services.AddTransient<IRecipeLikesRepository, RecipeLikesRepository>();
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
                app.UseExceptionHandler("/Info/InternalError");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionLoggingMiddleware>();

            app.UseMiddleware<RequestResponseLogMiddleware>();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Recipes}/{action=Overview}/{id?}");
            });
        }
    }
}
