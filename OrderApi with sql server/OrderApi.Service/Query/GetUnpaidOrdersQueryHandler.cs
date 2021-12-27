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
    public class GetUnpaidOrdersQueryHandler : IRequestHandler<GetUnpaidOrdersQuery, List<Order>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetUnpaidOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<Order>> Handle(GetUnpaidOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetUnPaidOrdersAsync(cancellationToken);
        }
    }
}
