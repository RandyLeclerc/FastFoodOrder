using DAL.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using WebApplication1.Data;

namespace WebApplication1.ViewModel
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel()
        {
            Users = new List<ApplicationUser>();
        }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public List<ApplicationUser> Users { get; set; }

    }
}
