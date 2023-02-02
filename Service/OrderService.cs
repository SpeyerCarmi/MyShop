using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        public async Task<Order> createOrder(Order order)
        {
            int count = 0;
            foreach (var item in order.OrderItems)
            {
                //IEnumerable<Product> products = await _productRepository.getProducts(null, null, null, null, null, item.ProductId, null, null, null, null);

                //Product res1 = await product.();
              
                //count += product.price;
            }
            
            Order newOrder = await _orderRepository.createOrder(order);
            return newOrder;
        }
    }
}
