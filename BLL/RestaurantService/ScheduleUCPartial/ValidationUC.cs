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
        //Check if the created or updated schedule has proper hours before insert or update in DB
        private bool ScheduleIsValid(ScheduleBTO scheduleBTO, List<ScheduleDTO> schedules)
        {
            foreach (var item in schedules)
            {
                if (!((scheduleBTO.TimeOpen.TimeOfDay <= item.TimeOpen.TimeOfDay && scheduleBTO.TimeClosed.TimeOfDay <= item.TimeOpen.TimeOfDay) ||
                    (scheduleBTO.TimeOpen.TimeOfDay >= item.TimeClosed.TimeOfDay && scheduleBTO.TimeClosed.TimeOfDay >= item.TimeClosed.TimeOfDay)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
