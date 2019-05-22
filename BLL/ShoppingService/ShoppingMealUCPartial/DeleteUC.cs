using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ShoppingService
{
    public partial class ShoppingMealUC
    {
        public void DeleteShoppingMeal(int id)
        {
            shoppingMealRepository.Delete(id);
        }
    }
}
