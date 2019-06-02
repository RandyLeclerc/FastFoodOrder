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

    public class SumAmountTests
    {
        [TestMethod]
        public void Sum_Amount_Ok()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();
            MealBTO meal1 = new MealBTO { Id = 1, Name = "P1", Price = 10 };
            MealBTO meal2 = new MealBTO { Id = 2, Name = "P2", Price = 5 };

            //Arrange
            BasketUC target = new BasketUC(mock.Object);

            //Act
            target.AddMealToBasket(meal1, 1);
            target.AddMealToBasket(meal2, 1);
            target.AddMealToBasket(meal1, 3);


            var results = target.ComputeTotalValue();

            //Assert
            Assert.AreEqual(results, 45);

        }
        
    }
}
