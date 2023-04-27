using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        static int idCounter = 3;
        Store214104465Context _store214104465;

        public OrderRepository(Store214104465Context store214104465)
        {
            this._store214104465 = store214104465;
        }

        public async Task<Order> AddOrder(Order order)
        {
            foreach(OrderItem oi in order.OrderItems)
            {
                oi.OrderItemId = idCounter++;
            }
            await _store214104465.Orders.AddAsync(order);
            await _store214104465.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _store214104465.Orders.FindAsync(id);
        }
    }
}
