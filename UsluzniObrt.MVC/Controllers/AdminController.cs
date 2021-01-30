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

    public class AdminController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly ICategoryService _categoryService;
        public AdminController()
        {
        }
        public AdminController(IMenuService menuService, ICategoryService categoryService)
        {
            _menuService = menuService;
            _categoryService = categoryService;
        }


        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            PopulateDropdownList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ItemCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                PopulateDropdownList();
                return View(model);
            }
            _menuService.Add(new MenuItem
            {
                CategoryId = model.CategoryId,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Status = model.Status
            });

            return RedirectToAction("Create", "Admin");

        }
        //Ovdje ide logika za populate dropdownlist of items
        //[HttpGet]
        //public ActionResult Modify()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult Modify(int )
        //{

        //    return View();

        //}

        [HttpGet]
        public ActionResult Remove()
        {
            return View();
        }

        private void PopulateDropdownList()
        {
            ViewBag.CategoryList = _categoryService.GetAll().ToList();
        }
    }
}