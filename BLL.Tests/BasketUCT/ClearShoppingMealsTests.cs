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

    public class ClearShoppingMealsTests
    {
        [TestMethod]
        public void Add_Meal_To_Basket_Ok()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();
            MealBTO meal1 = new MealBTO { Id = 1, Name = "M1" };
            MealBTO meal2 = new MealBTO { Id = 2, Name = "M2" };

            //Arrange
            BasketUC target = new BasketUC(mock.Object);

            //Act
            target.AddMealToBasket(meal1, 1);
            target.AddMealToBasket(meal2, 1);

            target.ClearShoppingMeals();

            //Assert
            Assert.AreEqual(target.shoppingMeals.Count, 0);
        }
        
    }
}
