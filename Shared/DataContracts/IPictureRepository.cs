using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataContracts
{
    public interface IPictureRepository : IRepository<PictureDTO>
    {
        List<PictureDTO> GetPicturesByRestoId(int id);
        PictureDTO GetProfilePictureByRestoId(int id);
    }
}
