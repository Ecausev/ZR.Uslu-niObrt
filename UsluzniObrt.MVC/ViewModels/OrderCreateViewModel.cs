using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsluzniObrt.MVC.ViewModels
{
    public class OrderCreateViewModel
    {
        public int OrderID { get; set; }

        public int MenuItemId { get; set; }

        public int Quantity { get; set; }

    }
}