using AutoMapper;
using Business;
using Entities;
using DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderBusiness _orderBusiness;
        IMapper _mapper;

        public OrderController(IOrderBusiness orderBusiness, IMapper mapper)
        {
            this._orderBusiness = orderBusiness;
            _mapper = mapper;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {
            Order order = await _orderBusiness.GetOrderById(id);
            OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(order);
            return orderDTO!=null? Ok(orderDTO) : NoContent();
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO orderDto)
        {
            Order order = _mapper.Map<OrderDTO, Order>(orderDto);
            order = await _orderBusiness.AddOrder(order);
            orderDto = _mapper.Map<Order, OrderDTO>(order);
            return orderDto.OrderId != 0 ? Ok(orderDto) : BadRequest();
        }
    }
}
