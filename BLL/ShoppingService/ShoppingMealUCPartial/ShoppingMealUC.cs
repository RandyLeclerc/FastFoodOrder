using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ShoppingService
{
    public partial class ShoppingMealUC
    {
        private readonly IShoppingMealRepository shoppingMealRepository;

        public ShoppingMealUC(IShoppingMealRepository ShoppingMealRepository)
        {
            shoppingMealRepository = ShoppingMealRepository;
        }
    }
}
