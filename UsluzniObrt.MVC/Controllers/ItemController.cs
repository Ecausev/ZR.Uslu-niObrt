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
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        // GET: Item
        public ItemController()
        {

        }
        public ItemController(IItemService itemService, ICategoryService categoryService)
        {
            _itemService = itemService;
            _categoryService = categoryService;
        }
        [HttpGet]
        public ActionResult Index()
        {

            PopulateDropdownList();
            var model = new ItemsViewModel();
            model.Items = _itemService.GetAll();
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
            _itemService.Add(new ItemCreate
            {
                CategoryId = model.CategoryId,
                Naziv = model.Naziv,
                Cijena = model.Cijena
            });

            return RedirectToAction("Index", "Order");

        }

        private void PopulateDropdownList()
        {

            ViewBag.CategoryList = _categoryService.GetAll().ToList();


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