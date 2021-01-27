using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsluzniObrt.MVC.ViewModels
{
    public class OrderCreateViewModel
    {
        public int OrderID { get; set; }

        public int ProizID { get; set; }

        public int Qty { get; set; }

    }
}