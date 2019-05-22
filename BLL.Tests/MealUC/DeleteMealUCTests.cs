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
    public class DeleteMealUCTests
    {
        [TestMethod]
        public void DeleteMeal_Should_Work()
        {
            //Arrange
            var mock = new Mock<IMealRepository>();
            var myMeal = new MealDTO
            {
                Id = 1,
                Name = "Starter",
                MealType = new MealTypeDTO()
            };

            mock.Setup(x => x.Delete(1));
            MealUC target = new MealUC(mock.Object);

            //Act
            target.DeleteMeal(1);

            //Assert
            mock.Verify(u => u.Delete(It.IsAny<int>()), Times.Once());
        }
    }
}
