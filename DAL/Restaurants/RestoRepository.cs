﻿using DAL.Cuisines.Entities;
using DAL.Data;
using DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.DataContracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Restaurants
{


    public class RestoRepository : IRestoRepository
    {
        private readonly ApplicationDbContext contextDB;

        public RestoRepository(ApplicationDbContext ContextDB)
        {
            contextDB = ContextDB;
        }

        public RestoDTO Create(RestoDTO obj)
        {
            var resto = obj.ToRestaurant();
            resto.UserManager = contextDB.Users.FirstOrDefault(x => x.Id == resto.UserManagerId);
            resto.RestaurantCuisines.ToList().ForEach(x => contextDB.Attach(x.Cuisine));
            contextDB.Add(resto);
            contextDB.SaveChanges();
            return resto.ToDTO();
        }

        public void Delete(int id)
        {
            var resto = contextDB.Restaurants.Include(x=>x.Pictures).FirstOrDefault(x=>x.Id==id);
            if (resto == null)
                throw new Exception("There is no Restaurant in this DB with this Id");
            else
            {
                contextDB.Restaurants.Remove(resto);
                contextDB.SaveChanges();
            }
        }



        public IEnumerable<RestoDTO> FindByCity(string city)
        {
            return contextDB.Restaurants.Where(x => x.City == city).Select(x=>x.ToDTO());
        }

        public string FindRestoMailByRestoId(int id)
        {
            var resto = contextDB.Restaurants
                .Include(x=>x.UserManager)
                .FirstOrDefault(x => x.Id == id);
            return resto.UserManager.Email;
        }

        public IEnumerable<RestoDTO> GetAll()
        {

            var result = contextDB.Restaurants
                .Include(x => x.UserManager)
                .Include(x=>x.Schedules)
                .Include(x => x.RestaurantCuisines)
                    .ThenInclude(y => y.Cuisine)
                .Select(x => x.ToDTO()).ToList();

            result.ForEach(x => x.Pictures = contextDB.Pictures
            .Where(y => y.Restaurant.Id == x.Id && y.IsProfilePicture)
            .Select(z => z.PictureToDTO())
            .ToList());
            return result;
            
        }

        public IEnumerable<RestoDTO> GetAllByCuisineId(int id)
        {
            var restos = contextDB.Restaurants
                .Include(x => x.UserManager)
                .Include(x => x.Schedules)
                .Include(x => x.RestaurantCuisines)
                    .ThenInclude(y => y.Cuisine)
                .Select(x => x.ToDTO()).ToList();

            restos.ForEach(x => x.Pictures = contextDB.Pictures
            .Where(y => y.Restaurant.Id == x.Id && y.IsProfilePicture)
            .Select(z => z.PictureToDTO())
            .ToList());

            var result = new List<RestoDTO>();
            foreach (var item in restos)
            {
                foreach (var cuisine in item.Cuisines)
                {
                    if (cuisine.Id == id)
                        result.Add(item);
                }
            }
            return result;
        }

        public RestoDTO GetById(int id)
        {
            var result =  contextDB.Restaurants
                .Include(um=>um.UserManager)
                .Include(s=>s.Schedules)
                .Include(mt=>mt.MealTypes)
                    .ThenInclude(y=>y.Meals)
                .Include(rc => rc.RestaurantCuisines)
                    .ThenInclude(c => c.Cuisine)
                .FirstOrDefault(i => i.Id == id).ToDTO();
            result.Pictures = contextDB.Pictures?.Where(x => x.Restaurant.Id == result.Id).Select(x => x.PictureToDTO()).ToList() ?? null;
            return result;
        }

        public IEnumerable<RestoDTO> GetRestaurantsByRestaurantManager(string RestaurantManagerId)
        {
            IEnumerable<RestoDTO> result = contextDB.Restaurants
                .Include(x=>x.UserManager)
                .Include(x=>x.RestaurantCuisines)
                    .ThenInclude(y=>y.Cuisine)
                .Where(x => x.UserManagerId == RestaurantManagerId )
                .Select(x => x.ToDTO());

            return result;
        }

        public bool RestaurantIsOpen(int restoId, DateTime arrivalDate)
        {
            var resto = contextDB.Restaurants
                .Include(x=>x.Schedules)
                .FirstOrDefault(x => x.Id == restoId);

            foreach (var schedule in resto.Schedules)
            {
                if (schedule.DayOfWeek == (int)arrivalDate.DayOfWeek)
                {
                    if (arrivalDate.TimeOfDay >= schedule.TimeOpen.TimeOfDay && arrivalDate.TimeOfDay <= schedule.TimeClosed.TimeOfDay)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public RestoDTO Update(RestoDTO obj)
        {
            var resto = contextDB.Restaurants.FirstOrDefault(x => x.Id == obj.Id);
            if (resto == null)
                return null;
            else
            {
                resto.Name = obj.Name;
                resto.ShortDescription = obj.ShortDescription;
                resto.LongDescription = obj.LongDescription;
                resto.PhoneNumber = obj.PhoneNumber;
                resto.UserManagerId = obj.UserManagerId;
                resto.City = obj.City;
                resto.Pictures = obj.Pictures?.Select(x => x.DtoToPicture()).ToList() ?? null;
                // 1 - Remove In table RestaurantCuisines the rows with this Restaurant
                foreach (var item in contextDB.RestaurantCuisines.Where(x => x.Restaurant == obj.ToRestaurant()))
                {
                    contextDB.RestaurantCuisines.Remove(item);

                }
                // 1b - Remove In table Pictures the rows with this Restaurant
                foreach (var item in contextDB.Pictures.Where(x => x.Restaurant == obj.ToRestaurant()))
                {
                    contextDB.Pictures.Remove(item);

                }
                // 2 - Populate the resto.RestaurantCuisines with the dto object
                resto.RestaurantCuisines = obj.Cuisines.Select(x => x.ToRestaurantCuisines()).ToList();
                resto.Pictures = obj.Pictures.Select(x => x.DtoToPicture()).ToList();

                // 3 - Attach the cuisines to the list of RestaurantCuisines
                resto.RestaurantCuisines.ToList().ForEach(x => contextDB.Attach<Cuisine>(x.Cuisine));
                contextDB.SaveChanges();
                return resto.ToDTO();
            }
        }
    }
}
