using DAL.Schedules.Entities;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Extensions
{
    public static class ScheduleExtensions
    {
        public static ScheduleDTO ScheduleToDTO(this Schedule schedule)
        {
            if (schedule != null)
                return new ScheduleDTO
                {
                    Id = schedule.Id,
                    RestoId = schedule.RestoId,
                    DayOfWeek = schedule.DayOfWeek,
                    TimeOpen = schedule.TimeOpen,
                    TimeClosed = schedule.TimeClosed
                    //Resto = schedule.Restaurant.ToDTO()
                };
            else return null;
        }

        public static Schedule DtoToSchedule(this ScheduleDTO dto)
        {
            if (dto != null)
                return new Schedule
                {
                    Id = dto.Id,
                    RestoId = dto.RestoId,
                    DayOfWeek = dto.DayOfWeek,
                    TimeOpen = dto.TimeOpen,
                    TimeClosed = dto.TimeClosed,
                    Resto = dto.Resto.ToRestaurant()
                };
            else return null;
        }
    }
}
