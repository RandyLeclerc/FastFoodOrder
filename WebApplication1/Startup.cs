using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Service;
using Microsoft.AspNetCore.Identity.UI.Services;
using DAL.Data;
using DAL;
using DAL.User.Entities;
using BLL.RestaurantService;
using Shared.DataContracts;
using DAL.Restaurants;
using DAL.Cuisines;
using DAL.Pictures;
using DAL.MealTypes;
using DAL.Meals;
using DAL.Baskets;
using DAL.Schedules;

namespace WebApplication1
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

            services.AddDbContext<DAL.Data.ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<RestaurantContextDB>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;
            })
            //services.AddDefaultIdentity<ApplicationUser>(config =>
            //{
            //    config.SignIn.RequireConfirmedEmail = true;
            //})
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //DependancyInjection :
            services.AddTransient<IRestoRepository, RestoRepository>();
            services.AddTransient<ICuisineRepository, CuisineRepository>();
            services.AddTransient<IPictureRepository, PictureRepository>();
            services.AddTransient<IMealTypeRepository, MealTypeRepository>();
            services.AddTransient<IMealRepository, MealRepository>();
            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();



            // requires
            // using Microsoft.AspNetCore.Identity.UI.Services;
            // using WebPWrecover.Services;
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //To use session
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //To use session
            app.UseSession();
            app.UseCookiePolicy();

            app.UseAuthentication();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
