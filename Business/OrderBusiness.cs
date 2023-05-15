using Entities;
using Microsoft.Extensions.Logging;
using NLog;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Microsoft.Extensions.Logging;

namespace Business
{
    public class OrderBusiness : IOrderBusiness
    {
        IOrderRepository _orderRepository;
        IProductRepository _productRepository;
        ILogger<OrderBusiness> _logger;
        public OrderBusiness(IOrderRepository orderRepository, IProductRepository productRepository, ILogger<OrderBusiness> logger)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<Order> AddOrder(Order order)
        {
            if (!await ValidateOrderSum(order))
            {
                _logger.LogWarning("Mismatch in order sum");
                return order;
            } 

            return await _orderRepository.AddOrder(order);
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _orderRepository.GetOrderById(id);
        }

        private async Task<bool> ValidateOrderSum(Order order)
        {
            double sum = 0;
            foreach (OrderItem orderItem in order.OrderItems)
            {
                Product p = await _productRepository.GetProductById(orderItem.ProductId);
                sum += (p.Price) * orderItem.Quantity;
            }
            return sum == order.OrderSum;

        }
    }
}
