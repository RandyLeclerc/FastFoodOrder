using BLL.UserService.Domain;
using System.Collections.Generic;

namespace BLL.RestaurantService.Domain
{
    public class RestoDomain
    {
        public int Id { get; set; }
        public string UserManagerId { get; set; }
        public ApplicationUserDomain UserManager { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<CuisineDomain> Cuisines { get; set; }
        public ICollection<PictureDomain> Pictures { get; set; }
        public ICollection<MealTypeDomain> MealTypes { get; set; }
        public ICollection<ScheduleDomain> Schedules { get; set; }

    }
}