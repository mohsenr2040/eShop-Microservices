﻿using MediatR;
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
    public class GetPaidOrdersQueryHandler : IRequestHandler<GetPaidOrdersQuery, List<Order>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetPaidOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }   
        public async Task<List<Order>> Handle(GetPaidOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetPaidOrdersAsync(cancellationToken);
        }
    }
}
