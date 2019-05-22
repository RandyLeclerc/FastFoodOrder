using BLL.Extensions;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class PictureUC
    {
        public PictureBTO AddPicture(PictureBTO pictureBto)
        {
            PictureDTO picture = new PictureDTO();
            if (pictureBto != null)
            {
                picture = pictureRepository.Create(pictureBto.BTOToPictureDomain().PictureDomainToDTO());
                return picture.DTOToPictureDomain().PictureToBTO();
            }
            return null;
        }
    }
}
