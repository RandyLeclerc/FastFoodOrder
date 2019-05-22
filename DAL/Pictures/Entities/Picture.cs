using DAL.Restaurants.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Pictures.Entities
{
    public class Picture
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsProfilePicture { get; set; }
        [Required]

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
