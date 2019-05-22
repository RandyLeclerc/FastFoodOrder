using DAL.Cuisines.Entities;
using DAL.MealTypes.Entities;
using DAL.Pictures.Entities;
using DAL.User.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Restaurants.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string UserManagerId { get; set; }
        public ApplicationUser UserManager { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<RestaurantCuisine> RestaurantCuisines { get; set; }
        public /*virtual*/ ICollection<Picture> Pictures { get; set; }
        public /*virtual*/ ICollection<MealType> MealTypes { get; set; }
    }
}
