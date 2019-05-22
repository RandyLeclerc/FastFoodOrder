using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.User.Entities;
using System.Text;
using DAL.Restaurants.Entities;

namespace DAL.User.Entities
{
    //[Table("AspNetUsers")]
    public class ApplicationUser : IdentityUser
    {
        //public string Id { get; set; }
        public string FirstName { get; set; }
        public List<Restaurant> Restaurants { get; set; }

    }
}
