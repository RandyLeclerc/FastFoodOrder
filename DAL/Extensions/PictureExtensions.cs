using DAL.Pictures.Entities;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Extensions
{
    public static class PictureExtensions
    {
        public static PictureDTO PictureToDTO(this Picture picture)
        {
            if (picture != null)
                return new PictureDTO
                {
                    Id = picture.Id,
                    Url = picture.Url,
                    IsProfilePicture = picture.IsProfilePicture,
                    RestaurantId = picture.RestaurantId
                    //Resto = picture.Restaurant.ToDTO()
                };
            else return null;
        }

        public static Picture DtoToPicture(this PictureDTO dto)
        {
            if (dto != null)
                return new Picture
                {
                    Id = dto.Id,
                    Url = dto.Url,
                    IsProfilePicture = dto.IsProfilePicture,
                    RestaurantId = dto.RestaurantId,
                    Restaurant = dto.Resto.ToRestaurant()
                };
            else return null;
        }
    }
}
