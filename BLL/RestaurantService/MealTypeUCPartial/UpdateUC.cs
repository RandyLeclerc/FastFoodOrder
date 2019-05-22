using BLL.Extensions;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class MealTypeUC
    {
        public MealTypeBTO UpdateMealType(MealTypeBTO mealTypeBto)
        {
            MealTypeDTO mealType = new MealTypeDTO();
            if (mealTypeBto != null)
            {
                mealType = mealTypeRepository.Update(mealTypeBto.BTOToMealTypeDomain().MealTypeDomainToDTO());
                return mealType?.DTOToMealTypeDomain().MealTypeDomainToBTO() ?? null;
            }
            return null;
        }
    }
}
