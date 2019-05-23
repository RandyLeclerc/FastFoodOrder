using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
    public class ScheduleDTO
    {
        public int Id { get; set; }

        public int RestoId { get; set; }

        public RestoDTO Resto { get; set; }

        public int DayOfWeek { get; set; }

        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime TimeOpen { get; set; }

        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime TimeClosed { get; set; }
    }
}
