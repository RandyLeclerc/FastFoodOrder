using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
    public class CuisineDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RestoDTO> Restaurants { get; set; }

    }
}
