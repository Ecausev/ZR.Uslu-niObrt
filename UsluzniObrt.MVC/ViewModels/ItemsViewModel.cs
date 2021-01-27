using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsluzniObrt.Model;

namespace UsluzniObrt.MVC.ViewModels
{
    public class ItemsViewModel : ItemViewModel
    {
        public List<Item> Items { get; set; }
    }
}