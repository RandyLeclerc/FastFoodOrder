using BLL.RestaurantService.Domain;
using Shared.BTO;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Extensions
{
    public static class ScheduleDomainExtensions
    {
        public static ScheduleDTO ScheduleDomainToDTO(this ScheduleDomain Domain)
        {
            if (Domain != null)
                return new ScheduleDTO
                {
                    Id = Domain.Id,
                    RestoId = Domain.RestoId,
                    DayOfWeek = Domain.DayOfWeek,
                    TimeOpen = Domain.TimeOpen,
                    TimeClosed = Domain.TimeClosed,
                    Resto = Domain.Resto.ToDTO()
                };
            else return null;
        }

        public static ScheduleDomain DTOToScheduleDomain(this ScheduleDTO scheduleDto)
        {
            if (scheduleDto != null)
                return new ScheduleDomain
                {
                    Id = scheduleDto.Id,
                    RestoId = scheduleDto.RestoId,
                    DayOfWeek = scheduleDto.DayOfWeek,
                    TimeOpen = scheduleDto.TimeOpen,
                    TimeClosed = scheduleDto.TimeClosed,
                    Resto = scheduleDto.Resto.DTOToDomain()
                };
            else return null;
        }
        public static ScheduleBTO ScheduleToBTO(this ScheduleDomain Domain)
        {
            if (Domain != null)
                return new ScheduleBTO
                {
                    Id = Domain.Id,
                    RestoId = Domain.RestoId,
                    DayOfWeek = Domain.DayOfWeek,
                    TimeOpen = Domain.TimeOpen,
                    TimeClosed = Domain.TimeClosed,
                    Resto = Domain.Resto.ToBTO()
                };
            else return null;
        }
        public static ScheduleDomain BTOToScheduleDomain(this ScheduleBTO scheduleBto)
        {
            if (scheduleBto != null)
                return new ScheduleDomain
                {
                    Id = scheduleBto.Id,
                    RestoId = scheduleBto.RestoId,
                    DayOfWeek = scheduleBto.DayOfWeek,
                    TimeOpen = scheduleBto.TimeOpen,
                    TimeClosed = scheduleBto.TimeClosed,
                    Resto = scheduleBto.Resto.BTOToDomain()
                };
            else return null;
        }
    }
}
