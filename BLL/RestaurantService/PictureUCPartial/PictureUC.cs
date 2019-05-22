using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class PictureUC
    {
        private IPictureRepository pictureRepository;

        public PictureUC(IPictureRepository PictureRepository) 
        {
            pictureRepository = PictureRepository;
        }
    }
}
