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
            ViewBag.Table = id;
            return View(model);
        }

        public ActionResult Cart(int id, int table)
        {
            if (_orderService.CanPlaceOrder(table))
            {
                var item = _menuService.GetById(id);
                GetCart().AddItem(item, 1);
                GetCart().Table = table;
                return RedirectToAction("Checkout", "Order");
            }
            else
            {
                return RedirectToAction("MyOrder", "Order", new { Id = table });
            }
        }

        public ActionResult RemoveFromCart(int id)
        {
            var item = _menuService.GetById(id);
            GetCart().RemoveItem(item);
            return RedirectToAction("Checkout");
        }
        public ActionResult RemoveOneFromCart(int id)
        {
            var item = _menuService.GetById(id);
            GetCart().RemoveOne(item, 1);
            return RedirectToAction("Checkout");
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            var ItemList = _menuService.GetAll().ToList();
            return View(new CartViewModel {
                Cart = GetCart(),
                MenuItemList = ItemList,
            });
        }

        public ActionResult CreateOrder(CartViewModel model)
        {
            
            Cart cart = (Cart)Session["CartSession"];
            Order MyOrder = new Order();

            int table = cart.Table;
            var orderItems = new List<OrderItem>();
            foreach (var item in cart.OrderList)
            {

                orderItems.Add(new OrderItem
                {
                    MenuItemId = item.MenuItemId,
                    Quantity = item.Quantity
                });
            }


            var order = new Order
            {
                Date = DateTime.Now,
                TableNumber = table,
                Status = OrderStatus.Pending,
                Items = orderItems
            };

            _orderService.Add(order);
            Session.Remove("CartSession");
            return RedirectToAction("MyOrder","Order", new {Id = table });
        }
        /// <summary>
        /// 
        /// Stranica za pregled narudzbe lkvnmsklgskjgnvvn 
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MyOrder (int id)
        {
            Order myOrder = new Order();
            myOrder = _orderService.GetAll().Where(x => x.TableNumber == id && (x.Status == OrderStatus.InProgress || x.Status == OrderStatus.Pending)).FirstOrDefault();

            if (myOrder == null)
            {
                return RedirectToAction("Menu", new {Id = id });
            }
            return View(new OrdersViewModel {

                Order = myOrder,
                itemOrderList = myOrder.Items.ToList()

            });

        }
        private void PopulateDropdownList()
        {
            ViewBag.CategoryList = _categoryService.GetAll().ToList();

        }

        public Cart GetCart()
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
