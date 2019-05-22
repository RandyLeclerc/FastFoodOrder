using DAL.Restaurants.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Cuisines.Entities
{
    public class RestaurantCuisine
    {
        public int CuisineId { get; set; }
        public Cuisine Cuisine { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}
