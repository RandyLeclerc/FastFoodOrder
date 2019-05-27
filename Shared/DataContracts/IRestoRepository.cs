using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared.DataContracts
{
    public interface IRestoRepository : IRepository<RestoDTO>
    {
        IEnumerable<RestoDTO> FindByCity(string City);
        IEnumerable<RestoDTO> GetRestaurantsByRestaurantManager(string RestaurantManagerId);
        bool RestaurantIsOpen(int restoId, DateTime arrivalDate);
        IEnumerable<RestoDTO> GetAllByCuisineId(int id);
        string FindRestoMailByRestoId(int id);
    }
}