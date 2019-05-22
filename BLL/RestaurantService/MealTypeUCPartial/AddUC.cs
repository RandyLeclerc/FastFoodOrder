using BLL.Extensions;
using Shared.BTO;
using Shared.DTO;

namespace BLL.RestaurantService
{
    public partial class MealTypeUC
    {
        public MealTypeBTO AddMealType(MealTypeBTO mealTypeBto)
        {
            MealTypeDTO mealType = new MealTypeDTO();
            if (mealTypeBto != null)
            {
                mealType = mealTypeRepository.Create(mealTypeBto.BTOToMealTypeDomain().MealTypeDomainToDTO());
                return mealType.DTOToMealTypeDomain().MealTypeDomainToBTO();
            }
            return null;
        }
    }
}
