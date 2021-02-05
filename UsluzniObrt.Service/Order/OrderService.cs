using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsluzniObrt.Model;
using UsluzniObrt.Repository;
using UsluzniObrt.Service.DTO;

namespace UsluzniObrt.Service
{
    public class OrderService : IOrderService
    {

        public IOrderRepository _orderRepository;

        public OrderService()
        {
               
        }

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void Add(Order order)
        {
            var existingOrder = _orderRepository.GetAll().Any(x => x.TableNumber == order.TableNumber && x.Status != OrderStatus.Completed);
            if (existingOrder)
            {
                //throw exception
            }
            else
            {
                _orderRepository.Insert(order);
                _orderRepository.Save();
            }
            
            
        }

        public void Delete(int id)
        {
            _orderRepository.Delete(id);
            _orderRepository.Save();
        }

        public void edit(Order item)
        {
            _orderRepository.Update(item);
            _orderRepository.Save();
        }

        public List<Order> GetAll()
        {
            return _orderRepository.GetAll().ToList();
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetById(id);
        }
    }
}
