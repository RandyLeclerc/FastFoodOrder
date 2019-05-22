using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ShoppingService
{
    public partial class BasketUC
    {
        public void DeleteBasket(int id)
        {
            basketRepository.Delete(id);
        }
    }
}
