using BLL.Extensions;
using Shared.BTO;
using Shared.DTO;

namespace BLL.ShoppingService
{
    public partial class ShoppingMealUC
    {
        public ShoppingMealBTO AddShoppingMeal(ShoppingMealBTO shoppingMealBto)
        {
            ShoppingMealDTO meal = new ShoppingMealDTO();
            if (shoppingMealBto != null)
            {
                meal = shoppingMealRepository.Create(shoppingMealBto.BTOToShoppingMealDomain().ShoppingMealDomainToDTO());
                return meal.DTOToShoppingMealDomain().ShoppingMealDomainToBTO();
            }
            return null;
        }
    }
}
