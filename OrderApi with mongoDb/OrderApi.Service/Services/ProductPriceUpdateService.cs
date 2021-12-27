using MediatR;
using OrderApi.Data.Repository;
using OrderApi.Domain.Entities;
using OrderApi.Service.Command;
using OrderApi.Service.Models;
using OrderApi.Service.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Service.Services
{
    public class ProductPriceUpdateService:IProductPriceUpdateService
    {
        private readonly IMediator _mediator;
        public ProductPriceUpdateService(IMediator  mediator)
        {
            _mediator = mediator;
        }
        public async void UpdateProductInOrderDetails(UpdateProductPriceModel updateProductPriceModel)
        {
            try
            {
                var unpaidOrdersOfProduct =await _mediator.Send(new GetUnpaidOrdersQuery { });
                
                if(unpaidOrdersOfProduct.Count!=0)
                {
                     List<OrderDetail> Lst_orderdetails=null;
                    foreach(var _order in unpaidOrdersOfProduct)
                    {
                        var orderdetails = await _mediator.Send(new GetOrderDetailsByOrderIdQuery
                        {
                            order= _order
                        });

                        var orderdetail = orderdetails.FirstOrDefault(o => o.ProductId == updateProductPriceModel.Id);
                        if(orderdetail!=null)
                        {
                            orderdetail.Price = updateProductPriceModel.Price;
                            Lst_orderdetails.Add(orderdetail);
                        }
                     
                    }
                    if(Lst_orderdetails.Count!=0)
                    {
                        await _mediator.Send(new UpdateOrderDetailCommand
                        {
                            OrderDetails = Lst_orderdetails
                        });
                    }
                   
                }
                
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
