using BLL.Extensions;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class MealUC
    {
        public MealBTO UpdateMeal(MealBTO mealBto)
        {
            MealDTO meal = new MealDTO();
            if (mealBto != null)
            {
                meal = mealRepository.Update(mealBto.BTOToMealDomain().MealDomainToDTO());
                return meal?.DTOToMealDomain().MealDomainToBTO() ?? null;
            }
            return null;
        }
    }
}
