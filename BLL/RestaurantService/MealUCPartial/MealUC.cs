using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class MealUC
    {
        private readonly IMealRepository mealRepository;

        public MealUC(IMealRepository MealRepository)
        {
            mealRepository = MealRepository;
        }
    }
}
