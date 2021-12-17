using MediatR;
using OrderApi.Data.Repository;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.Service.Command
{
    public class CreateOrderDetailCommandHandler:IRequestHandler<CreateOrderDetailCommand,List<OrderDetail>>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public CreateOrderDetailCommandHandler(IOrderDetailRepository  orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<List<OrderDetail>> Handle (CreateOrderDetailCommand request,CancellationToken cancellationToken )
        {
           return  await _orderDetailRepository.AddRangeAsync(request.OrderDetails);
        }
    }
}
