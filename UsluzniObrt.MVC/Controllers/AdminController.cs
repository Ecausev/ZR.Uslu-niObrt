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
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        public AdminController()
        {
        }
        public AdminController(IItemService itemService, ICategoryService categoryService)
        {
            _itemService = itemService;
            _categoryService = categoryService;
        }

        
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateItem()
        {
            PopulateDropdownList();
            return View();

        }

        private void PopulateDropdownList()
        {
            
            ViewBag.CategoryList = _categoryService.GetAll();
            

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateItem(ItemCreateViewModel model)
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


    }
}