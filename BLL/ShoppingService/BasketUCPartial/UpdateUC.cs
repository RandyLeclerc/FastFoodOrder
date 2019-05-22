using BLL.Extensions;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ShoppingService
{
    public partial class BasketUC
    {
        public BasketBTO UpdateBasket(BasketBTO basketBto)
        {
            BasketDTO basket;
            if (basketBto != null)
            {
                basket = basketRepository.Update(basketBto.BTOToBasketDomain().BasketDomainToDTO());
                return basket?.DTOToBasketDomain().BasketDomainToBTO() ?? null;
            }
            return null;
        }
    }
}
