using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class CuisineUC
    {
        private ICuisineRepository cuisineRepository;

        public CuisineUC(ICuisineRepository CuisineRepository)
        {
            cuisineRepository = CuisineRepository;
        }
    }
}
