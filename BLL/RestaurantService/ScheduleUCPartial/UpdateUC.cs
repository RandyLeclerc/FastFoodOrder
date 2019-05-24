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
                schedule = scheduleRepository.Update(scheduleBto.BTOToScheduleDomain().ScheduleDomainToDTO());
                return schedule?.DTOToScheduleDomain().ScheduleToBTO() ?? null;
            }
            return null;
        }
    }
}
