using DAL.Restaurants.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Schedules.Entities
{
    public class Schedule
    {
        public int Id { get; set; }

        public int RestoId { get; set; }

        public Restaurant Resto { get; set; }

        public int DayOfWeek { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime TimeOpen { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime TimeClosed { get; set; }
    }
}
