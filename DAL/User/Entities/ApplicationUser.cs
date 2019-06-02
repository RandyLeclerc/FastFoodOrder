using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.User.Entities;
using System.Text;
using DAL.Restaurants.Entities;

namespace DAL.User.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public List<Restaurant> Restaurants { get; set; }

    }
}
