using BLL.Extensions;
using Shared.BTO;
using Shared.DTO;

namespace BLL.RestaurantService
{
    public partial class MealUC
    {
        public MealBTO AddMeal(MealBTO mealBto)
        {
            MealDTO meal = new MealDTO();
            if (mealBto != null)
            {
                meal = mealRepository.Create(mealBto.BTOToMealDomain().MealDomainToDTO());
                return meal.DTOToMealDomain().MealDomainToBTO();
            }
            return null;
        }
    }
}
