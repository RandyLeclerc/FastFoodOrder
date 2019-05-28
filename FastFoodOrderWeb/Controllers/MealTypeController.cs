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
    public class MealTypeController : Controller
    {
        private readonly IMealTypeRepository mealTypeRepository;
        public MealTypeUC mealTypeUC;
        public MealTypeController(IMealTypeRepository MealTypeRepository)
        {
            mealTypeRepository = MealTypeRepository;
            mealTypeUC = new MealTypeUC(mealTypeRepository);
        }

        public IActionResult GetAllMealTypesByRestoId(int Id)
        {
            var result = mealTypeUC.GetAllMealTypesByRestaurantId(Id);

            ViewData["RestoId"] = Id;
            if (result != null || result.ToList().Count == 0) return View(result);
            else return RedirectToAction("Error", 
                new { errorMessage = "Sorry! There is any meal in our database" });
        }

        public IActionResult Error(string errorMessage)
        {
            ViewData["Message"] = errorMessage;

            return View();
        }

        public IActionResult GetMealTypeById(int id)
        {
            var result = mealTypeUC.GetMealTypeById(id);
            if (result != null) return View(result);
            else return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find this Meal Type" });
        }

        //[Authorize(Roles = "Administrators")]
        [HttpGet]
        public IActionResult CreateMealType(int Id)
        {
            MealTypeBTO result = new MealTypeBTO();
            result.Restaurant = new RestoBTO { Id = Id };
            return View(result);
        }
        //[Authorize(Roles = "RestaurantManager, Administrators")]
        [HttpPost]
        public IActionResult CreateMealType(MealTypeBTO mealTypeBTO)
        {
            int idToReturn = mealTypeBTO.Restaurant.Id;

            if (!ModelState.IsValid) return View(mealTypeBTO);
            var result = mealTypeUC.AddMealType(mealTypeBTO);

            if (result == null)
            {
                return RedirectToAction("Error", new { errorMessage = "We can't add this meal type, please contact support" });
            }
            return RedirectToAction("GetAllMealTypesByRestoId", new { Id = idToReturn });
        }

        //[Authorize(Roles = "Administrators")]
        [HttpPost]
        public IActionResult DeleteMealType(int id)
        {
            var mealType = mealTypeUC.GetMealTypeById(id);
            int idToReturn = mealType.RestaurantId;
            if (mealType == null)
                return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find the meal type with this Id" });
            else
            {
                try
                {
                    mealTypeUC.DeleteMealType(id);
                }
                catch
                {
                    throw new Exception("A problem occured...");
                }
                return RedirectToAction("GetAllMealTypesByRestoId", new { Id = idToReturn });
            }
        }

        //[Authorize(Roles = "Administrators")]
        [HttpGet]
        public IActionResult EditMealType(int id)
        {
            var result = mealTypeUC.GetMealTypeById(id);
            if (result != null)
                return View(result);
            else
                return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find the meal type with this Id" });
        }

        //[Authorize(Roles = "Administrators")]
        [HttpPost]
        public IActionResult EditMealType(MealTypeBTO mealTypeBTO)
        {
            if (!ModelState.IsValid) return View(mealTypeBTO);

            var result = mealTypeUC.UpdateMealType(mealTypeBTO);
            int idToReturn = result.RestaurantId;


            if (result == null)
            {
                return RedirectToAction("Error", new { errorMessage = "We can't update this meal type, please contact support" });
            }
            return RedirectToAction("GetAllMealTypesByRestoId", new { Id = idToReturn });
        }
    }
}