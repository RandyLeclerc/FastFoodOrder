using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Extensions;
using Microsoft.AspNetCore.Http;
using BLL.RestaurantService;
using BLL.ShoppingService;
using Microsoft.AspNetCore.Mvc;
using Shared.BTO;
using Shared.DataContracts;
using Newtonsoft.Json;
using WebApplication1.Infrastructure.Extensions;
using WebApplication1.ViewModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMealRepository mealRepository;
        private readonly IMealTypeRepository mealTypeRepository;
        private readonly IRestoRepository restoRepository;
        private readonly IEmailSender _emailSender;
        public MealUC mealUC;
        public MealTypeUC mealTypeUC;
        private List<ShoppingMealBTO> ShoppingMeals { get; set; }
        public BasketUC basketUC;

        public BasketController(IBasketRepository BasketRepository,
            IMealRepository MealRepository,
            IMealTypeRepository MealTypeRepository,
            IRestoRepository RestoRepository, IEmailSender emailSender)
        {
            basketRepository = BasketRepository;
            mealRepository = MealRepository;
            mealTypeRepository = MealTypeRepository;
            restoRepository = RestoRepository;
            _emailSender = emailSender;
            mealUC = new MealUC(mealRepository);
            mealTypeUC = new MealTypeUC(mealTypeRepository);
            basketUC = new BasketUC(basketRepository);
        }

        public IActionResult Index(string returnUrl, int RestoId)
        {
            var result = new BasketUCIndexViewModel
            {
                basketUC = GetBasketUC(),
                restoId = RestoId,
                ReturnUrl = returnUrl
            };
            return View(result);

        }

        public IActionResult Error(string errorMessage)
        {
            ViewData["Message"] = errorMessage;

            return View();
        }

        public PartialViewResult Summary(BasketBTO basket)
        {
            return PartialView(basket);
        }

        
        public IActionResult AddMealToBasket(int MealId, string returnUrl)
        {
            var mealBTO = mealUC.GetMealById(MealId);
            var restoId = mealUC.GetRestoIdByMealId(MealId);
            if (mealBTO != null)
            {
                /*BasketUC */
                basketUC = GetBasketUC();
                if (basketUC.restoId == 0)
                {
                    basketUC.restoId = restoId;
                }
                else if (basketUC.restoId != restoId)
                {
                    return RedirectToAction("Error", new { errorMessage = "Sorry, your can order only in one restaurant at the same time. Please clear your basket first" });
                }
                basketUC.AddMealToBasket(mealBTO, 1);
                SaveBasket(basketUC);
            }
            return Redirect(returnUrl);

        }

        private void SaveBasket(BasketUC basketUC)
        {
            HttpContext.Session.SetJson("BasketUC", basketUC);
        }
        [HttpPost]
        public IActionResult RemoveMealFromBasket(int MealId)
        {
            var mealBTO = mealUC.GetMealById(MealId);
            int idResto = mealUC.GetRestoIdByMealId(MealId);
            if (mealBTO != null)
            {
                basketUC = GetBasketUC();
                basketUC.RemoveMeal(mealBTO);
                if (basketUC.shoppingMeals.Count == 0)
                {
                    basketUC.restoId = 0;
                    SaveBasket(basketUC);

                    return RedirectToAction("GetAllRestaurants", "Restaurant");

                }
                else SaveBasket(basketUC);
            }

            return RedirectToAction("RestaurantDetails", "Restaurant", new { id = idResto });
        }

        //[Authorize]
        [HttpPost]
        public IActionResult CreateBasket(DateTime arrivalDate)
        {
            basketUC = GetBasketUC();


            if (basketUC.shoppingMeals.Count() == 0)
            {
                return RedirectToAction("Error", new { errorMessage = "Sorry, your basket is empty..." });
            }
            if (!ModelState.IsValid) return View(basketUC);
            var basketBTO = new BasketBTO();
            basketBTO.ArrivalDate = arrivalDate;

            RestaurantUC restoUC = new RestaurantUC(restoRepository);
            basketBTO.ShoppingMeals = basketUC.shoppingMeals
                .Select(x => x.ShoppingMealDomainToBTO())
                .ToList();

            basketBTO.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? null;

            if (basketBTO.UserId == null)
                return RedirectToAction("Error", new { errorMessage = "You have to be logged to complete your order" });

            if (!restoUC.IsOpen(basketUC.restoId, basketBTO.ArrivalDate))
            {
                return RedirectToAction("Error", new { errorMessage = "The restaurant will be closed at this hour" });
            }
            var result = basketUC.AddBasket(basketBTO);
            basketUC.ClearShoppingMeals();
            if (basketUC.shoppingMeals.Count == 0)
            {
                HttpContext.Session.Clear();
            }
            if (result == null)
            {
                return RedirectToAction("Error", new { errorMessage = "We can't add this basket, please contact support" });
            }
            string email = restoUC.FindRestoMailByRestoId(basketUC.restoId);
            if (!String.IsNullOrEmpty(email))
            {
                _emailSender.SendEmailAsync(email,
                            "You have a new order",
                            "See your orders by clicking here");
            }

            return View(result);
        }

        //[Authorize(Roles = "Administrators")]
        [HttpPost]
        public IActionResult DeleteBasket(int id)
        {
            var basket = GetBasketUC().GetBasketById(id);
            //int idToReturn = meal.MealTypeID;
            if (basket == null)
                return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find the basket with this Id" });
            else
            {
                try
                {
                    GetBasketUC().DeleteBasket(id);
                }
                catch
                {
                    throw new Exception("A problem occured...");
                }
                return View(basket);
            }
        }
        //[Authorize(Roles = "Administrators")]
        [HttpGet]
        public IActionResult EditBasket(int id)
        {
            var result = GetBasketUC().GetBasketById(id);
            if (result != null)
                return View(result);
            else
                return RedirectToAction("Error",
                    new { errorMessage = "Sorry! We don't find the meal with this Id" });
        }
        [HttpPost]
        public IActionResult EditBasket(BasketBTO basketBTO)
        {
            if (!ModelState.IsValid) return View(basketBTO);

            var result = GetBasketUC().UpdateBasket(basketBTO);

            if (result == null)
            {
                return RedirectToAction("Error", new { errorMessage = "We can't update this meal, please contact support" });
            }

            return View(result);
        }

        private BasketUC GetBasketUC()
        {
            basketUC = HttpContext.Session.GetJson<BasketUC>("BasketUC") ?? new BasketUC(basketRepository);
            var result = new BasketUC(basketRepository);
            result.restoId = basketUC.restoId;
            result.shoppingMeals = basketUC.shoppingMeals;
            result.ArrivalDate = basketUC.ArrivalDate;
           
            return result;
        }

        public IActionResult GetBasketsByUserId()
        {
            var result = basketUC.GetBasketsByUserId(User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList();
            RestaurantUC restoUC = new RestaurantUC(restoRepository);

            foreach (var item in result)
            {
                foreach (var shoppingMeal in item.ShoppingMeals)
                {
                    shoppingMeal.Meal.MealType = mealTypeUC.GetMealTypeById(shoppingMeal.Meal.MealTypeID);
                    shoppingMeal.Meal.MealType.Restaurant = restoUC.GetRestaurantById(shoppingMeal.Meal.MealType.RestaurantId);
                }
            }
            result = result.OrderBy(x => x.ArrivalDate).ToList();
            return View(result);
        }
        public IActionResult GetBasketsByRestoId(int restoId)
        {
            var result = basketUC.GetBasketsByRestoId(restoId).ToList();
            RestaurantUC restoUC = new RestaurantUC(restoRepository);

            foreach (var item in result)
            {
                foreach (var shoppingMeal in item.ShoppingMeals)
                {
                    shoppingMeal.Meal.MealType = mealTypeUC.GetMealTypeById(shoppingMeal.Meal.MealTypeID);
                    shoppingMeal.Meal.MealType.Restaurant = restoUC.GetRestaurantById(shoppingMeal.Meal.MealType.RestaurantId);
                }
            }
            return View(result.OrderBy(x => x.ArrivalDate).ToList());
        }
    }
}