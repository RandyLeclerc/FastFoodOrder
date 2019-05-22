using Shared.DataContracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class RestaurantUC
    {

        public void DeleteRestaurant(int id)
        {
            restoRepository.Delete(id);
        }
    }
}
