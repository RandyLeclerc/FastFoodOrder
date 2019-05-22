using BLL.RestaurantService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ShoppingService.Domain
{
    public class ShoppingMealDomain
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int MealId { get; set; }
        public MealDomain Meal { get; set; }
        public int BasketId { get; set; }
        public virtual BasketDomain Basket { get; set; }
    }
}
