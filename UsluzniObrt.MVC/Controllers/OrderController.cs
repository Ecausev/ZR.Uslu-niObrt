﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsluzniObrt.Repository;
using UsluzniObrt.Model;
using UsluzniObrt.MVC.ViewModels;
using UsluzniObrt.Service;

namespace UsluzniObrt.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        private readonly IOfficeService _officeService;
        private readonly ITableService _tableService;
        private readonly IOrderItemService _orderItemService;
        // GET: Item
        public OrderController()
        {

        }
        public OrderController(
            IItemService itemService, 
            ICategoryService categoryService, 
            IOrderService orderService, 
            IOfficeService officeService, 
            ITableService tableService,
            IOrderItemService orderItemService)
        {
            _itemService = itemService;
            _categoryService = categoryService;
            _orderService = orderService;
            _officeService = officeService;
            _tableService = tableService;
            _orderItemService = orderItemService;
        }

        
        [HttpGet]
        public ActionResult Menu(int OfficeId, int TableId)
        {
            //PopulateViewBagOrder(OfficeId, TableId);
            PopulateDropdownList();
            var model = new ItemsViewModel();
            model.Items = _itemService.GetAll();
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult AddToCart(int id)
        {
            var item = _itemService.GetById(id);
            GetCart().AddItem(item, 1);
            return RedirectToAction("Checkout", "Order");
        }


        public ViewResult Checkout()
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart()
            });
        }

        [HttpGet]
        public ActionResult Tables(OrdersViewModel model)
        {
            PopulateDropdownList();
            return View(model);
        }

        public ActionResult RemoveFromCart( int id)
        {
            var item = _itemService.GetById(id);
            GetCart().RemoveItem(item);
            return RedirectToAction("Checkout", "Order");
        }

        private void PopulateDropdownList()
        {
            //ViewBag.TableList = _officeService.GetAll().ToList();
            ViewBag.CategoryList = _categoryService.GetAll().ToList();
            

        }
        private CartViewModel GetCart()
        {
            CartViewModel cart = (CartViewModel)Session["CartViewModel"];
            if (cart == null)
            {
                cart = new CartViewModel();
                Session["CartViewModel"] = cart;
            }
            return cart;
        }
        //private void PopulateViewBagOrder(int OfficeId, int TableId)
        //{
        //    ViewBag.TableId = OfficeId;
        //    ViewBag.OrderId = TableId;
        //}
        //public ActionResult CreateOrder(int officeId, int tableId, int itemId, int Qty)
        //{

        //    var newOrder = new Order
        //    {
        //        TableId = tableId
        //    };
        //    _orderService.Add(newOrder);

        //    var LastOrder = _orderService.GetAll().Last();

        //    var editOrder = new OrderItem
        //    {
        //        OrderId = LastOrder.OrderId,

        //        ItemId = itemId,
        //        Qty = Qty,
        //    };

        //    _orderItemService.Add(editOrder);

        //    var officeTable = new OfficeTable
        //    {
        //        OfficeId = officeId,
        //        TableId = tableId
        //    };
        //    _officeTableService.Add(officeTable);


        //    return RedirectToAction("Index");

        //}
        // If list.contains x
        // if last order with tableid = TableId && Order.status = "Active" - add cartorder to old else create new :S
        // oce ta logika ici u create dio ? mislim da hoce.
        // If Last Order contains item ID , qty =  qty + qty 







        //public ActionResult Buy(string id)
        //{
        //    ProductModel productModel = new ProductModel();
        //    if (Session["cart"] == null)
        //    {
        //        List<Item> cart = new List<Item>();
        //        cart.Add(new Item { Product = productModel.find(id), Quantity = 1 });
        //        Session["cart"] = cart;
        //    }
        //    else
        //    {
        //        List<Item> cart = (List<Item>)Session["cart"];
        //        int index = isExist(id);
        //        if (index != -1)
        //        {
        //            cart[index].Quantity++;
        //        }
        //        else
        //        {
        //            cart.Add(new Item { Product = productModel.find(id), Quantity = 1 });
        //        }
        //        Session["cart"] = cart;
        //    }
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Remove(string id)
        //{
        //    List<Item> cart = (List<Item>)Session["cart"];
        //    int index = isExist(id);
        //    cart.RemoveAt(index);
        //    Session["cart"] = cart;
        //    return RedirectToAction("Index");
        //}

        //private int isExist(string id)
        //{
        //    List<Item> cart = (List<Item>)Session["cart"];
        //    for (int i = 0; i < cart.Count; i++)
        //        if (cart[i].Product.Id.Equals(id))
        //            return i;
        //    return -1;
        //}
    }
}
