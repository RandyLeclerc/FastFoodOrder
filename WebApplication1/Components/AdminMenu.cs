using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Components
{
    public class AdminMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = new List<AdminMenuItem> { new AdminMenuItem()
                {
                    DisplayValue = "User management",
                    ActionValue = "UserManagement"

                },
                new AdminMenuItem()
                {
                    DisplayValue = "Role management",
                    ActionValue = "RoleManagement"
                },
                new AdminMenuItem()
                {
                    DisplayValue="Cuisine management",
                    ActionValue = "GetAllCuisines"
                },
                new AdminMenuItem()
                {
                    DisplayValue="Picture management",
                    ActionValue = "GetAllPictures"
                },
                new AdminMenuItem()
                {
                    DisplayValue="Restaurant management",
                    ActionValue = "GetAllRestaurantsAdmin"
                }
            };

            return View(menuItems);
        }
    }
}
