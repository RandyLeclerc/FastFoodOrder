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
    public class DeleteBasketUCTests
    {
        [TestMethod]
        public void DeleteBasket_Should_Work()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();
            var myBasket = new BasketDTO
            {
                Id = 1,
                UserId = "25"
            };

            mock.Setup(x => x.Delete(1));
            BasketUC target = new BasketUC(mock.Object);

            //Act
            target.DeleteBasket(1);

            //Assert
            mock.Verify(u => u.Delete(It.IsAny<int>()), Times.Once());
        }
    }
}
