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
    public class UpdateMealTypeUCTests
    {
        [TestMethod]
        public void UpdateMealType_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IMealTypeRepository>();
            var myMealType = new MealTypeDTO
            {
                Id = 1,
                Name = "Starter",
                Restaurant = new RestoDTO()
            };

            mock.Setup(x => x.Update(myMealType)).Returns(
                new MealTypeDTO
                {
                    Id = 1,
                    Name = "Starter",
                    Restaurant = new RestoDTO()
                }
            );
            MealTypeUC target = new MealTypeUC(mock.Object);

            //Act
            var result = target.UpdateMealType(new MealTypeBTO
            {
                Id = 1,
                Name = "Starter",
                Restaurant = new RestoBTO()
            });

            //Assert
            mock.Verify(u => u.Update(It.IsAny<MealTypeDTO>()), Times.Once());
        }

        [TestMethod]
        public void UpdateMealType_Should_Return_Null_If_Bto_Is_Null()
        {
            //Arrange
            var mock = new Mock<IMealTypeRepository>();
            var myMealType = new MealTypeDTO
            {
                Id = 1,
                Name = "Starter",
                Restaurant = new RestoDTO()
            };

            mock.Setup(x => x.Update(myMealType)).Returns(
                new MealTypeDTO
                {
                    Id = 1,
                    Name = "Starter",
                    Restaurant = new RestoDTO()
                }
            );
            MealTypeUC target = new MealTypeUC(mock.Object);

            //Act
            var result = target.UpdateMealType(null);

            //Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void UpdateMealType_Should_Return_Null_If_No_Result_Found_In_Db()
        {
            //Arrange
            var mock = new Mock<IMealTypeRepository>();
            var myMealType = new MealTypeDTO
            {
                Id = 1,
                Name = "Starter",
                Restaurant = new RestoDTO()
            };

            mock.Setup(x => x.Update(myMealType));
            MealTypeUC target = new MealTypeUC(mock.Object);

            //Act
            var result = target.UpdateMealType(new MealTypeBTO
            {
                Id = 1,
                Name = "Starter",
                Restaurant = new RestoBTO()
            });

            //Assert
            Assert.IsNull(result);
        }
    }
}
