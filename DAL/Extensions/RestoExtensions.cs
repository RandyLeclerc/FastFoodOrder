using DAL.Cuisines.Entities;
using DAL.Restaurants.Entities;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Extensions
{
    public static class RestoExtensions
    {
        public static RestoDTO ToDTO(this Restaurant resto)
        {
            if (resto != null)

                return new RestoDTO
                {
                    Id = resto.Id,
                    Name = resto.Name,
                    UserManager = resto.UserManager.ToDTO(),
                    UserManagerId = resto.UserManagerId,
                    City = resto.City,
                    ShortDescription = resto.ShortDescription,
                    LongDescription = resto.LongDescription,
                    PhoneNumber = resto.PhoneNumber,
                    Pictures = resto.Pictures?.Select(x=>x.PictureToDTO()).ToList() ?? null,
                    Cuisines = resto.RestaurantCuisines?.Select(x => x.Cuisine.ToDTO()).ToList() ?? null,
                    MealTypes = resto.MealTypes?.Select(x=>x.MealTypeToDTO()).ToList() ?? null,
                    Schedules = resto.Schedules?.Select(x=>x.ScheduleToDTO()).ToList() ?? null
                };
            else return null;
        }
        public static Restaurant ToRestaurant(this RestoDTO restoDTO)
            => restoDTO == null ? null : new Restaurant
                {
                    Id = restoDTO.Id,
                    Name = restoDTO.Name,
                    UserManagerId = restoDTO.UserManagerId,
                    City = restoDTO.City,
                    ShortDescription = restoDTO.ShortDescription,
                    LongDescription = restoDTO.LongDescription,
                    PhoneNumber = restoDTO.PhoneNumber,
                    RestaurantCuisines = restoDTO.Cuisines?.Select(x=> x.ToRestaurantCuisines()).ToList() ?? null,
                    Pictures = restoDTO.Pictures?.Select(x=>x.DtoToPicture()).ToList() ?? null,
                    MealTypes = restoDTO.MealTypes?.Select(x => x.DtoToMealType()).ToList() ?? null,
                    Schedules = restoDTO.Schedules?.Select(x => x.DtoToSchedule()).ToList() ?? null
            };

        public static RestaurantCuisine ToRestaurantCuisines(this CuisineDTO cuisineDTO)
            => cuisineDTO==null ? null : new RestaurantCuisine
            {
                Cuisine = new Cuisine { Id = cuisineDTO.Id, Name = cuisineDTO.Name }
            };


    }
}
