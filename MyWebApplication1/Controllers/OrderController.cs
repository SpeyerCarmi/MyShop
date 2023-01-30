using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
       {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;   
        }
       // POST api/<OrderController>
            [HttpPost]
            public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
                Order newOrder = await _orderService.createOrder(order); 
            
            if (newOrder == null)
                return NotFound();
                return newOrder;
            }

        }
    }

