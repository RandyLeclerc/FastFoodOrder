using DAL.Restaurants.Entities;
using DAL.User.Entities;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Extensions
{
    public static class UserExtentions
    {
        public static UserDTO ToDTO(this ApplicationUser user)
            => user == null ? null : new UserDTO { Id = user.Id, FirstName = user.FirstName};

        public static ApplicationUser DTOToUser(this UserDTO dto)
            => dto == null ? null : new ApplicationUser { Id = dto.Id, FirstName = dto.FirstName };
    }
}
