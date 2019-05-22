using DAL.Restaurants.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Cuisines.Entities
{
    public class Cuisine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RestaurantCuisine> RestaurantCuisines { get; set; }
    }
}
