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
    public class SearchPictureUCTests
    {

        [TestMethod]
        public void GetAllPictures_Should_Return_Should_Return_Proper_Collection()
        {
            //Arrange
            var mock = new Mock<IPictureRepository>();
            var myPictures = new List<PictureDTO>
            {
                new PictureDTO
                {
                    Id = 1,
                    IsProfilePicture = true,
                    Resto = new RestoDTO(),
                    Url = "www.myurl.com"
                },
                new PictureDTO
                {
                    Id = 2,
                    IsProfilePicture = false,
                    Resto = new RestoDTO(),
                    Url = "www.myurl2.com"
                }
            };
            mock.Setup(x => x.GetAll()).Returns(myPictures);
            PictureUC target = new PictureUC(mock.Object);

            //Act
            var result = target.GetAllPictures().ToList();

            //Assert
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[1].Url, "www.myurl2.com");

        }
        [TestMethod]
        public void GetPictureById_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IPictureRepository>();
            var myPicture = new PictureDTO
            {
                Id = 1,
                IsProfilePicture = true,
                Resto = new RestoDTO(),
                Url = "www.myurl.com"
            };

            mock.Setup(x => x.GetById(1)).Returns(
                    new PictureDTO
                    {
                        Id = 1,
                        IsProfilePicture = true,
                        Resto = new RestoDTO(),
                        Url = "www.myurl.com"
                    }
            );

            PictureUC target = new PictureUC(mock.Object);

            //Act
            var result = target.GetPictureById(1);

            //Assert
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Url, "www.myurl.com");

        }
        [TestMethod]
        public void GetPictureById_Should_Return_Null_When_Not_Found()
        {
            //Arrange
            var mock = new Mock<IPictureRepository>();
            mock.Setup(x => x.GetById(25));
            PictureUC target = new PictureUC(mock.Object);

            //Act
            var result = target.GetPictureById(25);

            //Assert
            Assert.AreEqual(null, result);
            Assert.IsNull(result);

        }
    }
}
