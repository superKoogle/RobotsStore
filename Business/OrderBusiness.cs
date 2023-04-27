using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class OrderBusiness : IOrderBusiness
    {
        IOrderRepository _orderRepository;
        public OrderBusiness(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public async Task<Order> AddOrder(Order order)
        {
            return await _orderRepository.AddOrder(order);
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _orderRepository.GetOrderById(id);
        }
    }
}
