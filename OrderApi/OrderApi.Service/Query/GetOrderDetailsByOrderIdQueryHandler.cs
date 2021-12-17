using MediatR;
using OrderApi.Data.Repository;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.Service.Query
{
    public class GetOrderDetailsByOrderIdQueryHandler:IRequestHandler<GetOrderDetailsByOrderIdQuery,List<OrderDetail>>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public GetOrderDetailsByOrderIdQueryHandler(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<OrderDetail>> Handle(GetOrderDetailsByOrderIdQuery request, CancellationToken cancellationToken)
        {
            return await _orderDetailRepository.GetOrderDetailsByOrderIdAsync(request.order.OrderId,cancellationToken);
        }
    }
}
