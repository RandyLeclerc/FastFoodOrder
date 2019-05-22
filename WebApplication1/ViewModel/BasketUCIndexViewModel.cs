using BLL.ShoppingService;
using Shared.BTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModel
{
    public class BasketUCIndexViewModel
    {
        public BasketUC basketUC { get; set; }
        public int restoId { get; set; }
        public string ReturnUrl { get; set; }
    }
}
