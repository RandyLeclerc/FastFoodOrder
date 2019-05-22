using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
    public class MealTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RestaurantId { get; set; }
        public RestoDTO Restaurant { get; set; }
        public ICollection<MealDTO> Meals { get; set; }

    }
}
