using BLL.Extensions;
using Shared.BTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ShoppingService
{
    public partial class BasketUC
    {
        public ICollection<BasketBTO> GetAllBaskets()
        {
            var baskets = basketRepository.GetAll();
            var result = baskets.Select(x => x.DTOToBasketDomain().BasketDomainToBTO()).ToList();
            return result;
        }
        public BasketBTO GetBasketById(int id)
        {
            var basket = basketRepository.GetById(id);
            return basket.DTOToBasketDomain().BasketDomainToBTO();
        }

        public ICollection<BasketBTO> GetBasketsByUserId(string UserId)
        {
            var baskets = basketRepository.GetBasketsByUserId(UserId);
            var result = baskets.Select(x => x.DTOToBasketDomain().BasketDomainToBTO()).ToList();
            return result;
        }






    }
}
