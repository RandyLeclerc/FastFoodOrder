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
    public class DeleteMealTypeUCTests
    {
        [TestMethod]
        public void DeleteMealType_Should_Work()
        {
            //Arrange
            var mock = new Mock<IMealTypeRepository>();
            var myMealType = new MealTypeDTO
            {
                Id = 1,
                Name = "Starter",
                Restaurant = new RestoDTO()
            };

            mock.Setup(x => x.Delete(1));
            MealTypeUC target = new MealTypeUC(mock.Object);

            //Act
            target.DeleteMealType(1);

            //Assert
            mock.Verify(u => u.Delete(It.IsAny<int>()), Times.Once());
        }
    }
}
