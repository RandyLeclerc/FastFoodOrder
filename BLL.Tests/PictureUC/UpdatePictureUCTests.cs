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
    public class UpdatePictureUCTests
    {
        [TestMethod]
        public void UpdatePicture_Should_Return_Valid_Data()
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

            mock.Setup(x => x.Update(myPicture)).Returns(
                new PictureDTO
                {
                    Id = 1,
                    IsProfilePicture = false,
                    Resto = new RestoDTO(),
                    Url = "www.myurl.com"
                }
            );
            PictureUC target = new PictureUC(mock.Object);

            //Act
            var result = target.UpdatePicture(new PictureBTO
            {
                Id = 1,
                IsProfilePicture = false,
                Resto = new RestoBTO(),
                Url = "www.myurl.com"
            });

            //Assert
            mock.Verify(u => u.Update(It.IsAny<PictureDTO>()), Times.Once());
        }

        [TestMethod]
        public void UpdatePicture_Should_Return_Null_If_Bto_Is_Null()
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

            mock.Setup(x => x.Update(myPicture)).Returns(
                new PictureDTO
                {
                    Id = 1,
                    IsProfilePicture = false,
                    Resto = new RestoDTO(),
                    Url = "www.myurl.com"
                }
            );
            PictureUC target = new PictureUC(mock.Object);

            //Act
            var result = target.UpdatePicture(null);

            //Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void UpdatePicture_Should_Return_Null_If_No_Result_Found_In_Db()
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

            mock.Setup(x => x.Update(myPicture));
            PictureUC target = new PictureUC(mock.Object);

            //Act
            var result = target.UpdatePicture(new PictureBTO
            {
                Id = 1,
                IsProfilePicture = true,
                Resto = new RestoBTO(),
                Url = "www.myurl.com"
            });

            //Assert
            Assert.IsNull(result);
        }
    }
}
