using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.RestaurantService;
using Microsoft.AspNetCore.Mvc;
using Shared.BTO;
using Shared.DataContracts;

namespace WebApplication1.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleRepository scheduleRepository;
        public ScheduleUC scheduleUC;
        public ScheduleController(IScheduleRepository ScheduleRepository)
        {
            scheduleRepository = ScheduleRepository;
            scheduleUC = new ScheduleUC(scheduleRepository);
        }
        public IActionResult GetAllSchedulesByRestoId(int Id)
        {
            var result = scheduleUC.GetAllSchedulesByRestaurantId(Id);
            ViewData["RestoId"] = Id;
            if (result != null || result.ToList().Count == 0) return View(result);
            else return RedirectToAction("Error", new { errorMessage = "Sorry! There is any schedule in our database" });
        }
        public IActionResult GetScheduleById(int id)
        {
            var result = scheduleUC.GetScheduleById(id);
            if (result != null) return View(result);
            else return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find this schedule" });
        }
        public IActionResult Error(string errorMessage)
        {
            ViewData["Message"] = errorMessage;

            return View();
        }
        //[Authorize(Roles = "Administrators")]
        [HttpGet]
        public IActionResult CreateSchedule(int Id)
        {
            ScheduleBTO result = new ScheduleBTO();
            result.Resto = new RestoBTO { Id = Id };
            return View(result);
        }
        //[Authorize(Roles = "RestaurantManager, Administrators")]
        [HttpPost]
        public IActionResult CreateSchedule(ScheduleBTO scheduleBTO)
        {
            int idToReturn = scheduleBTO.Resto.Id;


            if (!ModelState.IsValid) return View(scheduleBTO);

            if (scheduleBTO.TimeClosed.TimeOfDay <= scheduleBTO.TimeOpen.TimeOfDay)
            {
                ViewData["Error"] = "You can't do that : TimeClosed must be superior to TimeOpen";
                return View(scheduleBTO);
            }

            var result = scheduleUC.AddSchedule(scheduleBTO);

            if (result == null)
            {
                return RedirectToAction("Error", new { errorMessage = "We can't add this schedule, please contact support" });
            }
            return RedirectToAction("GetAllSchedulesByRestoId", new { Id = idToReturn });
        }

        [HttpPost]
        public IActionResult DeleteSchedule(int id)
        {
            var schedule = scheduleUC.GetScheduleById(id);
            int idToReturn = schedule.RestoId;
            if (schedule == null)
                return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find the schedule with this Id" });
            else
            {
                try
                {
                    scheduleUC.DeleteSchedule(id);
                }
                catch
                {
                    throw new Exception("A problem occured...");
                }
                return RedirectToAction("GetAllSchedulesByRestoId", new { Id = idToReturn });
            }
        }
        //[Authorize(Roles = "Administrators")]
        [HttpGet]
        public IActionResult EditSchedule(int id)
        {
            var result = scheduleUC.GetScheduleById(id);
            if (result != null)
                return View(result);
            else
                return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find the schedule with this Id" });
        }
        [HttpPost]
        public IActionResult EditSchedule(ScheduleBTO scheduleBto)
        {
            int idToReturn = scheduleBto.RestoId;
            if (!ModelState.IsValid) return View(scheduleBto);

            if (scheduleBto.TimeClosed.TimeOfDay <= scheduleBto.TimeOpen.TimeOfDay)
            {
                ViewData["Error"] = "You can't do that : TimeClosed must be superior to TimeOpen";
                return View(scheduleBto);
            }


            var result = scheduleUC.UpdateSchedule(scheduleBto);



            if (result == null)
            {
                return RedirectToAction("Error", new { errorMessage = "We can't update this schedule, please contact support" });
            }
            if (User.IsInRole("Administrators"))
            {
                return RedirectToAction("GetAllSchedules");
            }
            else
                return RedirectToAction("GetAllSchedulesByRestoId", new { Id = idToReturn });
        }
    }
}