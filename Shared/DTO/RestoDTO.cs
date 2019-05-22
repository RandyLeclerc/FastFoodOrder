using System.Collections.Generic;

namespace Shared.DTO
{
    public class RestoDTO
    {
        public int Id { get; set; }
        public string UserManagerId { get; set; }
        public UserDTO UserManager { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<CuisineDTO> Cuisines { get; set; }
        public ICollection<PictureDTO> Pictures { get; set; }
        public ICollection<MealTypeDTO> MealTypes { get; set; }
    }
}
