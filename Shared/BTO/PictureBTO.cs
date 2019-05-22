using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.BTO
{
    public class PictureBTO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsProfilePicture { get; set; }
        public int RestaurantId { get; set; }
        public RestoBTO Resto { get; set; }
    }
}
