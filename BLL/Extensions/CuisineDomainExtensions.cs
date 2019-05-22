using BLL.RestaurantService.Domain;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Extensions
{
    public static class CuisineDomainExtensions
    {
        public static CuisineDTO ToDTO(this CuisineDomain Domain)
        {
            if (Domain != null)
                return new CuisineDTO
                {
                    Id = Domain.Id,
                    Name = Domain.Name
                };
            else return null;
        }
        public static CuisineDomain DTOToCuisineDomain(this CuisineDTO cuisineDto)
        {
            if (cuisineDto != null)
                return new CuisineDomain
                {
                    Id = cuisineDto.Id,
                    Name = cuisineDto.Name
                };
            else return null;
        }

        public static CuisineBTO ToBTO(this CuisineDomain Domain)
        {
            if (Domain != null)
                return new CuisineBTO
                {
                    Id = Domain.Id,
                    Name = Domain.Name
                };
            else return null;
        }
        public static CuisineDomain BTOToCuisineDomain(this CuisineBTO cuisineBto)
        {
            if (cuisineBto != null)
                return new CuisineDomain
                {
                    Id = cuisineBto.Id,
                    Name = cuisineBto.Name
                };
            else return null;
        }
    }
}
