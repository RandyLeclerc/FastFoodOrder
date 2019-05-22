using BLL.RestaurantService.Domain;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Extensions
{
    public static class MealDomainExtensions
    {
        public static MealDTO MealDomainToDTO(this MealDomain Domain)
        {
            if (Domain != null)
                return new MealDTO
                {
                    Id = Domain.Id,
                    Name = Domain.Name,
                    Description = Domain.Description,
                    Price = Domain.Price,
                    MealTypeID = Domain.MealTypeID,
                    MealType = Domain.MealType.MealTypeDomainToDTO()
                };
            else return null;
        }
        public static MealDomain DTOToMealDomain(this MealDTO mealDto)
        {
            if (mealDto != null)
                return new MealDomain
                {
                    Id = mealDto.Id,
                    Name = mealDto.Name,
                    Description = mealDto.Description,
                    Price = mealDto.Price,
                    MealTypeID = mealDto.MealTypeID,
                    MealType = mealDto.MealType.DTOToMealTypeDomain()
                };
            else return null;
        }
        public static MealBTO MealDomainToBTO(this MealDomain Domain)
        {
            if (Domain != null)
                return new MealBTO
                {
                    Id = Domain.Id,
                    Name = Domain.Name,
                    Description = Domain.Description,
                    Price = Domain.Price,
                    MealTypeID = Domain.MealTypeID,
                    MealType = Domain.MealType.MealTypeDomainToBTO()
                };
            else return null;
        }
        public static MealDomain BTOToMealDomain(this MealBTO mealBto)
        {
            if (mealBto != null)
                return new MealDomain
                {
                    Id = mealBto.Id,
                    Name = mealBto.Name,
                    Description = mealBto.Description,
                    Price = mealBto.Price,
                    MealTypeID = mealBto.MealTypeID,
                    MealType = mealBto.MealType.BTOToMealTypeDomain()
                };
            else return null;
        }
    }
}
