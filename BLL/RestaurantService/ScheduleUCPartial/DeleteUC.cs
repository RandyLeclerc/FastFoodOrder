using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class ScheduleUC
    {
        public void DeleteSchedule(int id)
        {
            scheduleRepository.Delete(id);
        }
    }
}
