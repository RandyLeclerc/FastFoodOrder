using BLL.RestaurantService;
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
    public class UpdateRestaurantUCTests
    {
        [TestMethod]
        public void UpdateRestaurant_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            var myResto = new RestoDTO { City = "Bruxelles", Id = 1, Name = "R1" };

            mock.Setup(x => x.Update(myResto)).Returns(
                new RestoDTO { City = "Bruxelles", Id = 1, Name = "R1" }
            );
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.UpdateRestaurant(new RestoBTO { City = "Bruxelles", Id = 1, Name = "R1" });

            //Assert
            mock.Verify(u => u.Update(It.IsAny<RestoDTO>()), Times.Once());
        }

        [TestMethod]
        public void UpdateRestaurant_Should_Return_Null_If_Bto_Is_Null()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            var myResto = new RestoDTO { City = "Bruxelles", Id = 1, Name = "R1" };

            mock.Setup(x => x.Update(myResto)).Returns(
                new RestoDTO { City = "Bruxelles", Id = 1, Name = "R1" }
            );
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.UpdateRestaurant(null);

            //Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void UpdateRestaurant_Should_Return_Null_If_No_Result_Found_In_Db()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            var myResto = new RestoDTO { City = "Bruxelles", Id = 1, Name = "R1" };

            mock.Setup(x => x.Update(myResto));
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.UpdateRestaurant(new RestoBTO { City = "Bruxelles", Id = 1, Name = "R1" });

            //Assert
            Assert.IsNull(result);
        }
    }
}
