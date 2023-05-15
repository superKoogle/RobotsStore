using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        static int idCounter = 30;
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
            var order =  await _store214104465.Orders.Include(order=>order.OrderItems).Where(order=>order.OrderId==id).ToListAsync();
            return order != null ? order[0] : null;
        }
    }
}
