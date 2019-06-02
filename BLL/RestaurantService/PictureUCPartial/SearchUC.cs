using BLL.Extensions;
using Shared.BTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class PictureUC
    {
        public ICollection<PictureBTO> GetAllPictures()
        {
            var pictures = pictureRepository.GetAll();
            var result = pictures.Select(x => x.DTOToPictureDomain().PictureToBTO()).ToList();
            return result;
        }
        public PictureBTO GetPictureById(int id)
        {
            var picture = pictureRepository.GetById(id);
            return picture.DTOToPictureDomain().PictureToBTO();
        }

        public ICollection<PictureBTO> GetAllPicturesByRestaurantId(int id)
        {
            var pictures = pictureRepository.GetPicturesByRestoId(id);

            return pictures.Select(x=>x.DTOToPictureDomain().PictureToBTO()).ToList();
        }
        public PictureBTO GetProfilePicture(int id)
        {
            return pictureRepository.GetProfilePictureByRestoId(id).DTOToPictureDomain().PictureToBTO();
        }


    }
}
