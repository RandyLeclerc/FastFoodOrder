using BLL.Extensions;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class ScheduleUC
    {
        public ScheduleBTO UpdateSchedule(ScheduleBTO scheduleBto)
        {
            ScheduleDTO schedule = new ScheduleDTO();
            if (scheduleBto != null)
            {
                var schedules = scheduleRepository.GetSchedulesByDayOfWeekAndRestoId(scheduleBto.RestoId, (DayOfWeek)scheduleBto.WeekDay);

                //Remove the scheduleBto of the schedules because ScheduleIsValid() will check the scheduleBto in the list
                var scheduleToRemove = schedules.Find(x => x.Id == scheduleBto.Id);

                schedules.Remove(scheduleToRemove);

                if (ScheduleIsValid(scheduleBto, schedules))
                {
                    schedule = scheduleRepository.Update(scheduleBto.BTOToScheduleDomain().ScheduleDomainToDTO());
                    return schedule?.DTOToScheduleDomain().ScheduleToBTO() ?? null;
                }
            }
            return null;
        }
    }
}
