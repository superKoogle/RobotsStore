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
        Store214087579Context _store214087579;

        public OrderRepository(Store214087579Context store214104465)
        {
            this._store214087579 = store214104465;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _store214087579.Orders.AddAsync(order);
            await _store214087579.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _store214087579.Orders.FindAsync(id);
        }
    }
}
