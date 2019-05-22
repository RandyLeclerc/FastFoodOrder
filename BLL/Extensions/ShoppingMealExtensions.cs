using BLL.ShoppingService.Domain;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Extensions
{
    public static class ShoppingMealExtensions
    {
        public static ShoppingMealDTO ShoppingMealDomainToDTO(this ShoppingMealDomain Domain)
        {
            if (Domain != null)
                return new ShoppingMealDTO
                {
                    Id = Domain.Id,
                    Quantity = Domain.Quantity,
                    BasketId = Domain.BasketId,
                    Basket = Domain.Basket.BasketDomainToDTO(),
                    MealId = Domain.MealId,
                    Meal = Domain.Meal.MealDomainToDTO()
                };
            else return null;
        }
        public static ShoppingMealDomain DTOToShoppingMealDomain(this ShoppingMealDTO shoppingMealDto)
        {
            if (shoppingMealDto != null)
                return new ShoppingMealDomain
                {
                    Id = shoppingMealDto.Id,
                    Quantity = shoppingMealDto.Quantity,
                    MealId = shoppingMealDto.MealId,
                    Meal = shoppingMealDto.Meal.DTOToMealDomain(),
                    BasketId = shoppingMealDto.BasketId,
                    Basket = shoppingMealDto.Basket.DTOToBasketDomain()
                };
            else return null;
        }
        public static ShoppingMealBTO ShoppingMealDomainToBTO(this ShoppingMealDomain Domain)
        {
            if (Domain != null)
                return new ShoppingMealBTO
                {
                    Id = Domain.Id,
                    Quantity = Domain.Quantity,
                    BasketId = Domain.BasketId,
                    Basket = Domain.Basket.BasketDomainToBTO(),
                    MealId = Domain.MealId,
                    Meal = Domain.Meal.MealDomainToBTO()
                };
            else return null;
        }
        public static ShoppingMealDomain BTOToShoppingMealDomain(this ShoppingMealBTO shoppingMealBto)
        {
            if (shoppingMealBto != null)
                return new ShoppingMealDomain
                {
                    Id = shoppingMealBto.Id,
                    Quantity = shoppingMealBto.Quantity,
                    MealId = shoppingMealBto.MealId,
                    Meal = shoppingMealBto.Meal.BTOToMealDomain(),
                    BasketId = shoppingMealBto.BasketId,
                    Basket = shoppingMealBto.Basket.BTOToBasketDomain()
                };
            else return null;
        }
    }
}
