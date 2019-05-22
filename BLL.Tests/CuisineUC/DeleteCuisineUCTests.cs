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
    public class DeleteCuisineUCTests
    {
        [TestMethod]
        public void DeleteCuisine_Should_Work()
        {
            //Arrange
            var mock = new Mock<ICuisineRepository>();
            var myCuisine = new CuisineDTO { Id = 1, Name = "Japonais" };

            mock.Setup(x => x.Delete(1));
            CuisineUC target = new CuisineUC(mock.Object);

            //Act
            target.DeleteCuisine(1);

            //Assert
            mock.Verify(u => u.Delete(It.IsAny<int>()), Times.Once());
        }
    }
}
