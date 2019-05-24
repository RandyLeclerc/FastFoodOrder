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
        public ScheduleBTO AddSchedule(ScheduleBTO scheduleBto)
        {
            ScheduleDTO schedule = new ScheduleDTO();
            if (scheduleBto != null)
            {
                schedule = scheduleRepository.Create(scheduleBto.BTOToScheduleDomain().ScheduleDomainToDTO());
                return schedule.DTOToScheduleDomain().ScheduleToBTO();
            }
            return null;
        }
    }
}
