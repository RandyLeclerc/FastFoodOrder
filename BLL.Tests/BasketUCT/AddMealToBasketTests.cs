using BLL.RestaurantService;
using BLL.ShoppingService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.BTO;
using Shared.DataContracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Tests
{
    [TestClass]

    public class AddMealToBasketTests
    {
        [TestMethod]
        public void Add_Meal_To_Basket_Ok()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();
            MealBTO meal1 = new MealBTO { Id = 1, Name = "P1" };
            MealBTO meal2 = new MealBTO { Id = 2, Name = "P2" };

            //Arrange
            BasketUC target = new BasketUC(mock.Object);

            //Act
            target.AddMealToBasket(meal1, 1);
            target.AddMealToBasket(meal2, 1);

            var results = target.shoppingMeals;

            //Assert
            Assert.AreEqual(results.Count, 2);
            Assert.AreEqual(results[0].Meal.Id, meal1.Id);
            Assert.AreEqual(results[0].Meal.Name, meal1.Name);
            Assert.AreEqual(results[1].Meal.Id, meal2.Id);
            Assert.AreEqual(results[1].Meal.Name, meal2.Name);
        }
        [TestMethod]
        public void Add_Meal_To_Basket_Can_Add_Quantity()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();
            MealBTO meal1 = new MealBTO { Id = 1, Name = "P1" };
            MealBTO meal2 = new MealBTO { Id = 2, Name = "P2" };

            BasketUC target = new BasketUC(mock.Object);

            //Act
            target.AddMealToBasket(meal1, 1);
            target.AddMealToBasket(meal2, 1);
            target.AddMealToBasket(meal1, 10);

            var results = target.shoppingMeals;

            //Assert
            Assert.AreEqual(results.Count, 2);
            Assert.AreEqual(results[0].Quantity, 11);
            Assert.AreEqual(results[1].Quantity, 1);
        }
    }
}
