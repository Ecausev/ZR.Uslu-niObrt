using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsluzniObrt.Repository;
using UsluzniObrt.Model;
using UsluzniObrt.MVC.ViewModels;
using UsluzniObrt.Service;
using UsluzniObrt.Service.DTO;

namespace UsluzniObrt.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        // GET: Item
        public OrderController()
        {

        }
        public OrderController(
            IMenuService itemService, 
            ICategoryService categoryService, 
            IOrderService orderService )
        {
            _menuService = itemService;
            _categoryService = categoryService;
            _orderService = orderService;
        }

        
        [HttpGet]
        public ActionResult Menu(int id)
        {
            PopulateDropdownList();

            var model = new ItemsViewModel();
            model.Items = _menuService.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Cart(int id)
        {
            var item = _menuService.GetById(id);
            GetCart().AddItem(item, 1);
            return RedirectToAction("Checkout", "Order");
        }

        public ViewResult Checkout()
        {
            PopulateItems();
            return View(new CartViewModel {
                Cart = GetCart()
            });
        }


        
        //public ActionResult CreateOrder(CartIndexViewModel model)
        //{
        //    var orderItems = new List<OrderItem>();
        //    foreach (var orderItem in model.Cart.OrderList)
        //    {
        //        orderItems.Add(new OrderItem
        //        {
        //            MenuItemId = orderItem.Item.Id,
        //            Quantity = orderItem.Qty
        //        });
        //    }

        //    var order = new Order
        //    {
        //        Date = DateTime.Now,
        //        TableNumber = 1,
        //        Status = OrderStatus.Pending,
        //        Items = orderItems
        //    };

        //    _orderService.Add(order);

        //    var orderId = order.Id; //for test

        //    return View();
        //}

        public ActionResult RemoveFromCart(int id)
        {
            var item = _menuService.GetById(id);
            GetCart().RemoveItem(item);
            return RedirectToAction("Checkout", "Order");
        }
        public ActionResult RemoveOneFromCart(int id)
        {
            var item = _menuService.GetById(id);

            GetCart().RemoveOne(item, 1);
            return RedirectToAction("Checkout", "Order");
        }

        private void PopulateDropdownList()
        {
            ViewBag.CategoryList = _categoryService.GetAll().ToList();

        }

        private void PopulateItems()
        {
            ViewBag.ItemList = _menuService.GetAll().ToList();

        }
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["CartSession"];
            if (cart == null)
            {
                cart = new Cart();
                Session["CartSession"] = cart;
            }
            return cart;
        }

        
    }
}
