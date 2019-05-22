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
    public class SearchCuisineUCTests
    {

        [TestMethod]
        public void GetAllCuisines_Should_Return_Should_Return_Proper_Collection()
        {
            //Arrange
            var mock = new Mock<ICuisineRepository>();
            mock.Setup(x => x.GetAll()).Returns(new List<CuisineDTO>()
            {
                new CuisineDTO{Id= 1, Name = "Japonais"},
                new CuisineDTO{Id= 2, Name = "Viet"},
                new CuisineDTO{Id= 3, Name = "Thaï"},

            });
            CuisineUC target = new CuisineUC(mock.Object);

            //Act
            var result = target.GetAllCuisines().ToList();

            //Assert
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[2].Name, "Viet");

        }
        [TestMethod]
        public void GetCuisineById_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<ICuisineRepository>();
            mock.Setup(x => x.GetById(1)).Returns(
                new CuisineDTO { Id = 1, Name = "Japonais" }
            );
            CuisineUC target = new CuisineUC(mock.Object);

            //Act
            var result = target.GetCuisineById(1);

            //Assert
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Name, "Japonais");

        }
        [TestMethod]
        public void GetCuisineById_Should_Return_Null_When_Not_Found()
        {
            //Arrange
            var mock = new Mock<ICuisineRepository>();
            mock.Setup(x => x.GetById(25));
            CuisineUC target = new CuisineUC(mock.Object);

            //Act
            var result = target.GetCuisineById(25);

            //Assert
            Assert.AreEqual(null, result);
            Assert.IsNull(result);

        }
    }
}
