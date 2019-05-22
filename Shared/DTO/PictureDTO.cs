using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
    public class PictureDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsProfilePicture { get; set; }

        public int RestaurantId { get; set; }
        public RestoDTO Resto { get; set; }
    }
}
