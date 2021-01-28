using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsluzniObrt.Model;
using UsluzniObrt.MVC.ViewModels;
using UsluzniObrt.Service;
using UsluzniObrt.Repository;

namespace UsluzniObrt.MVC.Controllers
{
    public class ItemController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly ICategoryService _categoryService;
        // GET: Item
        public ItemController()
        {

        }
        public ItemController(IMenuService menuService, ICategoryService categoryService)
        {
            _menuService = menuService;
            _categoryService = categoryService;
        }


        //[HttpGet]
        //public ActionResult Modify()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Modify()
        //{

        //    return View();

        //}

        //[HttpGet]
        //public ActionResult Remove()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Remove()
        //{



        //}

    }
}