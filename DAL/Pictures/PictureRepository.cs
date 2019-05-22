using DAL.Data;
using DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.DataContracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Pictures
{
    public class PictureRepository : IPictureRepository
    {
        private readonly ApplicationDbContext contextDB;
        public PictureRepository(ApplicationDbContext ContextDB)
        {
            contextDB = ContextDB;
        }

        public PictureDTO Create(PictureDTO obj)
        {
            var picture = obj.DtoToPicture();
            contextDB.Restaurants.First(x => x.Id == obj.Resto.Id);
            contextDB.Pictures.Add(picture);
            contextDB.SaveChanges();
            return picture.PictureToDTO();
        }

        public void Delete(int id)
        {
            var picture = contextDB.Pictures.FirstOrDefault(x => x.Id == id);
            if (picture == null)
                throw new Exception("There is no Picture in this DB with this Id");
            else
            {
                contextDB.Pictures.Remove(picture);
                contextDB.SaveChanges();
            }
        }

        public IEnumerable<PictureDTO> GetAll()
        {
            return contextDB.Pictures
                //.Include(x => x.Restaurant)
                //.ThenInclude(y => y.Cuisine)
                .Select(x => x.PictureToDTO());
        }

        public PictureDTO GetById(int id)
        {
            return contextDB.Pictures
                .Include(x=>x.Restaurant)
                //.Include(x => x.UserManager)
                //.Include(x => x.RestaurantCuisines)
                //.ThenInclude(y => y.Cuisine)
                .FirstOrDefault(x => x.Id == id).PictureToDTO();
        }

        public List<PictureDTO> GetPicturesByRestoId(int id)
        {
            return contextDB.Pictures
                .Where(x => x.Restaurant.Id == id)
                .Select(x=>x.PictureToDTO())
                .ToList();
        }

        public PictureDTO GetProfilePictureByRestoId(int id)
        {
            var picture = GetPicturesByRestoId(id).FirstOrDefault(x => x.IsProfilePicture);
            return picture;
        }

        public PictureDTO Update(PictureDTO obj)
        {
            var picture = contextDB.Pictures.FirstOrDefault(x => x.Id == obj.Id);
            if (picture == null)
                return null;
            else
            {
                picture.Url = obj.Url;
                picture.Restaurant = obj.Resto.ToRestaurant();
                picture.IsProfilePicture = obj.IsProfilePicture;
                contextDB.SaveChanges();
                return picture.PictureToDTO();
            }
        }
    }
}
