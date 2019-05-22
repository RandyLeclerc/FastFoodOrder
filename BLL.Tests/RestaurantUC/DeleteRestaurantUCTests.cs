using BLL.RestaurantService;
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
    public class DeleteRestaurantUCTests
    {
        [TestMethod]
        public void DeleteRestaurant_Should_Work()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            var myResto = new RestoDTO { City = "Bruxelles", Id = 1, Name = "R1" };

            mock.Setup(x => x.Delete(1));
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            target.DeleteRestaurant(1);

            //Assert
            mock.Verify(u => u.Delete(It.IsAny<int>()), Times.Once());
        }
    }
}
