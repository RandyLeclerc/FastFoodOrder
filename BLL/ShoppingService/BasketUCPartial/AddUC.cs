using BLL.Extensions;
using Shared.BTO;
using Shared.DataContracts;
using Shared.DTO;

namespace BLL.ShoppingService
{
    public partial class BasketUC
    {
        public BasketBTO AddBasket(BasketBTO basketBto)
        {
            BasketDTO meal = new BasketDTO();
            if (basketBto != null)
            {
                var domain = basketBto.BTOToBasketDomain();
                meal = basketRepository.Create(domain.BasketDomainToDTO());
                return meal.DTOToBasketDomain().BasketDomainToBTO();
            }
            return null;
        }
    }
}
