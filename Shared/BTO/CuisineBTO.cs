using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.BTO
{
    public class CuisineBTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Selected { get; set; }
        public List<RestoBTO> Restaurants { get; set; }

    }
}
