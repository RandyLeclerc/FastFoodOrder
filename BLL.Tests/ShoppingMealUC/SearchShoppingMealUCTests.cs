using BLL.RestaurantService;
using BLL.ShoppingService;
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
    public class SearchShoppingMealUCTests
    {

        [TestMethod]
        public void GetAllShoppingMeals_Should_Return_Should_Return_Proper_Collection()
        {
            //Arrange
            var mock = new Mock<IShoppingMealRepository>();
            var myShoppingMeals = new List<ShoppingMealDTO>
            {
                new ShoppingMealDTO
                {
                Id = 1,
                Quantity = 3
                },
                new ShoppingMealDTO
                {
                    Id = 2,
                    Quantity = 18
                }
            };
            mock.Setup(x => x.GetAll()).Returns(myShoppingMeals);
            ShoppingMealUC target = new ShoppingMealUC(mock.Object);

            //Act
            var result = target.GetAllShoppingMeals().ToList();

            //Assert
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[1].Quantity, 18);

        }
        [TestMethod]
        public void GetShoppingMealById_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IShoppingMealRepository>();
            var myShoppingMeal = new ShoppingMealDTO
            {
                Id = 1,
                Quantity = 3
            };

            mock.Setup(x => x.GetById(1)).Returns(
                    new ShoppingMealDTO
                    {
                        Id = 1,
                        Quantity = 3
                    }
            );

            ShoppingMealUC target = new ShoppingMealUC(mock.Object);

            //Act
            var result = target.GetShoppingMealById(1);

            //Assert
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Quantity, 3);

        }
        [TestMethod]
        public void GetShoppingMealById_Should_Return_Null_When_Not_Found()
        {
            //Arrange
            var mock = new Mock<IShoppingMealRepository>();
            mock.Setup(x => x.GetById(25));
            ShoppingMealUC target = new ShoppingMealUC(mock.Object);

            //Act
            var result = target.GetShoppingMealById(25);

            //Assert
            Assert.AreEqual(null, result);
            Assert.IsNull(result);

        }
    }
}
