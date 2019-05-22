using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
    public class ShoppingMealDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int MealId { get; set; }
        public MealDTO Meal { get; set; }
        public int BasketId { get; set; }
        public virtual BasketDTO Basket { get; set; }
    }
}
