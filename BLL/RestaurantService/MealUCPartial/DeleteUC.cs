using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class MealUC
    {
        public void DeleteMeal(int id)
        {
            mealRepository.Delete(id);
        }
    }
}
