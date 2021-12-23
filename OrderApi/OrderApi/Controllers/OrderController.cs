using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Domain.Entities;
using OrderApi.Models;
using OrderApi.Service.Command;
using OrderApi.Service.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<Order>> Order(OderModel orderModel)
        {
            try
            {
                return await _mediator.Send(new CreateOrderCommand
                {
                    Order = _mapper.Map<Order>(orderModel)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<List<Order>>> Orders()
        {
            try
            {
                return await _mediator.Send(new GetPaidOrdersQuery());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetOrder/{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            try
            {
                return await _mediator.Send(new GetOrderByIdQuery
                {
                    Id = id
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("Pay/{id}")]
        public async Task<ActionResult<Order>> Pay(int id)
        {
            try
            {
                var order = await _mediator.Send(new GetOrderByIdQuery
                {
                    Id = id
                });

                if (order == null)
                {
                    return BadRequest($"No order found with the id {id}");
                }

                order.OrderState = OrderState.Paid ;

                return await _mediator.Send(new PayOrderCommand
                {
                    Order = _mapper.Map<Order>(order)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
