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
    public class SearchMealUCTests
    {

        [TestMethod]
        public void GetAllMeals_Should_Return_Proper_Collection()
        {
            //Arrange
            var mock = new Mock<IMealRepository>();
            var myMeals = new List<MealDTO>
            {
                new MealDTO
                {
                    Id = 1,
                    Name = "Salade César",
                    MealType = new MealTypeDTO()
                },
                new MealDTO
                {
                    Id = 2,
                    Name = "Mac N Cheese",
                    MealType = new MealTypeDTO()
                }
            };
            mock.Setup(x => x.GetAll()).Returns(myMeals);
            MealUC target = new MealUC(mock.Object);

            //Act
            var result = target.GetAllMeals().ToList();

            //Assert
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[1].Name, "Mac N Cheese");

        }
        [TestMethod]
        public void GetMealById_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IMealRepository>();
            var myMeal = new MealDTO
            {
                Id = 1,
                Name = "Starter",
                MealType = new MealTypeDTO()
            };

            mock.Setup(x => x.GetById(1)).Returns(
                    new MealDTO
                    {
                        Id = 1,
                        Name = "Starter",
                        MealType = new MealTypeDTO()
                    }
            );

            MealUC target = new MealUC(mock.Object);

            //Act
            var result = target.GetMealById(1);

            //Assert
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Name, "Starter");

        }
        [TestMethod]
        public void GetMealById_Should_Return_Null_When_Not_Found()
        {
            //Arrange
            var mock = new Mock<IMealRepository>();
            mock.Setup(x => x.GetById(25));
            MealUC target = new MealUC(mock.Object);

            //Act
            var result = target.GetMealById(25);

            //Assert
            Assert.AreEqual(null, result);
            Assert.IsNull(result);

        }
        //GetAllMealsByMealTypeId
        [TestMethod]
        public void GetAllMealsByMealTypeId_Should_Return_Proper_Collection()
        {
            //Arrange
            var mock = new Mock<IMealRepository>();
            var myMeals = new List<MealDTO>
            {
                new MealDTO
                {
                    Id = 1,
                    Name = "Salade César",
                    MealType = new MealTypeDTO()
                },
                new MealDTO
                {
                    Id = 2,
                    Name = "Mac N Cheese",
                    MealType = new MealTypeDTO()
                }
            };
            mock.Setup(x => x.GetMealsByMealTypeId(1)).Returns(myMeals);
            MealUC target = new MealUC(mock.Object);

            //Act
            var result = target.GetAllMealsByMealTypeId(1).ToList();

            //Assert
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[1].Name, "Mac N Cheese");

        }
        [TestMethod]
        public void GetAllMealsByMealTypeId_Should_Return_EmptyList_When_Not_Found()
        {
            //Arrange
            var mock = new Mock<IMealRepository>();

            mock.Setup(x => x.GetMealsByMealTypeId(1)).Returns(new List<MealDTO>());
            MealUC target = new MealUC(mock.Object);

            //Act
            var result = target.GetAllMealsByMealTypeId(1).ToList();

            //Assert
            Assert.AreEqual(0, result.Count);

        }
        [TestMethod]
        public void GetRestoIdByMealId_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IMealRepository>();

            mock.Setup(x => x.GetRestoIdByMealId(1)).Returns(5);

            MealUC target = new MealUC(mock.Object);

            //Act
            var result = target.GetRestoIdByMealId(1);

            //Assert
            Assert.AreEqual(result, 5);
        }
        [TestMethod]
        public void GetRestoIdByMealId_Should_Return_Zero_When_Not_Found()
        {
            //Arrange
            var mock = new Mock<IMealRepository>();

            mock.Setup(x => x.GetRestoIdByMealId(1));

            MealUC target = new MealUC(mock.Object);

            //Act
            var result = target.GetRestoIdByMealId(1);

            //Assert
            Assert.AreEqual(result, 0);
        }
    }
}
