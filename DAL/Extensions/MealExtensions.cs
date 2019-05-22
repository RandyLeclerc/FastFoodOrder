using DAL.Meals.Entities;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Extensions
{
    public static class MealExtensions
    {
        public static MealDTO MealToDTO(this Meal meal)
        {
            if (meal != null)
                return new MealDTO
                {
                    Id = meal.Id,
                    Name = meal.Name,
                    Description = meal.Description,
                    Price = meal.Price,
                    MealTypeID = meal.MealTypeID
                   // MealType = meal.MealType.MealTypeToDTO()
                };
            else return null;
        }
        public static Meal DtoToMeal(this MealDTO dto)
        {
            if (dto != null)
                return new Meal
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Description = dto.Description,
                    Price = dto.Price,
                    MealTypeID = dto.MealTypeID,
                    MealType = dto.MealType.DtoToMealType()
                };
            else return null;
        }
    }
}
