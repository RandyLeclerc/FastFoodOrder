using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.BTO
{
    public class PictureBTO
    {
        public int Id { get; set; }
        [Display(Name = "Picture")]
        public string Url { get; set; }
        [Display(Name = "Profile picture?")]
        public bool IsProfilePicture { get; set; }
        public int RestaurantId { get; set; }
        public RestoBTO Resto { get; set; }
    }
}
