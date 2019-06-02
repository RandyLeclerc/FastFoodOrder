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
    public class SearchMealTypeUCTests
    {

        [TestMethod]
        public void GetAllMealTypes_Should_Return_Proper_Collection()
        {
            //Arrange
            var mock = new Mock<IMealTypeRepository>();
            var myMealTypes = new List<MealTypeDTO>
            {
                new MealTypeDTO
                {
                    Id = 1,
                    Name = "Starter",
                    Restaurant = new RestoDTO()
                },
                new MealTypeDTO
                {
                    Id = 2,
                    Name = "Main",
                    Restaurant = new RestoDTO()
                }
            };
            mock.Setup(x => x.GetAll()).Returns(myMealTypes);
            MealTypeUC target = new MealTypeUC(mock.Object);

            //Act
            var result = target.GetAllMealTypes().ToList();

            //Assert
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[1].Name, "Main");

        }
        [TestMethod]
        public void GetMealTypeById_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IMealTypeRepository>();
            var myMealType = new MealTypeDTO
            {
                Id = 1,
                Name = "Starter",
                Restaurant = new RestoDTO()
            };

            mock.Setup(x => x.GetById(1)).Returns(
                    new MealTypeDTO
                    {
                        Id = 1,
                        Name = "Starter",
                        Restaurant = new RestoDTO()
                    }
            );

            MealTypeUC target = new MealTypeUC(mock.Object);

            //Act
            var result = target.GetMealTypeById(1);

            //Assert
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Name, "Starter");

        }
        [TestMethod]
        public void GetMealTypeById_Should_Return_Null_When_Not_Found()
        {
            //Arrange
            var mock = new Mock<IMealTypeRepository>();
            mock.Setup(x => x.GetById(25));
            MealTypeUC target = new MealTypeUC(mock.Object);

            //Act
            var result = target.GetMealTypeById(25);

            //Assert
            Assert.AreEqual(null, result);
            Assert.IsNull(result);

        }
        [TestMethod]
        public void GetAllMealTypesByRestaurantId_Should_Return_Proper_Collection()
        {
            //Arrange
            var mock = new Mock<IMealTypeRepository>();
            var myMealTypes = new List<MealTypeDTO>
            {
                new MealTypeDTO
                {
                    Id = 1,
                    Name = "Starter",
                    Restaurant = new RestoDTO()
                },
                new MealTypeDTO
                {
                    Id = 2,
                    Name = "Main",
                    Restaurant = new RestoDTO()
                    {
                        Id = 35
                    }
                }
            };
            mock.Setup(x => x.GetMealTypesByRestoId(35)).Returns(myMealTypes);
            MealTypeUC target = new MealTypeUC(mock.Object);

            //Act
            var result = target.GetAllMealTypesByRestaurantId(35).ToList();

            //Assert
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[1].Name, "Main");
        }
        [TestMethod]
        public void GetAllMealTypesByRestaurantId_Should_Return_Null_When_Not_Found()
        {
            //Arrange
            var mock = new Mock<IMealTypeRepository>();
            var myMealTypes = new List<MealTypeDTO>
            {
                new MealTypeDTO
                {
                    Id = 1,
                    Name = "Starter",
                    Restaurant = new RestoDTO()
                },
                new MealTypeDTO
                {
                    Id = 2,
                    Name = "Main",
                    Restaurant = new RestoDTO()
                    {
                        Id = 35
                    }
                }
            };
            mock.Setup(x => x.GetMealTypesByRestoId(35));
            MealTypeUC target = new MealTypeUC(mock.Object);

            //Act
            var result = target.GetAllMealTypesByRestaurantId(35);

            //Assert
            Assert.IsNull(result);

        }
    }
}
