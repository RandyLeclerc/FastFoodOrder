using BLL.Extensions;
using Shared.BTO;
using Shared.DataContracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class RestaurantUC
    {

        public RestoBTO UpdateRestaurant(RestoBTO restoBTO)
        {
            RestoDTO resto = new RestoDTO();
            if (restoBTO != null)
            {
                resto = restoRepository.Update(restoBTO.BTOToDomain().ToDTO());
                return resto?.DTOToDomain().ToBTO() ?? null;
            }
            return null;
        }

    }
}
