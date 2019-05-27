using BLL.ShoppingService.Domain;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Extensions
{
    public static class BasketDomainExtensions
    {
        public static BasketDTO BasketDomainToDTO(this BasketDomain Domain)
        {
            if (Domain != null)
                return new BasketDTO
                {
                    Id = Domain.Id,
                    UserId = Domain.UserId,
                    User = Domain.User.UserDomainToDTO(),
                    ShoppingMeals = Domain.ShoppingMeals?
                    .Select(x=>x.ShoppingMealDomainToDTO())
                    .ToList() ?? null,
                    ArrivalDate = Domain.ArrivalDate
                };
            else return null;
        }
        public static BasketDomain DTOToBasketDomain(this BasketDTO basketDto)
        {
            if (basketDto != null)
                return new BasketDomain
                {
                    Id = basketDto.Id,
                    UserId = basketDto.UserId,
                    User = basketDto.User.UserDTOToUserDomain(),
                    ShoppingMeals = basketDto.ShoppingMeals?
                    .Select(x=>x.DTOToShoppingMealDomain())
                    .ToList() ?? null,
                    ArrivalDate = basketDto.ArrivalDate

                };
            else return null;
        }
        public static BasketBTO BasketDomainToBTO(this BasketDomain Domain)
        {
            if (Domain != null)
                return new BasketBTO
                {
                    Id = Domain.Id,
                    UserId = Domain.UserId,
                    User = Domain.User.UserDomainToBTO(),
                    ShoppingMeals = Domain.ShoppingMeals?
                    .Select(x => x.ShoppingMealDomainToBTO())
                    .ToList() ?? null,
                    ArrivalDate = Domain.ArrivalDate

                };
            else return null;
        }
        public static BasketDomain BTOToBasketDomain(this BasketBTO basketBto)
        {
            if (basketBto != null)
                return new BasketDomain
                {
                    Id = basketBto.Id,
                    UserId = basketBto.UserId,
                    User = basketBto.User.UserBTOToUserDomain(),
                    ShoppingMeals = basketBto.ShoppingMeals?
                    .Select(x => x.BTOToShoppingMealDomain())
                    .ToList() ?? null,
                    ArrivalDate = basketBto.ArrivalDate
                };
            else return null;
        }
    }
}
