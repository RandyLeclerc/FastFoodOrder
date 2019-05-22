using BLL.RestaurantService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.BTO;
using Shared.DataContracts;
using Shared.DTO;
using System.Collections.Generic;
using System.Linq;
namespace BLL.Tests
{
    [TestClass]
    public class AddRestaurantUCTests
    {
        [TestMethod]
        public void CreateRestaurant_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            var myResto = new RestoDTO { City = "Bruxelles", Id = 1, Name = "R1" };

            mock.Setup(x => x.Create(myResto)).Returns(
                new RestoDTO { City = "Bruxelles", Id = 1, Name = "R1" }
            );
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.AddRestaurant(new RestoBTO { City = "Bruxelles", Id = 1, Name = "R1" });

            //Assert
            mock.Verify(u => u.Create(It.IsAny<RestoDTO>()), Times.Once());

        }
        [TestMethod]
        public void CreateRestaurant_Should_Return_Null_If_Dto_Is_Null()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            var myResto = new RestoDTO { City = "Bruxelles", Id = 1, Name = "R1" };

            mock.Setup(x => x.Create(myResto)).Returns(
                new RestoDTO { City = "Bruxelles", Id = 1, Name = "R1" }
            );
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.AddRestaurant(null);

            //Assert
            Assert.IsNull(result);

        }
    }
}
