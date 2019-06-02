using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.BTO
{
    public class BasketBTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserBTO User { get; set; }
        public ICollection<ShoppingMealBTO> ShoppingMeals { get; set; }
        [Display(Name = "Arrivale date and time in the restaurant")]
        public DateTime ArrivalDate { get; set; }

    }
}
