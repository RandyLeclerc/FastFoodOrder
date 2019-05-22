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
    public class AddCuisineUCTests
    {
        [TestMethod]
        public void CreateCuisine_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<ICuisineRepository>();
            var myCuisine = new CuisineDTO {  Id=1, Name = "Japonais" };

            mock.Setup(x => x.Create(myCuisine)).Returns(
                new CuisineDTO { Id = 1, Name = "Japonais" }
            );
            CuisineUC target = new CuisineUC(mock.Object);

            //Act
            var result = target.AddCuisine(new CuisineBTO { Id = 1, Name = "Japonais" });

            //Assert
            mock.Verify(u => u.Create(It.IsAny<CuisineDTO>()), Times.Once());

        }
        [TestMethod]
        public void CreateCuisine_Should_Return_Null_If_Dto_Is_Null()
        {
            //Arrange
            var mock = new Mock<ICuisineRepository>();
            var myCuisine = new CuisineDTO { Id = 1, Name = "Japonais" };

            mock.Setup(x => x.Create(myCuisine)).Returns(
                new CuisineDTO { Id = 1, Name = "Japonais" }
            );
            CuisineUC target = new CuisineUC(mock.Object);

            //Act
            var result = target.AddCuisine(null);

            //Assert
            Assert.IsNull(result);

        }
    }
}
