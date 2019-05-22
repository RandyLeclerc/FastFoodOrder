using DAL.Baskets.Entities;
using DAL.Meals.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ShoppingMeals.Entities
{
    public class ShoppingMeal
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }
        public int BasketId { get; set; }
        public virtual Basket Basket { get; set; }
    }
}
