using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.RestaurantService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.BTO;
using Shared.DataContracts;

namespace WebApplication1.Controllers
{
    public class CuisineController : Controller
    {
        private ICuisineRepository cuisineRepository;
        public CuisineUC cuisineUC;
        public CuisineController(ICuisineRepository CuisineRepository)
        {
            cuisineRepository = CuisineRepository;
            cuisineUC = new CuisineUC(cuisineRepository);
        }

        public IActionResult GetAllCuisines()
        {
            var result = cuisineUC.GetAllCuisines();
            if (result != null || result.ToList().Count == 0) return View(result);
            else return RedirectToAction("Error", new { errorMessage = "Sorry! There is any cuisine in our database" });
 
        }
        public IActionResult GetCuisineById(int id)
        {
            var result = cuisineUC.GetCuisineById(id);
            if (result != null) return View(result);
            else return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find this cuisine" });
        }
        public IActionResult Error(string errorMessage)
        {
            ViewData["Message"] = errorMessage;

            return View();
        }
        [Authorize(Roles = "Administrators")]
        [HttpGet]
        public IActionResult CreateCuisine()
        {
            return View();
        }

        [Authorize(Roles = "RestaurantManager, Administrators")]
        [HttpPost]
        public IActionResult CreateCuisine(CuisineBTO cuisineBTO)
        {
            if (!ModelState.IsValid) return View(cuisineBTO);
            var result = cuisineUC.AddCuisine(cuisineBTO);

            if (result == null)
            {
                return RedirectToAction("Error", new { errorMessage = "We can't add this cuisine, please contact support" });
            }
            return RedirectToAction("GetAllCuisines");
        }

        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public IActionResult DeleteCuisine(int id)
        {
            var cuisine = cuisineUC.GetCuisineById(id);
            if (cuisine == null)
                return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find the cuisine with this Id" });
            else
            {
                try
                {
                    cuisineUC.DeleteCuisine(id);
                }
                catch
                {
                    throw new Exception("A problem occured...");
                }
                return RedirectToAction("GetAllCuisines");
            }
        }

        [Authorize(Roles = "Administrators")]
        [HttpGet]
        public IActionResult EditCuisine(int id)
        {
            var result = cuisineUC.GetCuisineById(id);
            if (result != null)
                return View(result);
            else
                return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find the cuisine with this Id" });
        }


        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public IActionResult EditCuisine(CuisineBTO cuisineBTO)
        {
            if (!ModelState.IsValid) return View(cuisineBTO);

            var result = cuisineUC.UpdateCuisine(cuisineBTO);

            if (result == null)
            {
                return RedirectToAction("Error", new { errorMessage = "We can't update this cuisine, please contact support" });
            }

            return RedirectToAction("GetAllCuisines");
        }
    }
}