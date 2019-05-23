using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService.Domain
{
    public class ScheduleDomain
    {
        public int Id { get; set; }

        public int RestoId { get; set; }

        public RestoDomain Resto { get; set; }

        public int DayOfWeek { get; set; }

        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime TimeOpen { get; set; }

        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime TimeClosed { get; set; }
    }
}
