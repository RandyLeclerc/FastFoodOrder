using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService.Domain
{
    public class MealTypeDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RestaurantId { get; set; }
        public RestoDomain Restaurant { get; set; }
        public ICollection<MealDomain> Meals { get; set; }

    }
}
