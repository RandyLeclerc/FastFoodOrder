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
    public class UpdateCuisineUCTests
    {
        [TestMethod]
        public void UpdateCuisine_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<ICuisineRepository>();
            var myCuisine = new CuisineDTO { Id = 1, Name = "Japonais" };

            mock.Setup(x => x.Update(myCuisine)).Returns(
                new CuisineDTO { Id = 1, Name = "Chinois" }
            );
            CuisineUC target = new CuisineUC(mock.Object);

            //Act
            var result = target.UpdateCuisine(new CuisineBTO { Id = 1, Name = "Japonais" });

            //Assert
            mock.Verify(u => u.Update(It.IsAny<CuisineDTO>()), Times.Once());
            

        }

        [TestMethod]
        public void UpdateCuisine_Should_Return_Null_If_Bto_Is_Null()
        {
            //Arrange
            var mock = new Mock<ICuisineRepository>();
            var myCuisine = new CuisineDTO { Id = 1, Name = "Japonais" };

            mock.Setup(x => x.Update(myCuisine)).Returns(
                new CuisineDTO { Id = 1, Name = "Japonais" }
            );
            CuisineUC target = new CuisineUC(mock.Object);

            //Act
            var result = target.UpdateCuisine(null);

            //Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void UpdateCuisine_Should_Return_Null_If_No_Result_Found_In_Db()
        {
            //Arrange
            var mock = new Mock<ICuisineRepository>();
            var myCuisine = new CuisineDTO { Id = 1, Name = "Japonais" };

            mock.Setup(x => x.Update(myCuisine));
            CuisineUC target = new CuisineUC(mock.Object);

            //Act
            var result = target.UpdateCuisine(new CuisineBTO { Id = 1, Name = "Japonais" });

            //Assert
            Assert.IsNull(result);
        }
    }
}
