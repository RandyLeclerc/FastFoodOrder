using BLL.Extensions;
using Shared.BTO;
using Shared.DataContracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.RestaurantService
{
    public partial class RestaurantUC
    {
        public RestoBTO AddRestaurant(RestoBTO restoBTO)
        {
            RestoDTO resto = new RestoDTO();
            if (restoBTO != null)
            {
                resto = restoRepository.Create(restoBTO.BTOToDomain().ToDTO());
                return resto.DTOToDomain().ToBTO();
            }
            return  null;
        }
    }
}
