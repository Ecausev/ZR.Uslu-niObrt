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
        [HttpGet]
        public ActionResult Index()
        {
            PopulateDropdownList();
            var model = new ItemsViewModel();
            model.Items = _menuService.GetAll();
            return View(model);
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

            return RedirectToAction("Index", "Admin");

        }

        [HttpGet]
        public ActionResult Modify(int id)
        {
            PopulateDropdownList();
            ViewBag.Item = _menuService.GetById(id);
            return View();
        }


        [HttpPost]
        public ActionResult Modify(ItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                PopulateDropdownList();
                return View();
            }

            var item = _menuService.GetById(model.Id);
            item.CategoryId = model.CategoryId;
            item.Name = model.Name;
            item.Price = model.Price;
            item.Description = model.Description;
            item.Status = model.Status;
            
            _menuService.edit(item);
            return RedirectToAction("Index");

        }

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