using BLL.RestaurantService.Domain;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Extensions
{
    public static class MealTypeDomainExtensions
    {
        public static MealTypeDTO MealTypeDomainToDTO(this MealTypeDomain Domain)
        {
            if (Domain != null)
                return new MealTypeDTO
                {
                    Id = Domain.Id,
                    Name = Domain.Name,
                    RestaurantId = Domain.RestaurantId,
                    Restaurant = Domain.Restaurant.ToDTO(),
                    Meals = Domain.Meals?.Select(x=>x.MealDomainToDTO()).ToList() ?? null
                };
            else return null;
        }
        public static MealTypeDomain DTOToMealTypeDomain(this MealTypeDTO mealTypeDto)
        {
            if (mealTypeDto != null)
                return new MealTypeDomain
                {
                    Id = mealTypeDto.Id,
                    Name = mealTypeDto.Name,
                    RestaurantId = mealTypeDto.RestaurantId,
                    Restaurant = mealTypeDto.Restaurant.DTOToDomain(),
                    Meals = mealTypeDto.Meals?.Select(x=>x.DTOToMealDomain()).ToList() ?? null
                };
            else return null;
        }
        public static MealTypeBTO MealTypeDomainToBTO(this MealTypeDomain Domain)
        {
            if (Domain != null)
                return new MealTypeBTO
                {
                    Id = Domain.Id,
                    Name = Domain.Name,
                    RestaurantId = Domain.RestaurantId,
                    Restaurant = Domain.Restaurant.ToBTO(),
                    Meals = Domain.Meals?.Select(x => x.MealDomainToBTO()).ToList() ?? null
                };
            else return null;
        }
        public static MealTypeDomain BTOToMealTypeDomain(this MealTypeBTO mealTypeBto)
        {
            if (mealTypeBto != null)
                return new MealTypeDomain
                {
                    Id = mealTypeBto.Id,
                    Name = mealTypeBto.Name,
                    RestaurantId = mealTypeBto.RestaurantId,
                    Restaurant = mealTypeBto.Restaurant.BTOToDomain(),
                    Meals = mealTypeBto.Meals?.Select(x => x.BTOToMealDomain()).ToList() ?? null
                };
            else return null;
        }
    }
}
