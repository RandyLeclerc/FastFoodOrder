using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class CuisineUC
    {
        public void DeleteCuisine(int id)
        {
            cuisineRepository.Delete(id);
        }
    }
}
