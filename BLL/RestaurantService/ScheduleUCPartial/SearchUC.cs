using BLL.Extensions;
using Shared.BTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class ScheduleUC
    {
        public ScheduleBTO GetScheduleById(int id)
        {
            var schedule = scheduleRepository.GetById(id);
            return schedule.DTOToScheduleDomain().ScheduleToBTO();
        }
        public ICollection<ScheduleBTO> GetAllSchedulesByRestaurantId(int id)
        {
            var schedules = scheduleRepository.GetAllSchedulesByRestoId(id);
            return schedules.Select(x=>x.DTOToScheduleDomain().ScheduleToBTO()).ToList();
        }
    }
}
