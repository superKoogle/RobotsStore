using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderBusiness _orderBusiness;

        public OrderController(IOrderBusiness orderBusiness)
        {
            this._orderBusiness = orderBusiness;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            Order order = await _orderBusiness.GetOrderById(id);
            return order!=null? Ok(order) : NoContent();
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            order = await _orderBusiness.AddOrder(order);
            return order.OrderId != 0 ? Ok(order) : BadRequest();
        }
    }
}
