using DAL.Data;
using DAL.Extensions;
using Microsoft.EntityFrameworkCore;
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

        public List<ScheduleDTO> GetAllSchedulesByRestoId(int id)
        {
            return contextDB.Schedules
                .Where(x => x.Resto.Id == id)
                .Select(x => x.ScheduleToDTO())
                .ToList();
        }

        public ScheduleDTO GetById(int id)
        {
            return contextDB.Schedules
                .Include(x => x.Resto)
                .FirstOrDefault(x => x.Id == id).ScheduleToDTO();
        }

        public List<ScheduleDTO> GetSchedulesByDayOfWeekAndRestoId(int id, DayOfWeek day)
        {
            return contextDB.Schedules
                .Where(x => x.Resto.Id == id && x.DayOfWeek == (int)day)
                .Select(x => x.ScheduleToDTO())
                .ToList();
        }

        public ScheduleDTO Update(ScheduleDTO obj)
        {
            var schedule = contextDB.Schedules.FirstOrDefault(x => x.Id == obj.Id);
            if (schedule == null)
                return null;
            else
            {
                schedule.Resto = obj.Resto.ToRestaurant();
                schedule.TimeOpen = obj.TimeOpen;
                schedule.TimeClosed = obj.TimeClosed;
                schedule.DayOfWeek = obj.DayOfWeek;
                contextDB.SaveChanges();
                return schedule.ScheduleToDTO();
            }
        }
    }
}
