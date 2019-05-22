using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.RestaurantService;
using BLL.RestaurantService.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared.BTO;
using Shared.DataContracts;

namespace WebApplication1.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestoRepository restoRepository;
        private ICuisineRepository cuisineRepository;
        private IPictureRepository pictureRepository;
        public CuisineUC cuisineUC;
        public PictureUC pictureUC;


        public RestaurantController(IRestoRepository RestoRepository, ICuisineRepository CuisineRepository, IPictureRepository PictureRepository)
        {
            restoRepository = RestoRepository;
            cuisineRepository = CuisineRepository;
            pictureRepository = PictureRepository;
            cuisineUC = new CuisineUC(cuisineRepository);
            pictureUC = new PictureUC(pictureRepository);
        }

        //https://localhost:44397/Restaurant/GetAllRestaurants
        public IActionResult GetAllRestaurants()
        {
            var restaurantUC = new RestaurantUC(restoRepository);
            var result = restaurantUC.GetAllRestaurants();
            //????
            
            if (result != null || result.ToList().Count == 0) return View(result);
            else
            {
                ModelState.AddModelError("", "Sorry! There is any restaurant in our database");
            }
            return RedirectToAction("GetAllRestaurants");

        }

        [Authorize(Roles = "Administrators")]

        public IActionResult GetAllRestaurantsAdmin()
        {
            var restaurantUC = new RestaurantUC(restoRepository);
            var result = restaurantUC.GetAllRestaurants();
            if (result != null || result.ToList().Count == 0) return View(result);
            else
            {
                return RedirectToAction("", "Sorry! There is any restaurant in our database");
            }
        }

        public IActionResult RestaurantDetails(int id)
        {
            var restaurantUC = new RestaurantUC(restoRepository);
            var result = restaurantUC.GetRestaurantById(id);
            //result.Basket = basketBTO;
            if (result != null) return View(result);
            else return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find this restaurant" });

        }
        //Get restaurant by city
        //https://localhost:44397/Restaurant/GetRestaurantByCity/?city=Bruxelles
        public IActionResult GetRestaurantByCity(string city)
        {
            var restaurantUC = new RestaurantUC(restoRepository);
            var result = restaurantUC.FindRestaurantByCity(city);
            if (result.ToList().Count != 0) return View(result);
            else
            //{
            //    ModelState.AddModelError("", "Sorry! We don't find any restaurant with this city you asked");
            //}
            return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find any restaurant with this city you asked" });
        }
        public IActionResult Error(string errorMessage)
        {
            ViewData["Message"] = errorMessage;

            return View();
        }

        [Authorize(Roles = "RestaurantManager, Administrators")]
        [HttpGet]
        public IActionResult CreateRestaurant()
        {
            var restoBTO = new RestoBTO();
            restoBTO.Cuisines = cuisineUC.GetAllCuisines().ToList();
            restoBTO.Pictures = new List<PictureBTO>().DefaultIfEmpty().ToList();
            restoBTO.MealTypes = new List<MealTypeBTO>().DefaultIfEmpty().ToList();
            restoBTO.MealTypes.Add(new MealTypeBTO { Name = "test" });
            return View(restoBTO);
        }


        [Authorize(Roles = "RestaurantManager, Administrators")]
        [HttpPost]
        public IActionResult CreateRestaurant(RestoBTO restoBTO)
        {
            var count = restoBTO.Cuisines.Count(x => x.Selected);
            if (!ModelState.IsValid) return View(restoBTO);
            restoBTO.Cuisines = restoBTO.Cuisines.Where(x => x.Selected).ToList();

            var restaurantUC = new RestaurantUC(restoRepository);

            if (restoBTO.UserManagerId == null)
            {
                restoBTO.UserManagerId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            var result = restaurantUC.AddRestaurant(restoBTO);

            if (result == null)
            {
                return RedirectToAction("Error", new { errorMessage = "We can't add this restaurant, please contact support" });
            }

            if (User.IsInRole("Administrators"))
            {
                return RedirectToAction("GetAllRestaurantsAdmin");
            }
            else
                return RedirectToAction("GetRestaurantsByRestaurantManager");
        }

        public IActionResult GetRestaurantsByRestaurantManager()
        {
            var restaurantUC = new RestaurantUC(restoRepository);
            var result = restaurantUC.GetRestaurantsByRestaurantManager(User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList();
            if (result.ToList().Count != 0) return View(result);
            else
                return RedirectToAction("Error", new { errorMessage = "Sorry! You don't have any restaurant" });
        }

        [Authorize(Roles = "RestaurantManager, Administrators")]
        [HttpGet]
        public IActionResult EditRestaurant(int id)
        {
            var restaurantUC = new RestaurantUC(restoRepository);
            var result = restaurantUC.GetRestaurantById(id);
            if (result.Pictures.Count == 0)
                result.Pictures = new List<PictureBTO>().DefaultIfEmpty().ToList();
            result.Cuisines = cuisineUC.GetAllCuisinesByRestaurantId(result.Id).ToList();
            
            //var cuisinesChecked = 
            if (result != null)
                return View(result);
            else
                return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find the restaurant with this Id" });
        }

        [Authorize(Roles = "RestaurantManager, Administrators")]
        [HttpPost]
        public IActionResult EditRestaurant(RestoBTO restoBTO)
        {
            if (!ModelState.IsValid) return View(restoBTO);
            restoBTO.Cuisines = restoBTO.Cuisines.Where(x => x.Selected).ToList();
            restoBTO.Pictures = pictureUC.GetAllPicturesByRestaurantId(restoBTO.Id).ToList();


            var restaurantUC = new RestaurantUC(restoRepository);
            var result = restaurantUC.UpdateRestaurant(restoBTO);

            if (result == null)
            {
                return RedirectToAction("Error", new { errorMessage = "We can't update this restaurant, please contact support" });
            }
            if (User.IsInRole("Administrators"))
            {
                return RedirectToAction("GetAllRestaurantsAdmin");
            }
            else
                return RedirectToAction("GetRestaurantsByRestaurantManager");
        }

        [Authorize(Roles = "RestaurantManager, Administrators")]
        [HttpPost]
        public IActionResult DeleteRestaurant(int id)
        {
            var restaurantUC = new RestaurantUC(restoRepository);
            var resto = restaurantUC.GetRestaurantById(id);
            if (resto==null)
                return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find the restaurant with this Id" });
            else
            {
                //var restaurantUC = new RestaurantUC(restoRepository);
                try
                {
                    restaurantUC.DeleteRestaurant(id);
                }
                catch
                {
                    throw new Exception("A problem occured...");
                }
                if (User.IsInRole("Administrators"))
                {
                    return RedirectToAction("GetAllRestaurantsAdmin");
                }
                else
                {
                    return RedirectToAction("GetRestaurantsByRestaurantManager");
                }
            }
        }


    }
}
 
 