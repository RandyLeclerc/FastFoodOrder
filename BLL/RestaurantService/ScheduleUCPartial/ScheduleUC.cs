using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class ScheduleUC
    {
        private IScheduleRepository scheduleRepository;

        public ScheduleUC(IScheduleRepository ScheduleRepository)
        {
            scheduleRepository = ScheduleRepository;
        }
    }
}
