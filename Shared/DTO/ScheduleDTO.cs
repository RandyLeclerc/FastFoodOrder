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
        public DateTime TimeOpen { get; set; }
        public DateTime TimeClosed { get; set; }
    }
}
