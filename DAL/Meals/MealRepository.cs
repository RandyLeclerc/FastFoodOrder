using DAL.Data;
using DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.DataContracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Meals
{
    public class MealRepository : IMealRepository
    {
        private ApplicationDbContext contextDB;

        public MealRepository(ApplicationDbContext ContextDB)
        {
            contextDB = ContextDB;
        }
        public MealDTO Create(MealDTO obj)
        {
            var meal = obj.DtoToMeal();
            contextDB.MealTypes.First(x => x.Id == obj.MealType.Id);
            contextDB.Meals.Add(meal);
            contextDB.SaveChanges();
            return meal.MealToDTO();
        }

        public void Delete(int id)
        {
            var meal = contextDB.Meals.FirstOrDefault(x => x.Id == id);
            if (meal == null)
                throw new Exception("There is no Meal in this DB with this Id");
            else
            {
                contextDB.Meals.Remove(meal);
                contextDB.SaveChanges();
            }
        }

        public IEnumerable<MealDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public MealDTO GetById(int id)
        {
            var result = contextDB.Meals
                .Include(x => x.MealType)
                .ThenInclude(y => y.Restaurant)
                .FirstOrDefault(x => x.Id == id);
            return result.MealToDTO();
        }

        public List<MealDTO> GetMealsByMealTypeId(int id)
        {
            return contextDB.Meals
                        .Where(x => x.MealType.Id == id)
                        .Select(x => x.MealToDTO())
                        .ToList();
        }

        public int GetRestoIdByMealId(int MealId)
        {
            var meal = contextDB.Meals
                .Include(x => x.MealType)
                .ThenInclude(y => y.Restaurant)
                .FirstOrDefault(x => x.Id == MealId);
            return meal.MealType.RestaurantId;
        }

        public MealDTO Update(MealDTO obj)
        {
            var meal = contextDB.Meals.FirstOrDefault(x => x.Id == obj.Id);
            if (meal == null)
                return null;
            else
            {
                meal.Name = obj.Name;
                meal.Description = obj.Description;
                meal.Price = obj.Price;
                meal.MealType = obj.MealType.DtoToMealType();
                contextDB.SaveChanges();
                return meal.MealToDTO();
            }
        }
    }
}
