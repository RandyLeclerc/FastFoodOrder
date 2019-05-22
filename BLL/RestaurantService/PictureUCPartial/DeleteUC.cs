using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class PictureUC
    {
        public void DeletePicture(int id)
        {
            pictureRepository.Delete(id);
        }
    }
}
