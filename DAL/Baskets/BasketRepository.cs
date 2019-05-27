using DAL.Baskets.Entities;
using DAL.Data;
using DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.DataContracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Baskets
{
    public class BasketRepository : IBasketRepository
    {

        private readonly ApplicationDbContext contextDB;
        public BasketRepository(ApplicationDbContext ContextDB)
        {
            contextDB = ContextDB;
        }
        public BasketDTO Create(BasketDTO obj)
        {
            var basket = obj.DtoToBasket();

            contextDB.Users.First(x => x.Id == obj.UserId);
            basket.ShoppingMeals.ToList().ForEach(x => contextDB.Attach(x.Meal));
            contextDB.Baskets.Add(basket);
            contextDB.SaveChanges();
            return basket.BasketToDTO();
        }

        public void Delete(int id)
        {
            var basket = contextDB.Baskets.FirstOrDefault(x => x.Id == id);
            if (basket == null)
                throw new Exception("There is no Basket in this DB with this Id");
            else
            {
                contextDB.Baskets.Remove(basket);
                contextDB.SaveChanges();
            }
        }

        public IEnumerable<BasketDTO> GetAll()
        {
            return contextDB.Baskets
                .Select(x => x.BasketToDTO());
        }

        public IEnumerable<BasketDTO> GetBasketsByRestoId(int restoId)
        {
            var baskets = contextDB.Baskets
                .Include(u => u.User)
                .Include(x => x.ShoppingMeals)
                    .ThenInclude(y => y.Meal)
                        .ThenInclude(z => z.MealType);

            List<Basket> result = new List<Basket>();

            foreach (var item in baskets)
            {
                foreach (var shops in item.ShoppingMeals)
                {
                    if (shops.Meal.MealType.RestaurantId==restoId)
                    {
                        result.Add(item);
                        break;
                    }
                }
            }
            return result.Select(x=>x.BasketToDTO());
        }

        public IEnumerable<BasketDTO> GetBasketsByUserId(string UserId)
        {
            return contextDB.Baskets
                .Where(x=>x.UserId == UserId)
                .Include(x=>x.ShoppingMeals)
                    .ThenInclude(y=>y.Meal)
                        .ThenInclude(z=>z.MealType)
                .Select(x => x.BasketToDTO());
        }

        public BasketDTO GetById(int id)
        {
            return contextDB.Baskets
                .FirstOrDefault(x => x.Id == id).BasketToDTO();
        }

        public BasketDTO Update(BasketDTO obj)
        {
            var basket = contextDB.Baskets.FirstOrDefault(x => x.Id == obj.Id);
            if (basket == null)
                return null;
            else
            {
                basket.User = obj.User.DTOToUser();
                contextDB.SaveChanges();
                return basket.BasketToDTO();
            }
        }
    }
}
