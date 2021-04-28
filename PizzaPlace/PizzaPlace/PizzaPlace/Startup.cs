using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaPlace.Models;
using PizzaPlace.Repositories;
using PizzaPlace.Repositories.Interfaces;
using PizzaPlace.Services;
using PizzaPlace.Services.Interfaces;
using System;

namespace PizzaPlace
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
            services.AddDbContext<PizzaPlaceDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("PizzaPlaceDb"));
            });

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<PizzaPlaceDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
            });

            //services.Configure<IdentityOptions>(options => {
            //    options.SignIn.RequireConfirmedAccount = true;
            //    options.User.RequireUniqueEmail = true;
            //    options.Password.RequireDigit = true;
            //    options.Password.RequireNonAlphanumeric = true;
            //    options.Password.RequireUppercase = true;
            //});

            //services.AddAuthentication().AddGoogle(options =>
            //{
            //    IConfigurationSection googleAuthNSection =
            //        Configuration.GetSection("Authentication:Google");

            //    options.ClientId = googleAuthNSection["ClientId"];
            //    options.ClientSecret = googleAuthNSection["ClientSecret"];
            //});

            services.AddRazorPages().AddRazorPagesOptions(options => {
                //options.RootDirectory = "/Views";
                options.Conventions.AddPageRoute("/Home", "");
            });

            //services
            services.AddTransient<IOfferService, OfferService>();
            services.AddTransient<IMenuItemService, MenuItemService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            

            //repositories
            services.AddTransient<IOffersRepository, OffersRepository>();
            services.AddTransient<IMenuItemRepository, MenuItemRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
