using DAL.Data;
using DAL.Extensions;
using Shared.DataContracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Schedules
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ApplicationDbContext contextDB;

        public ScheduleRepository(ApplicationDbContext ContextDB)
        {
            contextDB = ContextDB;
        }
        public ScheduleDTO Create(ScheduleDTO obj)
        {
            var schedule = obj.DtoToSchedule();
            contextDB.Restaurants.First(x => x.Id == obj.Resto.Id);
            contextDB.Schedules.Add(schedule);
            contextDB.SaveChanges();
            return schedule.ScheduleToDTO();
        }

        public void Delete(int id)
        {
            var schedule = contextDB.Schedules.FirstOrDefault(x => x.Id == id);
            if (schedule == null)
                throw new Exception("There is no Schedule in this DB with this Id");
            else
            {
                contextDB.Schedules.Remove(schedule);
                contextDB.SaveChanges();
            }
        }

        public IEnumerable<ScheduleDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public ScheduleDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ScheduleDTO Update(ScheduleDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
