using Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared.DataContracts
{
    public interface IRestoRepository : IRepository<RestoDTO>
    {
        IEnumerable<RestoDTO> FindByCity(string City);
        IEnumerable<RestoDTO> GetRestaurantsByRestaurantManager(string RestaurantManagerId);


        //IEnumerable<RestoDTO> Restos { get; }
    }
}