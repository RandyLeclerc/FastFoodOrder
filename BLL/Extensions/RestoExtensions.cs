using BLL.RestaurantService.Domain;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Extensions
{
    public static class RestoDomainExtensions
    {
        public static RestoBTO ToBTO(this RestoDomain Domain)
            => Domain == null ? null : new RestoBTO
            {
                Id = Domain.Id,
                Name = Domain.Name,
                City = Domain.City,
                UserManagerId = Domain.UserManagerId,
                UserManager = Domain.UserManager.UserDomainToBTO(),
                ShortDescription = Domain.ShortDescription,
                LongDescription = Domain.LongDescription,
                PhoneNumber = Domain.PhoneNumber,
                Pictures = Domain.Pictures?.Select(x=>x.PictureToBTO()).ToList() ?? null,
                Cuisines = Domain.Cuisines?.Select(x=>x.ToBTO()).ToList() ?? null,
                MealTypes = Domain.MealTypes?.Select(x => x.MealTypeDomainToBTO()).ToList() ?? null
            };

        public static RestoDTO ToDTO(this RestoDomain Domain)
            => Domain == null ? null : new RestoDTO
            {
                Id = Domain.Id,
                Name = Domain.Name,
                City = Domain.City,
                UserManagerId = Domain.UserManagerId,
                UserManager = Domain.UserManager.UserDomainToDTO(),
                ShortDescription = Domain.ShortDescription,
                LongDescription = Domain.LongDescription,
                PhoneNumber = Domain.PhoneNumber,
                Pictures = Domain.Pictures?.Select(x=>x.PictureDomainToDTO()).ToList() ?? null,
                Cuisines = Domain.Cuisines.Select(x=>x.ToDTO()).ToList(),
                MealTypes = Domain.MealTypes?.Select(x => x.MealTypeDomainToDTO()).ToList() ?? null

            };
        public static RestoDomain DTOToDomain(this RestoDTO restoDto)
            => restoDto == null ? null : new RestoDomain
            {
                Id = restoDto.Id,
                Name = restoDto.Name,
                City = restoDto.City,
                UserManagerId = restoDto.UserManagerId,
                UserManager = restoDto.UserManager.UserDTOToUserDomain(),
                ShortDescription = restoDto.ShortDescription,
                LongDescription = restoDto.LongDescription,
                PhoneNumber = restoDto.PhoneNumber,
                Pictures = restoDto.Pictures?.Select(x=>x.DTOToPictureDomain()).ToList() ?? null,
                Cuisines = restoDto.Cuisines?.Select(x=>x.DTOToCuisineDomain()).ToList()??null,
                MealTypes = restoDto.MealTypes?.Select(x => x.DTOToMealTypeDomain()).ToList() ?? null

            };

        public static RestoDomain BTOToDomain(this RestoBTO restoBto)
            => restoBto == null ? null : new RestoDomain
            {
                Id = restoBto.Id,
                Name = restoBto.Name,
                City = restoBto.City,
                UserManagerId = restoBto.UserManagerId,
                UserManager = restoBto.UserManager.UserBTOToUserDomain(),
                ShortDescription = restoBto.ShortDescription,
                LongDescription = restoBto.LongDescription,
                PhoneNumber = restoBto.PhoneNumber,
                Pictures = restoBto.Pictures?.Select(x=>x.BTOToPictureDomain()).ToList() ?? null,
                Cuisines = restoBto.Cuisines?.Select(x=>x.BTOToCuisineDomain()).ToList()??new List<CuisineDomain>(),
                MealTypes = restoBto.MealTypes?.Select(x => x.BTOToMealTypeDomain()).ToList() ?? null

            };

    }
}
