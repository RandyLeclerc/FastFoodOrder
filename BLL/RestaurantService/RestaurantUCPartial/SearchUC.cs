using BLL.Extensions;
using BLL.RestaurantService.Domain;
using Shared.BTO;
using Shared.DataContracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class RestaurantUC
    {
        public IEnumerable<RestoBTO> FindRestaurantByCity(string city)
        {

            var restos = restoRepository.FindByCity(city); 

            return restos?.Select(x => x.DTOToDomain().ToBTO()) ?? new List<RestoBTO>();
        }
        public List<RestoBTO> FindOpenRestaurantsByDate(DateTime searchdate)
        {
            List<RestoDTO> result = new List<RestoDTO>();
            var restos = restoRepository.GetAll().ToList();

            foreach (var item in restos)
            {
                foreach (var schedule in item.Schedules)
                {
                    if(schedule.DayOfWeek == (int)searchdate.DayOfWeek)
                    {
                        if (searchdate.TimeOfDay >= schedule.TimeOpen.TimeOfDay && searchdate.TimeOfDay <= schedule.TimeClosed.TimeOfDay)
                        {
                            result.Add(item);
                        }
                    }
                }
            }
            return result?.Select(x => x.DTOToDomain().ToBTO()).ToList() ?? new List<RestoBTO>();
        }

        public IEnumerable<RestoBTO> GetAllRestaurants()
        {
            var restos = restoRepository.GetAll();

            return restos.Select(x => x.DTOToDomain().ToBTO());
        }

        public IEnumerable<RestoBTO> GetAllRestaurantsByCuisineId(int id)
        {
            var restos = restoRepository.GetAllByCuisineId(id);

            return restos?.Select(x => x.DTOToDomain().ToBTO()) ?? new List<RestoBTO>();
        }

        public RestoBTO GetRestaurantById(int id)
        {
            var resto = restoRepository.GetById(id);
            return resto.DTOToDomain().ToBTO();
        }

        public IEnumerable<RestoBTO> GetRestaurantsByRestaurantManager(string RestaurantManagerId)
        {
            if (string.IsNullOrEmpty(RestaurantManagerId))
                return new List<RestoBTO>();
            else
            {
                var restos = restoRepository.GetRestaurantsByRestaurantManager(RestaurantManagerId);

                return restos?.Select(x => x.DTOToDomain().ToBTO()) ?? new List<RestoBTO>();
            }

        }

        public bool IsOpen(int restoId, DateTime arrivalDate)
        {
            if (arrivalDate<DateTime.Now)
            {
                return false;
            }
            return restoRepository.RestaurantIsOpen(restoId, arrivalDate);
        }

        public string FindRestoMailByRestoId(int id)
        {
            string result = restoRepository.FindRestoMailByRestoId(id);
            return result;
        }
    }
}
