using DAL.MealTypes.Entities;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Extensions
{
    public static class MealTypeExtensions
    {
        public static MealTypeDTO MealTypeToDTO(this MealType mealType)
        {
            if (mealType != null)
                return new MealTypeDTO
                {
                    Id = mealType.Id,
                    Name = mealType.Name,
                    RestaurantId = mealType.RestaurantId,
                    Meals = mealType.Meals?.Select(x => x.MealToDTO()).ToList() ?? null
                    //Restaurant = mealType.Restaurant.ToDTO()
                    //Resto = picture.Restaurant.ToDTO()
                };
            else return null;
        }
        public static MealType DtoToMealType(this MealTypeDTO dto)
        {
            if (dto != null)
                return new MealType
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    RestaurantId = dto.RestaurantId,
                    Restaurant = dto.Restaurant.ToRestaurant(),
                    Meals = dto.Meals?.Select(x=>x.DtoToMeal()).ToList() ?? null
                };
            else return null;
        }
    }
}
