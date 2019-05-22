using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataContracts
{
    public interface IMealRepository : IRepository<MealDTO>
    {
        List<MealDTO> GetMealsByMealTypeId(int id);
        int GetRestoIdByMealId(int MealId);

    }
}
