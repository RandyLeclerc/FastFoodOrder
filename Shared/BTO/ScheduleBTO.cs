using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.BTO
{
    public class ScheduleBTO
    {
        public int Id { get; set; }

        public int RestoId { get; set; }

        public RestoBTO Resto { get; set; }

        public WeekDay WeekDay { get; set; }
        //public int DayOfWeek { get; set; }


        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime TimeOpen { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime TimeClosed { get; set; }
    }
    public enum WeekDay
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
}
