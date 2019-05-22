using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataContracts
{
    public interface IMealTypeRepository : IRepository<MealTypeDTO>
    {
        List<MealTypeDTO> GetMealTypesByRestoId(int id);
    }
}
