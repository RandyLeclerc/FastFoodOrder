using BLL.ShoppingService.Domain;
using Shared.BTO;
using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ShoppingService
{
    public partial class BasketUC
    {
        private readonly IBasketRepository basketRepository;
        public List<ShoppingMealDomain> shoppingMeals;
        public int restoId { get; set; }
        public BasketUC(IBasketRepository BasketRepository)
        {
            //shoppingMeals = BasketBTO.ShoppingMeals;
            basketRepository = BasketRepository;
            shoppingMeals = new List<ShoppingMealDomain>();
        }
    }
}
