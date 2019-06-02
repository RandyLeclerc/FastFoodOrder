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
    public class PictureController : Controller
    {
        private readonly IPictureRepository pictureRepository;
        public PictureUC pictureUC;
        public PictureController(IPictureRepository PictureRepository)
        {
            pictureRepository = PictureRepository;
            pictureUC = new PictureUC(pictureRepository);
        }

        public IActionResult GetAllPictures()
        {
            var result = pictureUC.GetAllPictures();
            if (result != null || result.ToList().Count == 0) return View(result);
            else return RedirectToAction("Error", new { errorMessage = "Sorry! There is any picture in our database" });

        }

        public IActionResult GetAllPicturesByRestoId(int Id)
        {
            var result = pictureUC.GetAllPicturesByRestaurantId(Id);

            ViewData["RestoId"] = Id;
            if (result != null || result.ToList().Count == 0) return View(result);
            else return RedirectToAction("Error", new { errorMessage = "Sorry! There is any picture in our database" });
        }

        public IActionResult GetPictureById(int id)
        {
            var result = pictureUC.GetPictureById(id);
            if (result != null) return View(result);
            else return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find this picture" });
        }

        public IActionResult Error(string errorMessage)
        {
            ViewData["Message"] = errorMessage;

            return View();
        }
        //[Authorize(Roles = "Administrators")]
        [HttpGet]
        public IActionResult CreatePicture(int Id)
        {
            PictureBTO  result = new PictureBTO();
            result.Resto = new RestoBTO { Id = Id };
            return View(result);
        }

        //[Authorize(Roles = "RestaurantManager, Administrators")]
        [HttpPost]
        public IActionResult CreatePicture(PictureBTO pictureBTO)
        {
            int idToReturn = pictureBTO.Resto.Id;

            
            if (!ModelState.IsValid) return View(pictureBTO);

            //Check if there is already a profile picture for this restaurant
            if (pictureBTO.IsProfilePicture)
            {
                var profilePicture = pictureUC.GetProfilePicture(pictureBTO.Resto.Id);
                if (profilePicture != null)
                {
                    ViewData["Error"] = "You can't do that : You already have a profile picture for your restaurant";
                    return View(pictureBTO);
                }
            }


            var result = pictureUC.AddPicture(pictureBTO);

            if (result == null)
            {
                return RedirectToAction("Error", new { errorMessage = "We can't add this picture, please contact support" });
            }
            return RedirectToAction("GetAllPicturesByRestoId", new { Id = idToReturn });
        }

        //[Authorize(Roles = "Administrators")]
        [HttpPost]
        public IActionResult DeletePicture(int id)
        {
            var picture = pictureUC.GetPictureById(id);
            int idToReturn = picture.RestaurantId;
            if (picture == null)
                return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find the picture with this Id" });
            else
            {
                try
                {
                    pictureUC.DeletePicture(id);
                }
                catch
                {
                    throw new Exception("A problem occured...");
                }
                return RedirectToAction("GetAllPicturesByRestoId", new { Id = idToReturn });
            }
        }

        //[Authorize(Roles = "Administrators")]
        [HttpGet]
        public IActionResult EditPicture(int id)
        {
            var result = pictureUC.GetPictureById(id);
            if (result != null)
                return View(result);
            else
                return RedirectToAction("Error", new { errorMessage = "Sorry! We don't find the picture with this Id" });
        }

        //[Authorize(Roles = "Administrators")]
        [HttpPost]
        public IActionResult EditPicture(PictureBTO pictureBto)
        {
            int idToReturn = pictureBto.RestaurantId;

            //Check if there is already a profile picture for this restaurant
            if (!ModelState.IsValid) return View(pictureBto);
            if (pictureBto.IsProfilePicture)
            {
                var profilePicture = pictureUC.GetProfilePicture(pictureBto.RestaurantId);
                if (profilePicture != null)
                {
                    ViewData["Error"] = "You can't do that : You already have a profile picture for your restaurant";
                    return View(pictureBto);
                }
            }

            var result = pictureUC.UpdatePicture(pictureBto);

            if (result == null)
            {
                return RedirectToAction("Error", new { errorMessage = "We can't update this picture, please contact support" });
            }
            if (User.IsInRole("Administrators"))
            {
                return RedirectToAction("GetAllPictures");
            }
            else
                return RedirectToAction("GetAllPicturesByRestoId", new { Id = idToReturn });
        }
    }
}