using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
    public class BasketDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserDTO User { get; set; }
        public ICollection<ShoppingMealDTO> ShoppingMeals { get; set; }
        public DateTime ArrivalDate { get; set; }

    }
}
