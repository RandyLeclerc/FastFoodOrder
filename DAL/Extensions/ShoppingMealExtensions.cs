using DAL.ShoppingMeals.Entities;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Extensions
{
    public static class ShoppingMealExtensions
    {
        public static ShoppingMealDTO ShoppingMealToDTO(this ShoppingMeal shoppingMeal)
        {
            if (shoppingMeal != null)
                return new ShoppingMealDTO
                {
                    Id = shoppingMeal.Id,
                    BasketId = shoppingMeal.BasketId,
                    //Basket = shoppingMeal.Basket.BasketToDTO(),
                    MealId = shoppingMeal.MealId,
                    Meal = shoppingMeal.Meal.MealToDTO(),
                    Quantity = shoppingMeal.Quantity
                };
            else return null;
        }
        public static ShoppingMeal DtoToShoppingMeal(this ShoppingMealDTO dto)
        {
            if (dto != null)
                return new ShoppingMeal
                {
                    Id = dto.Id,
                    BasketId = dto.BasketId,
                    Basket = dto.Basket.DtoToBasket(),
                    MealId = dto.MealId,
                    Meal = dto.Meal.DtoToMeal(),
                    Quantity = dto.Quantity
                };
            else return null;
        }
    }
}
