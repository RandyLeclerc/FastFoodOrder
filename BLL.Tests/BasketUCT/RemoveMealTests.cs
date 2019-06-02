using BLL.RestaurantService;
using BLL.ShoppingService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.BTO;
using Shared.DataContracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Tests
{
    [TestClass]

    public class RemoveMealTests
    {
        [TestMethod]
        public void Can_Remove_Meal()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();
            MealBTO meal1 = new MealBTO { Id = 1, Name = "M1" };
            MealBTO meal2 = new MealBTO { Id = 2, Name = "M2" };
            MealBTO meal3 = new MealBTO { Id = 3, Name = "M3" };

            //Arrange
            BasketUC target = new BasketUC(mock.Object);

            //Act
            target.AddMealToBasket(meal1, 1);
            target.AddMealToBasket(meal2, 3);
            target.AddMealToBasket(meal3, 5);

            target.RemoveMeal(meal2);

            //Assert
            Assert.AreEqual(target.shoppingMeals.Count, 2);
            Assert.AreEqual(target.shoppingMeals.Where(c => c.Meal.Id == meal2.Id).Count(), 0);

        }
        
    }
}
