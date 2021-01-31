using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsluzniObrt.Model;

namespace UsluzniObrt.MVC.ViewModels
{
    public class CartViewModel
    {
        public List<ItemOrderList> itemOrderList = new List<ItemOrderList>();

        public void AddItem(MenuItem item, int qty)
        {
            ItemOrderList itemOnList = itemOrderList.Where(x => x.Item.Id == item.Id).FirstOrDefault();

            if (itemOnList == null)
            {
                itemOrderList.Add(new ItemOrderList { Item = item, Qty = qty });

            }
            else
            {
                itemOnList.Qty += qty;
            }

        }
        public void RemoveItem(MenuItem item)
        {

            itemOrderList.RemoveAll(x => x.Item.Id == item.Id);

        }
        public void RemoveOne(MenuItem item, int qty)
        {
            ItemOrderList itemOnList = itemOrderList.Where(x => x.Item.Id == item.Id).FirstOrDefault();

            if (itemOnList.Qty == 1)
            {
                itemOrderList.RemoveAll(x => x.Item.Id == item.Id);
            }
            else
            {
                itemOnList.Qty -= qty;
            }

        }
        public decimal Calculate()
        {
            return Convert.ToDecimal(itemOrderList.Sum(x => x.Item.Price * x.Qty));
        }
        public void Clear()
        {
            itemOrderList.Clear();
        }

        public IEnumerable<ItemOrderList> OrderList { get { return itemOrderList; } }
    }
    public class ItemOrderList
    {
        public MenuItem Item { get; set; }
        public int Qty { get; set; }
    }
}