using DAL.Data;
using DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.DataContracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Cuisines
{
    public class CuisineRepository : ICuisineRepository
    {
        private readonly ApplicationDbContext contextDB;

        public CuisineRepository(ApplicationDbContext ContextDB)
        {
            contextDB = ContextDB;
        }

        public CuisineDTO Create(CuisineDTO obj)
        {
            var cuisine = obj.ToCuisine();
            contextDB.Cuisines.Add(cuisine);
            contextDB.SaveChanges();
            return cuisine.ToDTO();
        }

        public void Delete(int id)
        {
            var cuisine = contextDB.Cuisines.FirstOrDefault(x => x.Id == id);
            if (cuisine == null)
                throw new Exception("There is no Cuisine in this DB with this Id");
            else
            {
                contextDB.Cuisines.Remove(cuisine);
                contextDB.SaveChanges();
            }
        }

        public IEnumerable<CuisineDTO> GetAll()
        {
            return contextDB.Cuisines
                //.Include(x => x.RestaurantCuisines)
                //.ThenInclude(y => y.Cuisine)
                .Select(x => x.ToDTO());
        }
        public IEnumerable<CuisineDTO> GetAllByRestaurantId(int id)
        {
            return contextDB.RestaurantCuisines
                //.Include(x => x.RestaurantCuisines)
                //.ThenInclude(y => y.Cuisine)
                .Where(x=>x.RestaurantId == id)
                .Select(x => x.Cuisine.ToDTO());
        }

        public CuisineDTO GetById(int id)
        {
            return contextDB.Cuisines.FirstOrDefault(x => x.Id == id).ToDTO();
        }

        public bool RestoHasCuisine(int CuisineId, int RestoId)
        {
            return contextDB.RestaurantCuisines.Count(x=> (x.RestaurantId==RestoId) && (x.CuisineId==CuisineId)) > 0;
        }

        public CuisineDTO Update(CuisineDTO obj)
        {
            var cuisine = contextDB.Cuisines.FirstOrDefault(x => x.Id == obj.Id);
            if (cuisine == null)
                return null;
            else
            {
                cuisine.Name = obj.Name;
                contextDB.SaveChanges();
                return cuisine.ToDTO();
            }
        }
    }
}
