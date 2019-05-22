using DAL.Cuisines.Entities;
using DAL.Restaurants.Entities;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Extensions
{
    public static class CuisineExtensions
    {
        public static CuisineDTO ToDTO(this Cuisine cuisine)
        {
            if (cuisine != null)
                return new CuisineDTO
                {
                    Id = cuisine.Id,
                    Name = cuisine.Name,
                    //Restaurants = cuisine.RestaurantCuisines?.Select(x => x.Restaurant.ToDTO()).ToList() ?? null
                };
            else return null;
        }
        public static Cuisine ToCuisine(this CuisineDTO dto)
        {
            if (dto != null)
                return new Cuisine
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    RestaurantCuisines = dto.Restaurants?.Select(x => x.ToCuisineRestaurant()).ToList() ?? null
                };
            else return null;
        }

        public static RestaurantCuisine ToCuisineRestaurant(this RestoDTO restoDTO)
            => restoDTO == null ? null : new RestaurantCuisine
                {
                     Restaurant = new Restaurant
                     {
                         Id = restoDTO.Id,
                         Name = restoDTO.Name,
                         City = restoDTO.City,
                         PhoneNumber = restoDTO.PhoneNumber,
                         ShortDescription = restoDTO.ShortDescription,
                         LongDescription = restoDTO.LongDescription,
                         Pictures = restoDTO.Pictures.Select(x=>x.DtoToPicture()).ToList()
                     }
                };
    }
}
