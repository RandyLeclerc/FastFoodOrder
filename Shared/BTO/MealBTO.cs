﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.BTO
{
    public class MealBTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int MealTypeID { get; set; }
        [Display(Name = "Meal type")]
        public MealTypeBTO MealType { get; set; }
    }
}
