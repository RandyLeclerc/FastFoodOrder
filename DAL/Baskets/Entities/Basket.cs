using DAL.User.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.ShoppingMeals.Entities;

namespace DAL.Baskets.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public ICollection<ShoppingMeal> ShoppingMeals { get; set; }
    }
}
