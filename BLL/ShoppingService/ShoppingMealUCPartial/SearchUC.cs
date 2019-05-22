using BLL.Extensions;
using Shared.BTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ShoppingService
{
    public partial class ShoppingMealUC
    {
        public ICollection<ShoppingMealBTO> GetAllShoppingMeals()
        {
            var ShoppingMeals = shoppingMealRepository.GetAll();
            var result = ShoppingMeals.Select(x => x.DTOToShoppingMealDomain().ShoppingMealDomainToBTO()).ToList();
            return result;
        }
        public ShoppingMealBTO GetShoppingMealById(int id)
        {
            var ShoppingMeal = shoppingMealRepository.GetById(id);
            return ShoppingMeal.DTOToShoppingMealDomain().ShoppingMealDomainToBTO();
        }






    }
}
