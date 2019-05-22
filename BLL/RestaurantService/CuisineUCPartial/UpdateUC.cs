using BLL.Extensions;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class CuisineUC
    {
        public CuisineBTO UpdateCuisine(CuisineBTO cuisineBto)
        {
            CuisineDTO cuisine = new CuisineDTO();
            if (cuisineBto != null)
            {
                cuisine = cuisineRepository.Update(cuisineBto.BTOToCuisineDomain().ToDTO());
                return cuisine?.DTOToCuisineDomain().ToBTO() ?? null;
            }
            return null;
        }
    }
}
