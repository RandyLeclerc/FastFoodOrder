using BLL.ShoppingService.Domain;
using Shared.BTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ShoppingService
{
    public partial class BasketUC
    {
        public decimal ComputeTotalValue()
        {
            return shoppingMeals
                .Sum(x => x.Meal.Price * x.Quantity);
        }
    }
}
