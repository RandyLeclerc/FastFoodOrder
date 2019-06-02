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
        [Display(Name = "Restaurant name")]
        public string Name { get; set; }
        [Display(Name = "Short description")]
        public string ShortDescription { get; set; }
        [Display(Name = "Long description")]
        public string LongDescription { get; set; }
        public string City { get; set; }
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        public List<CuisineBTO> Cuisines { get; set; }
        public List<PictureBTO> Pictures { get; set; }
        [Display(Name = "Meal types")]
        public List<MealTypeBTO> MealTypes { get; set; }
        public List<ScheduleBTO> Schedules { get; set; }

        public string PictureUrl { get; set; }
        public BasketBTO Basket { get; set; }
    }
}
