using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsluzniObrt.Model;

namespace UsluzniObrt.MVC.ViewModels
{
    public class CartViewModel
    {
        public List<OrderItemList> itemOrderList = new List<OrderItemList>();

        public void AddItem(MenuItem item, int qty)
        {
            OrderItemList itemOnList = itemOrderList.Where(x => x.Item.Id == item.Id).FirstOrDefault();

            if (itemOnList == null)
            {
                itemOrderList.Add(new OrderItemList { Item = item, Quantity = qty });

            }
            else
            {
                itemOnList.Quantity += qty;
            }

        }
        public void RemoveItem(MenuItem item)
        {

            itemOrderList.RemoveAll(x => x.Item.Id == item.Id);

        }
        public void RemoveOne(MenuItem item, int qty)
        {
            OrderItemList itemOnList = itemOrderList.Where(x => x.Item.Id == item.Id).FirstOrDefault();

            if (itemOnList.Quantity == 1)
            {
                itemOrderList.RemoveAll(x => x.Item.Id == item.Id);
            }
            else
            {
                itemOnList.Quantity -= qty;
            }

        }
        public decimal Calculate()
        {
            return Convert.ToDecimal(itemOrderList.Sum(x => x.Item.Price * x.Quantity));
        }
        public void Clear()
        {
            itemOrderList.Clear();
        }

        public IEnumerable<OrderItemList> OrderList { get { return itemOrderList; } }
    }
    public class OrderItemList
    {
        public MenuItem Item { get; set; }
        public int Quantity { get; set; }
    }
}