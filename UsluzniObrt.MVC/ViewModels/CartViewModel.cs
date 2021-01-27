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

        public void AddItem(Item item, int qty)
        {
            ItemOrderList itemOnList = itemOrderList.Where(x => x.Item.ItemId == item.ItemId).FirstOrDefault();

            if (itemOnList == null)
            {
                itemOrderList.Add(new ItemOrderList { Item = item, Qty = qty });

            }
            else
            {
                itemOnList.Qty += qty;
            }

        }
        public void RemoveItem(Item item)
        {

            itemOrderList.RemoveAll(x => x.Item.ItemId == item.ItemId);

        }
        public decimal Calculate()
        {
            return itemOrderList.Sum(x => x.Item.Cijena * x.Qty);
        }
        public void Clear()
        {
            itemOrderList.Clear();
        }

        public IEnumerable<ItemOrderList> OrderList { get { return itemOrderList; } }
    }
    public class ItemOrderList
    {
        public Item Item { get; set; }
        public int Qty { get; set; }
    }
}