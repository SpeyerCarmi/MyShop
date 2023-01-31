using AutoMapper;
using DTO;
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

        private readonly IMapper _mapper;

        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;

            _mapper = mapper;

        }
        // POST api/<OrderController>
        [HttpPost]
            public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO orderDTO)
        {

            Order order = _mapper.Map<OrderDTO, Order>(orderDTO);

            Order newOrder = await _orderService.createOrder(order);
            OrderDTO newOrderDto = _mapper.Map<Order, OrderDTO>(newOrder);

                return newOrderDto;
            }

        }
    }

