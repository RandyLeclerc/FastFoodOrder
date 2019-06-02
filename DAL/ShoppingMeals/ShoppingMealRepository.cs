using DAL.Data;
using DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.DataContracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.ShoppingMeals
{
    public class ShoppingMealRepository : IShoppingMealRepository
    {

        private readonly ApplicationDbContext contextDB;
        public ShoppingMealRepository(ApplicationDbContext ContextDB)
        {
            contextDB = ContextDB;
        }
        public ShoppingMealDTO Create(ShoppingMealDTO obj)
        {
            var shoppingMeal = obj.DtoToShoppingMeal();
            contextDB.ShoppingMeals.Add(shoppingMeal);
            contextDB.SaveChanges();
            return shoppingMeal.ShoppingMealToDTO();
        }

        public void Delete(int id)
        {
            var shoppingMeal = contextDB.ShoppingMeals.FirstOrDefault(x => x.Id == id);
            if (shoppingMeal == null)
                throw new Exception("There is no ShoppingMeal in this DB with this Id");
            else
            {
                contextDB.ShoppingMeals.Remove(shoppingMeal);
                contextDB.SaveChanges();
            }
        }

        public IEnumerable<ShoppingMealDTO> GetAll()
        {
            return contextDB.ShoppingMeals
                .Select(x => x.ShoppingMealToDTO());
        }

        public ShoppingMealDTO GetById(int id)
        {
            return contextDB.ShoppingMeals
                .FirstOrDefault(x => x.Id == id).ShoppingMealToDTO();
        }

        public ShoppingMealDTO Update(ShoppingMealDTO obj)
        {
            var shoppingMeal = contextDB.ShoppingMeals.FirstOrDefault(x => x.Id == obj.Id);
            if (shoppingMeal == null)
                return null;
            else
            {
                shoppingMeal.Meal = obj.Meal.DtoToMeal();
                shoppingMeal.Quantity = obj.Quantity;
                shoppingMeal.Basket = obj.Basket.DtoToBasket();
                contextDB.SaveChanges();
                return shoppingMeal.ShoppingMealToDTO();
            }
        }
    }
}
