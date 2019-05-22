using BLL.UserService.Domain;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Extensions
{
    public static class ApplicationUserExtensions
    {
        public static UserBTO ToBTO(this ApplicationUserDomain Domain)
            => new UserBTO { Id = Domain.Id, FirstName = Domain.FirstName };


        public static UserDTO ToDTO(this ApplicationUserDomain Domain)
            => new UserDTO { Id = Domain.Id, FirstName = Domain.FirstName };
    }
}
