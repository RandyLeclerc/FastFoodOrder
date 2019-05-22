using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
    public class MealDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int MealTypeID { get; set; }

        public MealTypeDTO MealType { get; set; }
    }
}
