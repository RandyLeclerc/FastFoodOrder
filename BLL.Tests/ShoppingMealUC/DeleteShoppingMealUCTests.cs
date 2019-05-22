using BLL.RestaurantService;
using BLL.ShoppingService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.DataContracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Tests
{
    [TestClass]
    public class DeleteShoppingMealUCTests
    {
        [TestMethod]
        public void DeleteShoppingMeal_Should_Work()
        {
            //Arrange
            var mock = new Mock<IShoppingMealRepository>();
            var myShoppingMeal = new ShoppingMealDTO
            {
                Id = 1,
                Quantity = 3
            };

            mock.Setup(x => x.Delete(1));
            ShoppingMealUC target = new ShoppingMealUC(mock.Object);

            //Act
            target.DeleteShoppingMeal(1);

            //Assert
            mock.Verify(u => u.Delete(It.IsAny<int>()), Times.Once());
        }
    }
}
