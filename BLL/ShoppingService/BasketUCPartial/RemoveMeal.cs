using BLL.ShoppingService.Domain;
using Shared.BTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ShoppingService
{
    public partial class BasketUC
    {
        public void RemoveMeal(MealBTO mealBTO)
        {
            shoppingMeals.RemoveAll(x => x.Meal.Id == mealBTO.Id);
        }
    }
}
