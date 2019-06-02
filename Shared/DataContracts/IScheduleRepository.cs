using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataContracts
{
    public interface IScheduleRepository : IRepository<ScheduleDTO>
    {
        List<ScheduleDTO> GetAllSchedulesByRestoId(int id);
        List<ScheduleDTO> GetSchedulesByDayOfWeekAndRestoId(int id, DayOfWeek day);
    }
}
