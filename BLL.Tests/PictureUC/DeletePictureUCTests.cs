using BLL.RestaurantService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.DataContracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Tests
{
    [TestClass]
    public class DeletePictureUCTests
    {
        [TestMethod]
        public void DeletePicture_Should_Work()
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

            mock.Setup(x => x.Delete(1));
            PictureUC target = new PictureUC(mock.Object);

            //Act
            target.DeletePicture(1);

            //Assert
            mock.Verify(u => u.Delete(It.IsAny<int>()), Times.Once());
        }
    }
}
