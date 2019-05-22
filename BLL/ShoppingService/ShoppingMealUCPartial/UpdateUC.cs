using BLL.Extensions;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ShoppingService
{
    public partial class ShoppingMealUC
    {
        public ShoppingMealBTO UpdateShoppingMeal(ShoppingMealBTO shoppingMealBto)
        {
            ShoppingMealDTO shoppingMeal;
            if (shoppingMealBto != null)
            {
                shoppingMeal = shoppingMealRepository.Update(shoppingMealBto.BTOToShoppingMealDomain().ShoppingMealDomainToDTO());
                return shoppingMeal?.DTOToShoppingMealDomain().ShoppingMealDomainToBTO() ?? null;
            }
            return null;
        }
    }
}
