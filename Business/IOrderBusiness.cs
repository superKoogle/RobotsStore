using Entities;

namespace Business
{
    public interface IOrderBusiness
    {
        Task<Order> AddOrder(Order order);
        Task<Order> GetOrderById(int id);
    }
}