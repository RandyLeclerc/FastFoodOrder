using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.BTO
{
    public class BasketBTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserBTO User { get; set; }
        public ICollection<ShoppingMealBTO> ShoppingMeals { get; set; }
        public DateTime ArrivalDate { get; set; }

    }
}
