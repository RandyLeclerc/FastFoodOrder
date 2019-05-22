using DAL.Data;
using DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.DataContracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.MealTypes
{
    public class MealTypeRepository : IMealTypeRepository
    {
        private readonly ApplicationDbContext contextDB;

        public MealTypeRepository(ApplicationDbContext ContextDB)
        {
            contextDB = ContextDB;
        }

        public MealTypeDTO Create(MealTypeDTO obj)
        {
            var mealType = obj.DtoToMealType();
            contextDB.Restaurants.First(x => x.Id == obj.Restaurant.Id);
            contextDB.MealTypes.Add(mealType);
            contextDB.SaveChanges();
            return mealType.MealTypeToDTO();
        }

        public void Delete(int id)
        {
            var mealType = contextDB.MealTypes.FirstOrDefault(x => x.Id == id);
            if (mealType == null)
                throw new Exception("There is no MealType in this DB with this Id");
            else
            {
                contextDB.MealTypes.Remove(mealType);
                contextDB.SaveChanges();
            }
        }

        public IEnumerable<MealTypeDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public MealTypeDTO GetById(int id)
        {
            return contextDB.MealTypes
                .Include(x=>x.Restaurant)
                .FirstOrDefault(x => x.Id == id)
                .MealTypeToDTO();
        }

        public List<MealTypeDTO> GetMealTypesByRestoId(int id)
        {
            return contextDB.MealTypes
                        .Where(x => x.Restaurant.Id == id)
                        .Select(x => x.MealTypeToDTO())
                        .ToList();
        }

        public MealTypeDTO Update(MealTypeDTO obj)
        {
            var mealType = contextDB.MealTypes.FirstOrDefault(x => x.Id == obj.Id);
            if (mealType == null)
                return null;
            else
            {
                mealType.Name = obj.Name;
                mealType.Restaurant = obj.Restaurant.ToRestaurant();
                contextDB.SaveChanges();
                return mealType.MealTypeToDTO();
            }
        }
    }
}
