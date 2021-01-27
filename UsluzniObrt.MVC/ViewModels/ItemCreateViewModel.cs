using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsluzniObrt.MVC.ViewModels
{
    public class ItemCreateViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Naziv { get; set; }
        [Required]
        public int Cijena { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}