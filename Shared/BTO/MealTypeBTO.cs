using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.BTO
{
    public class MealTypeBTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RestaurantId { get; set; }
        public RestoBTO Restaurant { get; set; }
        public ICollection<MealBTO> Meals { get; set; }

    }
}
