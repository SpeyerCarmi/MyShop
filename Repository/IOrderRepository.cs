using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> createOrder(Order order);
    }
}