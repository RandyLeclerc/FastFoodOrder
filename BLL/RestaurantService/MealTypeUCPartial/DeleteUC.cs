using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class MealTypeUC
    {
        public void DeleteMealType(int id)
        {
            mealTypeRepository.Delete(id);
        }
    }
}
