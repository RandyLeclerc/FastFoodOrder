using BLL.Extensions;
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
        public void AddMealToBasket(MealBTO mealBTO, int quantity)
        {
            ShoppingMealDomain shoppingMeal = shoppingMeals
                .Where(x => x.Meal.Id == mealBTO.Id)
                .FirstOrDefault();

            if (shoppingMeal == null)
            {
                shoppingMeals.Add(new ShoppingMealDomain
                {
                    Meal = mealBTO.BTOToMealDomain(),
                    MealId = mealBTO.Id,
                    Quantity = quantity
                });
            }
            else shoppingMeal.Quantity += quantity;
        }
    }
}
