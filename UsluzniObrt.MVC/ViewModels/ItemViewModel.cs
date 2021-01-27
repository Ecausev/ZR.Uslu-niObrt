using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsluzniObrt.MVC.ViewModels
{
    public class ItemViewModel
    {
        public int ItemId { get; set; }
        public string Naziv { get; set; }
        public int Cijena { get; set; }
        public int CategoryId { get; set; }
    }
}