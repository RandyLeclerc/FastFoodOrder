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

    public class AddMealTypeUCTests
    {
        [TestMethod]
        public void CreateMealType_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IMealTypeRepository>();
            var myMealType = new MealTypeDTO
            {
                Id = 1,
                Name = "Starter",
                Restaurant = new RestoDTO()
            };

            mock.Setup(x => x.Create(myMealType)).Returns(
                new MealTypeDTO
                {
                    Id = 1,
                    Name = "Starter",
                    Restaurant = new RestoDTO()
                }
            );

            MealTypeUC target = new MealTypeUC(mock.Object);

            //Act
            var result = target.AddMealType(new MealTypeBTO
            {
                Id = 1,
                Name = "Starter",
                Restaurant = new RestoBTO()
            });

            //Assert
            mock.Verify(u => u.Create(It.IsAny<MealTypeDTO>()), Times.Once());
        }

        [TestMethod]
        public void CreateMealType_Should_Return_Null_If_Dto_Is_Null()
        {
            //Arrange
            var mock = new Mock<IMealTypeRepository>();
            var myMealType = new MealTypeDTO
            {
                Id = 1,
                Name = "Starter",
                Restaurant = new RestoDTO()
            };

            mock.Setup(x => x.Create(myMealType)).Returns(
                new MealTypeDTO
                {
                    Id = 1,
                    Name = "Starter",
                    Restaurant = new RestoDTO()
                }
            );

            MealTypeUC target = new MealTypeUC(mock.Object);

            //Act
            var result = target.AddMealType(null);

            //Assert
            Assert.IsNull(result);
        }
    }
}
