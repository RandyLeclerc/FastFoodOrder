using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.BTO
{
    public class RestoBTO
    {
        public int Id { get; set; }
        [Display(Name ="Manager")]
        public string UserManagerId { get; set; }
        public UserBTO UserManager { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public List<CuisineBTO> Cuisines { get; set; }
        public List<PictureBTO> Pictures { get; set; }
        public List<MealTypeBTO> MealTypes { get; set; }

        public string PictureUrl { get; set; }
        public BasketBTO Basket { get; set; }

    }
}
