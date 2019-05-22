using Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RestaurantService
{
    public partial class RestaurantUC
    {
        private IRestoRepository restoRepository;

        public RestaurantUC(IRestoRepository RestoRepository) /*: base()*/
        {
            restoRepository = RestoRepository;
        }
    }
}
