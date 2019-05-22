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

    public class AddBasketUCTests
    {
        [TestMethod]
        public void CreateBasket_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();
            var myBasket = new BasketDTO
            {
                Id = 1,
                UserId = "25"
            };

            mock.Setup(x => x.Create(myBasket)).Returns(
                new BasketDTO
                {
                    Id = 1,
                    UserId = "25"
                }
            );

            BasketUC target = new BasketUC(mock.Object);

            //Act
            var result = target.AddBasket(new BasketBTO
            {
                Id = 1,
                UserId = "25"
            });

            //Assert
            mock.Verify(u => u.Create(It.IsAny<BasketDTO>()), Times.Once());
        }

        [TestMethod]
        public void CreateBasket_Should_Return_Null_If_Dto_Is_Null()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();
            var myBasket = new BasketDTO
            {
                Id = 1,
                UserId = "25"
            };

            mock.Setup(x => x.Create(myBasket)).Returns(
                new BasketDTO
                {
                    Id = 1,
                    UserId = "25"
                }
            );

            BasketUC target = new BasketUC(mock.Object);

            //Act
            var result = target.AddBasket(null);

            //Assert
            Assert.IsNull(result);
        }
    }
}
