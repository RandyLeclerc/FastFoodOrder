using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataContracts
{
    public interface IBasketRepository : IRepository<BasketDTO>
    {
        IEnumerable<BasketDTO> GetBasketsByUserId(string UserId);
    }
}
