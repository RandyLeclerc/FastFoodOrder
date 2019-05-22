using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.BTO
{
    public class ShoppingMealBTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int MealId { get; set; }
        public MealBTO Meal { get; set; }
        public int BasketId { get; set; }
        public virtual BasketBTO Basket { get; set; }
    }
}
