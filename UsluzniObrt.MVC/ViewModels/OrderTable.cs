using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsluzniObrt.Model;

namespace UsluzniObrt.MVC.ViewModels
{
    public class OrderTable
    {
        public List<OrderTableViewModel> tableList = new List<OrderTableViewModel>();

        public void AddToTable(Table tableId, Office OfficeId )
        {

            tableList.Add(new OrderTableViewModel { Table = tableId, Office = OfficeId });

        }
        
    }
    public class OrderTableViewModel
    {
        public Table Table { get; set; }

        public Office Office { get; set; }
    }
}