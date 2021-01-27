using UsluzniObrt.Model;
using System.Collections.Generic;
namespace UsluzniObrt.Service
{
    public interface IOrderService
    {
        List<Order> GetAll();
        void Add(Order newOrder);
        void Delete(int id);
        void edit(Order item);
        Order GetById(int id);
    }
}