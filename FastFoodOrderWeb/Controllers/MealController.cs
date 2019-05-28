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
    public class MealController : Controller
    {
        private readonly IMealRepository mealRepository;
        public MealUC mealUC;
        public MealController(IMealRepository MealRepository)
        {
            mealRepository = MealRepository;
            mealUC = new MealUC(mealRepository);
        }

        public IActionResult GetAllMealsByMealTypeId(int Id)
        {
            var result = mealUC.GetAllMealsByMealTypeId(Id);
            ViewData["MealTypeId"] = Id;
            if (result != null || result.ToList().Count == 0) return View(result);
            else return RedirectToAction("Error", 
                new { errorMessage = "Sorry! There is any meal in our database" });
        }

        public IActionResult Error(string errorMessage)
        {
            ViewData["Message"] = errorMessage;

            return View();
        }
        public IActionResult GetMealById(int id)
        {
            var result = mealUC.GetMealById(id);
            if (result != null) return View(result);
            else return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find this Meal" });
        }
        //[Authorize(Roles = "Administrators")]
        [HttpGet]
        public IActionResult CreateMeal(int Id)
        {
            MealBTO result = new MealBTO();
            result.MealType = new MealTypeBTO { Id = Id };
            return View(result);
        }
        //[Authorize(Roles = "RestaurantManager, Administrators")]
        [HttpPost]
        public IActionResult CreateMeal(MealBTO mealBTO)
        {
            int idToReturn = mealBTO.MealType.Id;

            if (!ModelState.IsValid) return View(mealBTO);
            var result = mealUC.AddMeal(mealBTO);

            if (result == null)
            {
                return RedirectToAction("Error", new { errorMessage = "We can't add this meal, please contact support" });
            }
            return RedirectToAction("GetAllMealsByMealTypeId", new { Id = idToReturn });
        }
        //[Authorize(Roles = "Administrators")]
        [HttpPost]
        public IActionResult DeleteMeal(int id)
        {
            var meal = mealUC.GetMealById(id);
            int idToReturn = meal.MealTypeID;
            if (meal == null)
                return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find the meal with this Id" });
            else
            {
                try
                {
                    mealUC.DeleteMeal(id);
                }
                catch
                {
                    throw new Exception("A problem occured...");
                }
                return RedirectToAction("GetAllMealsByMealTypeId", new { Id = idToReturn });
            }
        }
        //[Authorize(Roles = "Administrators")]
        [HttpGet]
        public IActionResult EditMeal(int id)
        {
            var result = mealUC.GetMealById(id);
            if (result != null)
                return View(result);
            else
                return RedirectToAction("Error", 
                    new { errorMessage = "Sorry! We don't find the meal with this Id" });
        }
        //[Authorize(Roles = "Administrators")]
        [HttpPost]
        public IActionResult EditMeal(MealBTO mealBTO)
        {
            if (!ModelState.IsValid) return View(mealBTO);

            var result = mealUC.UpdateMeal(mealBTO);
            int idToReturn = result.MealTypeID;

            if (result == null)
            {
                return RedirectToAction("Error", new { errorMessage = "We can't update this meal, please contact support" });
            }
            return RedirectToAction("GetAllMealsByMealTypeId", new { Id = idToReturn });
        }
    }
}