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
        public PictureBTO UpdatePicture(PictureBTO pictureBto)
        {
            PictureDTO picture = new PictureDTO();
            if (pictureBto != null)
            {
                picture = pictureRepository.Update(pictureBto.BTOToPictureDomain().PictureDomainToDTO());
                return picture?.DTOToPictureDomain().PictureToBTO() ?? null;
            }
            return null;
        }
    }
}
