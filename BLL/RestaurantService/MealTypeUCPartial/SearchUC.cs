using BLL.Extensions;
using Shared.BTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class MealTypeUC
    {
        public ICollection<MealTypeBTO> GetAllMealTypes()
        {
            var mealTypes = mealTypeRepository.GetAll();
            var result = mealTypes.Select(x => x.DTOToMealTypeDomain().MealTypeDomainToBTO()).ToList();
            return result;
        }
        public MealTypeBTO GetMealTypeById(int id)
        {
            var mealType = mealTypeRepository.GetById(id);
            return mealType.DTOToMealTypeDomain().MealTypeDomainToBTO();
        }

        public ICollection<MealTypeBTO> GetAllMealTypesByRestaurantId(int id)
        {
            var mealTypes = mealTypeRepository.GetMealTypesByRestoId(id);

            return mealTypes.Select(x=>x.DTOToMealTypeDomain().MealTypeDomainToBTO()).ToList();
        }




    }
}
