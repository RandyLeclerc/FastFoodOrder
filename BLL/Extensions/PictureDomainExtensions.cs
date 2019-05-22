using BLL.RestaurantService.Domain;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Extensions
{
    public static class PictureDomainExtensions
    {
        public static PictureDTO PictureDomainToDTO(this PictureDomain Domain)
        {
            if (Domain != null)
                return new PictureDTO
                {
                    Id = Domain.Id,
                    Url = Domain.Url,
                    IsProfilePicture = Domain.IsProfilePicture,
                    RestaurantId = Domain.RestaurantId,
                    Resto = Domain.Resto.ToDTO()
                };
            else return null;
        }

        public static PictureDomain DTOToPictureDomain(this PictureDTO pictureDto)
        {
            if (pictureDto != null)
                return new PictureDomain
                {
                    Id = pictureDto.Id,
                    Url = pictureDto.Url,
                    IsProfilePicture = pictureDto.IsProfilePicture,
                    RestaurantId = pictureDto.RestaurantId,
                    Resto = pictureDto.Resto.DTOToDomain()
                };
            else return null;
        }
        public static PictureBTO PictureToBTO(this PictureDomain Domain)
        {
            if (Domain != null)
                return new PictureBTO
                {
                    Id = Domain.Id,
                    Url = Domain.Url,
                    IsProfilePicture = Domain.IsProfilePicture,
                    RestaurantId = Domain.RestaurantId,
                    Resto = Domain.Resto.ToBTO()
                };
            else return null;
        }
        public static PictureDomain BTOToPictureDomain(this PictureBTO pictureBto)
        {
            if (pictureBto != null)
                return new PictureDomain
                {
                    Id = pictureBto.Id,
                    Url = pictureBto.Url,
                    IsProfilePicture = pictureBto.IsProfilePicture,
                    RestaurantId = pictureBto.RestaurantId,
                    Resto = pictureBto.Resto.BTOToDomain()
                };
            else return null;
        }
    }
}
