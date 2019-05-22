using BLL.Extensions;
using Shared.BTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class CuisineUC
    {
        public ICollection<CuisineBTO> GetAllCuisines()
        {
            var cuisines = cuisineRepository.GetAll().OrderBy(n => n.Name);
            var result = cuisines.Select(x => x.DTOToCuisineDomain().ToBTO()).ToList();
            return result;
        }

        public ICollection<CuisineBTO> GetAllCuisinesByRestaurantId(int id)
        {
            var cuisines = cuisineRepository.GetAll()
                .Select(x => x.DTOToCuisineDomain().ToBTO())
                .ToList();

            cuisines.ForEach(x => x.Selected = cuisineRepository.RestoHasCuisine(x.Id, id));

            return cuisines.OrderBy(x => x.Name).ToList();
        }

        public CuisineBTO GetCuisineById(int id)
        {
            var cuisine = cuisineRepository.GetById(id);
            return cuisine.DTOToCuisineDomain().ToBTO();
        }
    }
}
