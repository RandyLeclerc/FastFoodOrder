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
    public class UpdateShoppingMealUCTests
    {
        [TestMethod]
        public void UpdateShoppingMeal_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IShoppingMealRepository>();
            var myShoppingMeal = new ShoppingMealDTO
            {
                Id = 1,
                Quantity = 3
            };

            mock.Setup(x => x.Update(myShoppingMeal)).Returns(
                new ShoppingMealDTO
                {
                    Id = 1,
                    Quantity = 3
                }
            );
            ShoppingMealUC target = new ShoppingMealUC(mock.Object);

            //Act
            var result = target.UpdateShoppingMeal(new ShoppingMealBTO
            {
                Id = 1,
                Quantity = 3
            });

            //Assert
            mock.Verify(u => u.Update(It.IsAny<ShoppingMealDTO>()), Times.Once());
        }

        [TestMethod]
        public void UpdateShoppingMeal_Should_Return_Null_If_Bto_Is_Null()
        {
            //Arrange
            var mock = new Mock<IShoppingMealRepository>();
            var myShoppingMeal = new ShoppingMealDTO
            {
                Id = 1,
                Quantity = 3
            };

            mock.Setup(x => x.Update(myShoppingMeal)).Returns(
                new ShoppingMealDTO
                {
                    Id = 1,
                    Quantity = 3
                }
            );
            ShoppingMealUC target = new ShoppingMealUC(mock.Object);

            //Act
            var result = target.UpdateShoppingMeal(null);

            //Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void UpdateShoppingMeal_Should_Return_Null_If_No_Result_Found_In_Db()
        {
            //Arrange
            var mock = new Mock<IShoppingMealRepository>();
            var myShoppingMeal = new ShoppingMealDTO
            {
                Id = 1,
                Quantity = 3
            };

            mock.Setup(x => x.Update(myShoppingMeal));
            ShoppingMealUC target = new ShoppingMealUC(mock.Object);

            //Act
            var result = target.UpdateShoppingMeal(new ShoppingMealBTO
            {
                Id = 1,
                Quantity = 3
            });

            //Assert
            Assert.IsNull(result);
        }
    }
}
