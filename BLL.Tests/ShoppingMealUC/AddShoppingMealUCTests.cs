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

    public class AddShoppingMealUCTests
    {
        [TestMethod]
        public void CreateShoppingMeal_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IShoppingMealRepository>();
            var myShoppingMeal = new ShoppingMealDTO
            {
                Id = 1,
                Quantity = 3
            };

            mock.Setup(x => x.Create(myShoppingMeal)).Returns(
                new ShoppingMealDTO
                {
                    Id = 1,
                    Quantity = 3
                }
            );

            ShoppingMealUC target = new ShoppingMealUC(mock.Object);

            //Act
            var result = target.AddShoppingMeal(new ShoppingMealBTO
            {
                Id = 1,
                Quantity = 3
            });

            //Assert
            mock.Verify(u => u.Create(It.IsAny<ShoppingMealDTO>()), Times.Once());
        }

        [TestMethod]
        public void CreateShoppingMeal_Should_Return_Null_If_Dto_Is_Null()
        {
            //Arrange
            var mock = new Mock<IShoppingMealRepository>();
            var myShoppingMeal = new ShoppingMealDTO
            {
                Id = 1,
                Quantity = 3
            };

            mock.Setup(x => x.Create(myShoppingMeal)).Returns(
                new ShoppingMealDTO
                {
                    Id = 1,
                    Quantity = 3
                }
            );

            ShoppingMealUC target = new ShoppingMealUC(mock.Object);

            //Act
            var result = target.AddShoppingMeal(null);

            //Assert
            Assert.IsNull(result);
        }
    }
}
