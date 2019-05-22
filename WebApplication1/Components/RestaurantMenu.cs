using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Components
{
    public class RestaurantMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = new List<AdminMenuItem> {
                new AdminMenuItem()
                {
                    DisplayValue = "Add a new Restaurant",
                    ActionValue = "CreateRestaurant"
                },
                new AdminMenuItem()
                {
                    DisplayValue = "See my restaurants",
                    ActionValue = "GetRestaurantsByRestaurantManager"
                },
            };

            return View(menuItems);
        }
    }
}
