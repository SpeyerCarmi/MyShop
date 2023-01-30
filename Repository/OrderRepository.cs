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
        private readonly MyDatabaseContext dbContext;
        public OrderRepository(MyDatabaseContext myDatabaseContext)
        {
            dbContext = myDatabaseContext;
        }
        public async Task<Order> createOrder(Order order)
        {

            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return order;
        }
    }
}
