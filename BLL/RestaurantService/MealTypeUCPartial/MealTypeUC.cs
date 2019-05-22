using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class MealTypeUC
    {
        private readonly IMealTypeRepository mealTypeRepository;

        public MealTypeUC(IMealTypeRepository MealTypeRepository)
        {
            mealTypeRepository = MealTypeRepository;
        }
    }
}
