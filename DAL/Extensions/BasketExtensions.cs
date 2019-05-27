using DAL.Baskets.Entities;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Extensions
{
    public static class BasketExtensions
    {
        public static BasketDTO BasketToDTO(this Basket basket)
        {
            if (basket != null)
                return new BasketDTO
                {
                    Id = basket.Id,
                    User = basket.User.ToDTO(),
                    UserId = basket.UserId,
                    ShoppingMeals = basket.ShoppingMeals?.Select(x=>x.ShoppingMealToDTO()).ToList() ?? null,
                    ArrivalDate = basket.ArrivalDate
                };
            else return null;
        }
        public static Basket DtoToBasket(this BasketDTO dto)
        {
            if (dto != null)
                return new Basket
                {
                    Id = dto.Id,
                    User = dto.User.DTOToUser(),
                    UserId = dto.UserId,
                    ShoppingMeals = dto.ShoppingMeals?.Select(x=>x.DtoToShoppingMeal()).ToList()??null,
                    ArrivalDate = dto.ArrivalDate

                };
            else return null;
        }
    }
}
