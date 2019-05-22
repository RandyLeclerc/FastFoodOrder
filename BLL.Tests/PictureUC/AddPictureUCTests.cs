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

    public class AddPictureUCTests
    {
        [TestMethod]
        public void CreatePicture_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IPictureRepository>();
            var myPicture = new PictureDTO
            {
                Id = 1,
                IsProfilePicture = true,
                Resto = new RestoDTO(),
                Url ="www.myurl.com"
            };

            mock.Setup(x => x.Create(myPicture)).Returns(
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
            var result = target.AddPicture(new PictureBTO
            {
                Id = 1,
                IsProfilePicture = true,
                Resto = new RestoBTO(),
                Url = "www.myurl.com"
            });

            //Assert
            mock.Verify(u => u.Create(It.IsAny<PictureDTO>()), Times.Once());
        }

        [TestMethod]
        public void CreatePicture_Should_Return_Null_If_Dto_Is_Null()
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

            mock.Setup(x => x.Create(myPicture)).Returns(
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
            var result = target.AddPicture(null);

            //Assert
            Assert.IsNull(result);
        }
    }
}
