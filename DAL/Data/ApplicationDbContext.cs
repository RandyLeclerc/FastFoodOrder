using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DAL.User.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Restaurants.Entities;
using DAL.Cuisines.Entities;
using DAL.Pictures.Entities;
using DAL.MealTypes.Entities;
using DAL.Meals.Entities;
using DAL.ShoppingMeals.Entities;
using DAL.Baskets.Entities;

namespace DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<RestaurantCuisine> RestaurantCuisines { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<ShoppingMeal> ShoppingMeals { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        //To add relations between restaurant and cuisine
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RestaurantCuisine>()
                .HasKey(bc => new { bc.RestaurantId, bc.CuisineId });

            modelBuilder.Entity<RestaurantCuisine>()
                .HasOne(rc => rc.Restaurant)
                .WithMany(b => b.RestaurantCuisines)
                .HasForeignKey(bc => bc.RestaurantId);

            modelBuilder.Entity<RestaurantCuisine>()
                .HasOne(bc => bc.Cuisine)
                .WithMany(c => c.RestaurantCuisines)
                .HasForeignKey(bc => bc.CuisineId);
        }
    }
}
