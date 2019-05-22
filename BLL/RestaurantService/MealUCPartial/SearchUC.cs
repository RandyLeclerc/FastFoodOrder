using BLL.Extensions;
using Shared.BTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class MealUC
    {
        public ICollection<MealBTO> GetAllMeals()
        {
            var meals = mealRepository.GetAll();
            var result = meals.Select(x => x.DTOToMealDomain().MealDomainToBTO()).ToList();
            return result;
        }
        public MealBTO GetMealById(int id)
        {
            var meal = mealRepository.GetById(id);

            var result = meal.DTOToMealDomain().MealDomainToBTO();
            return result;
        }

        public ICollection<MealBTO> GetAllMealsByMealTypeId(int id)
        {
            var meals = mealRepository.GetMealsByMealTypeId(id);

            return meals.Select(x => x.DTOToMealDomain().MealDomainToBTO()).ToList();
        }

        public int GetRestoIdByMealId(int id)
        {
            var result = mealRepository.GetRestoIdByMealId(id);
            return result;
        }




    }
}
