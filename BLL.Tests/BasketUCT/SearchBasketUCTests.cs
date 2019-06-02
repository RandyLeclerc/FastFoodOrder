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
    public class SearchBasketUCTests
    {

        [TestMethod]
        public void GetAllBaskets_Should_Return_Proper_Collection()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();
            var myBaskets = new List<BasketDTO>
            {
                new BasketDTO
                {
                    Id = 1,
                    UserId = "25"
                },
                new BasketDTO
                {
                Id = 2,
                UserId = "36"
                }
            };
            mock.Setup(x => x.GetAll()).Returns(myBaskets);
            BasketUC target = new BasketUC(mock.Object);

            //Act
            var result = target.GetAllBaskets().ToList();

            //Assert
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[1].UserId, "36");

        }
        [TestMethod]
        public void GetBasketById_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();
            var myBasket = new BasketDTO
            {
                Id = 1,
                UserId = "25"
            };

            mock.Setup(x => x.GetById(1)).Returns(
                    new BasketDTO
                    {
                        Id = 1,
                        UserId = "25"
                    }
            );

            BasketUC target = new BasketUC(mock.Object);

            //Act
            var result = target.GetBasketById(1);

            //Assert
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.UserId, "25");

        }
        [TestMethod]
        public void GetBasketById_Should_Return_Null_When_Not_Found()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();
            mock.Setup(x => x.GetById(25));
            BasketUC target = new BasketUC(mock.Object);

            //Act
            var result = target.GetBasketById(25);

            //Assert
            Assert.AreEqual(null, result);
            Assert.IsNull(result);

        }
        [TestMethod]
        public void GetBasketsByUserId_Should_Return_Proper_Collection()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();
            var myBaskets = new List<BasketDTO>
            {
                new BasketDTO
                {
                Id = 2,
                UserId = "36"
                }
            };
            mock.Setup(x => x.GetBasketsByUserId("36")).Returns(myBaskets);
            BasketUC target = new BasketUC(mock.Object);

            //Act
            var result = target.GetBasketsByUserId("36").ToList();

            //Assert
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].Id, 2);
        }
        [TestMethod]
        public void GetBasketsByUserId_Should_Return_New_List_When_Not_Found()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();

            mock.Setup(x => x.GetBasketsByUserId("36")).Returns(new List<BasketDTO>());
            BasketUC target = new BasketUC(mock.Object);

            //Act
            var result = target.GetBasketsByUserId("36").ToList();

            //Assert
            Assert.AreEqual(result.Count, 0);
        }
        [TestMethod]
        public void GetBasketsByRestoId_Should_Return_Proper_Collection()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();
            var myBaskets = new List<BasketDTO>
            {
                new BasketDTO
                {
                Id = 2,
                UserId = "36"
                }
            };
            mock.Setup(x => x.GetBasketsByRestoId(36)).Returns(myBaskets);
            BasketUC target = new BasketUC(mock.Object);

            //Act
            var result = target.GetBasketsByRestoId(36).ToList();

            //Assert
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].Id, 2);
        }
        [TestMethod]
        public void GetBasketsByRestoId_Should_Return_New_List_When_Not_Found()
        {
            //Arrange
            var mock = new Mock<IBasketRepository>();

            mock.Setup(x => x.GetBasketsByRestoId(36)).Returns(new List<BasketDTO>());
            BasketUC target = new BasketUC(mock.Object);

            //Act
            var result = target.GetBasketsByRestoId(36).ToList();

            //Assert
            Assert.AreEqual(result.Count, 0);
        }
    }
}
