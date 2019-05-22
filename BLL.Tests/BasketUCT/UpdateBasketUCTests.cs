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
    public class UpdateBasketUCTests
    {
        [TestMethod]
        public void UpdateBasket_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();
            var myBasket = new BasketDTO
            {
                Id = 1,
                UserId = "25"
            };

            mock.Setup(x => x.Update(myBasket)).Returns(
                new BasketDTO
                {
                    Id = 1,
                    UserId = "25"
                }
            );
            BasketUC target = new BasketUC(mock.Object);

            //Act
            var result = target.UpdateBasket(new BasketBTO
            {
                Id = 1,
                UserId = "25"
            });

            //Assert
            mock.Verify(u => u.Update(It.IsAny<BasketDTO>()), Times.Once());
        }

        [TestMethod]
        public void UpdateBasket_Should_Return_Null_If_Bto_Is_Null()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();
            var myBasket = new BasketDTO
            {
                Id = 1,
                UserId = "25"
            };

            mock.Setup(x => x.Update(myBasket)).Returns(
                new BasketDTO
                {
                    Id = 1,
                    UserId = "25"
                }
            );
            BasketUC target = new BasketUC(mock.Object);

            //Act
            var result = target.UpdateBasket(null);

            //Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void UpdateBasket_Should_Return_Null_If_No_Result_Found_In_Db()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();
            var myBasket = new BasketDTO
            {
                Id = 1,
                UserId = "25"
            };

            mock.Setup(x => x.Update(myBasket));
            BasketUC target = new BasketUC(mock.Object);

            //Act
            var result = target.UpdateBasket(new BasketBTO
            {
                Id = 1,
                UserId = "25"
            });

            //Assert
            Assert.IsNull(result);
        }
    }
}
