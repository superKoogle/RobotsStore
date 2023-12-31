﻿using AutoMapper;
using Business;
using Entities;
using DTO;
using Microsoft.AspNetCore.Mvc;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderBusiness _orderBusiness;
        IMapper _mapper;

        public OrderController(IOrderBusiness orderBusiness,IMapper mapper)
        {
            this._orderBusiness = orderBusiness;
            this._mapper = mapper;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {
            Order order = await _orderBusiness.GetOrderById(id);
            OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(order);
            return orderDTO != null? Ok(orderDTO) : NoContent();
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO orderDTO)
        {
            Order order = _mapper.Map<OrderDTO, Order>(orderDTO);
            order = await _orderBusiness.AddOrder(order);
            orderDTO = _mapper.Map<Order, OrderDTO>(order);
            return orderDTO.OrderId != 0 ? Ok(orderDTO) : BadRequest();
        }
    }
}
