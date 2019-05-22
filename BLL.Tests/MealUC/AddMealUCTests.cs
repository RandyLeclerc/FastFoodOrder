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

    public class AddMealUCTests
    {
        [TestMethod]
        public void CreateMeal_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IMealRepository>();
            var myMeal = new MealDTO
            {
                Id = 1,
                Name = "Starter",
                MealType = new MealTypeDTO()
            };

            mock.Setup(x => x.Create(myMeal)).Returns(
                new MealDTO
                {
                    Id = 1,
                    Name = "Starter",
                    MealType = new MealTypeDTO()
                }
            );

            MealUC target = new MealUC(mock.Object);

            //Act
            var result = target.AddMeal(new MealBTO
            {
                Id = 1,
                Name = "Starter",
                MealType = new MealTypeBTO()
            });

            //Assert
            mock.Verify(u => u.Create(It.IsAny<MealDTO>()), Times.Once());
        }

        [TestMethod]
        public void CreateMeal_Should_Return_Null_If_Dto_Is_Null()
        {
            //Arrange
            var mock = new Mock<IMealRepository>();
            var myMeal = new MealDTO
            {
                Id = 1,
                Name = "Starter",
                MealType = new MealTypeDTO()
            };

            mock.Setup(x => x.Create(myMeal)).Returns(
                new MealDTO
                {
                    Id = 1,
                    Name = "Starter",
                    MealType = new MealTypeDTO()
                }
            );

            MealUC target = new MealUC(mock.Object);

            //Act
            var result = target.AddMeal(null);

            //Assert
            Assert.IsNull(result);
        }
    }
}
