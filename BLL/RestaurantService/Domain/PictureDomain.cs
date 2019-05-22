using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService.Domain
{
    public class PictureDomain
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsProfilePicture { get; set; }
        public int RestaurantId { get; set; }
        public RestoDomain Resto { get; set; }
    }
}
