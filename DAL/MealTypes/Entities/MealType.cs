using DAL.Meals.Entities;
using DAL.Restaurants.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.MealTypes.Entities
{
    public class MealType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RestaurantId { get; set; }
        [Required]
        public Restaurant Restaurant { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
