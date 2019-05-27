using BLL.UserService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ShoppingService.Domain
{
    public class BasketDomain
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUserDomain User { get; set; }
        public ICollection<ShoppingMealDomain> ShoppingMeals { get; set; }
        public DateTime ArrivalDate { get; set; }

    }
}
