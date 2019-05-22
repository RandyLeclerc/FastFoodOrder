using BLL.UserService.Domain;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Extensions
{
    public static class UserDomainExtensions
    {
        public static UserDTO UserDomainToDTO(this ApplicationUserDomain Domain)
        {
            if (Domain != null)
                return new UserDTO
                {
                    Id = Domain.Id,
                    FirstName = Domain.FirstName
                };
            else return null;
        }

        public static ApplicationUserDomain UserDTOToUserDomain(this UserDTO userDto)
        {
            if (userDto != null)
                return new ApplicationUserDomain
                {
                    Id = userDto.Id,
                    FirstName = userDto.FirstName
                };
            else return null;
        }
        public static UserBTO UserDomainToBTO(this ApplicationUserDomain Domain)
        {
            if (Domain != null)
                return new UserBTO
                {
                    Id = Domain.Id,
                    FirstName = Domain.FirstName
                };
            else return null;
        }
        public static ApplicationUserDomain UserBTOToUserDomain(this UserBTO userBto)
        {
            if (userBto != null)
                return new ApplicationUserDomain
                {
                    Id = userBto.Id,
                    FirstName = userBto.FirstName
                };
            else return null;
        }
    }
}
