using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using BLL.Extensions;

namespace BLL.RestaurantService
{
    public partial class CuisineUC
    {
        public CuisineBTO AddCuisine(CuisineBTO cuisineBto)
        {
            CuisineDTO cuisine = new CuisineDTO();
            if (cuisineBto != null)
            {
                cuisine = cuisineRepository.Create(cuisineBto.BTOToCuisineDomain().ToDTO());
                return cuisine.DTOToCuisineDomain().ToBTO();
            }
            return null;
        }
    }
}
