using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsluzniObrt.Model;

namespace UsluzniObrt.MVC.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public MenuItemStatus Status { get; set; }
        public int CategoryId { get; set; }
    }
}