using BLL.Extensions;
using BLL.RestaurantService.Domain;
using Shared.BTO;
using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class RestaurantUC
    {
        public IEnumerable<RestoBTO> FindRestaurantByCity(string city)
        {

            var restos = restoRepository.FindByCity(city); 

            return restos?.Select(x => x.DTOToDomain().ToBTO()) ?? new List<RestoBTO>();
        }

        public IEnumerable<RestoBTO> GetAllRestaurants()
        {
            var restos = restoRepository.GetAll();

            return restos.Select(x => x.DTOToDomain().ToBTO());
        }

        public RestoBTO GetRestaurantById(int id)
        {
            var resto = restoRepository.GetById(id);
            return resto.DTOToDomain().ToBTO();
        }

        public IEnumerable<RestoBTO> GetRestaurantsByRestaurantManager(string RestaurantManagerId)
        {
            if (string.IsNullOrEmpty(RestaurantManagerId))
                return new List<RestoBTO>();
            else
            {
                var restos = restoRepository.GetRestaurantsByRestaurantManager(RestaurantManagerId);
                //restos.Select(x=>x.Cuisines == repo)

                return restos?.Select(x => x.DTOToDomain().ToBTO()) ?? new List<RestoBTO>();
            }

        }
    }
}
