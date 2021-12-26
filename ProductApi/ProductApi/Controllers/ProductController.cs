using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Domain.Entities;
using ProductApi.Models;
using ProductApi.Service.Command;
using ProductApi.Service.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [Produces("application/json")]
    [Route("[Controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<Product>> Product(CreateProductModel createProductModel)
        {
            try
            {
                return await _mediator.Send(new CreateProductCommand
                {
                    Product = _mapper.Map<Product>(createProductModel)
                }) ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<ActionResult<Product>> Product(UpdateProductModel updateProductModel)
        {
            try
            {
                var product = await _mediator.Send(new GetProductByIdQuery
                {
                    Id = updateProductModel.ProductId
                }) ;
                if (product == null)
                {
                    return BadRequest($"No product found with the id {updateProductModel.ProductId}");
                }

                return await _mediator.Send(new UpdateProductCommand
                {
                    Product = _mapper.Map(updateProductModel, product)
                }) ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<Product>> GetProduct(Guid ProductId)
        {
            try
            {
                return await _mediator.Send(new GetProductByIdQuery
                {
                    Id= ProductId
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
