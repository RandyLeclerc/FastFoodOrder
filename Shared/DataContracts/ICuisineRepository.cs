using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataContracts
{
    public interface ICuisineRepository : IRepository<CuisineDTO>
    {
        IEnumerable<CuisineDTO> GetAllByRestaurantId(int id);
        bool RestoHasCuisine(int Id, int Resto);
    }
}
