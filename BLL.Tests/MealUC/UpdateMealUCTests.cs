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
    public class UpdateMealUCTests
    {
        [TestMethod]
        public void UpdateMeal_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IMealRepository>();
            var myMeal = new MealDTO
            {
                Id = 1,
                Name = "Starter",
                MealType = new MealTypeDTO()
            };

            mock.Setup(x => x.Update(myMeal)).Returns(
                new MealDTO
                {
                    Id = 1,
                    Name = "Starter",
                    MealType = new MealTypeDTO()
                }
            );
            MealUC target = new MealUC(mock.Object);

            //Act
            var result = target.UpdateMeal(new MealBTO
            {
                Id = 1,
                Name = "Starter",
                MealType = new MealTypeBTO()
            });

            //Assert
            mock.Verify(u => u.Update(It.IsAny<MealDTO>()), Times.Once());
        }

        [TestMethod]
        public void UpdateMeal_Should_Return_Null_If_Bto_Is_Null()
        {
            //Arrange
            var mock = new Mock<IMealRepository>();
            var myMeal = new MealDTO
            {
                Id = 1,
                Name = "Starter",
                MealType = new MealTypeDTO()
            };

            mock.Setup(x => x.Update(myMeal)).Returns(
                new MealDTO
                {
                    Id = 1,
                    Name = "Starter",
                    MealType = new MealTypeDTO()
                }
            );
            MealUC target = new MealUC(mock.Object);

            //Act
            var result = target.UpdateMeal(null);

            //Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void UpdateMeal_Should_Return_Null_If_No_Result_Found_In_Db()
        {
            //Arrange
            var mock = new Mock<IMealRepository>();
            var myMeal = new MealDTO
            {
                Id = 1,
                Name = "Starter",
                MealType = new MealTypeDTO()
            };

            mock.Setup(x => x.Update(myMeal));
            MealUC target = new MealUC(mock.Object);

            //Act
            var result = target.UpdateMeal(new MealBTO
            {
                Id = 1,
                Name = "Starter",
                MealType = new MealTypeBTO()
            });

            //Assert
            Assert.IsNull(result);
        }
    }
}
