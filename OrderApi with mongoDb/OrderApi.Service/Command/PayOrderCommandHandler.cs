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
    public class PayOrderCommandHandler:IRequestHandler<PayOrderCommand,Order>
    {
        private readonly IOrderRepository _orderRepository;
        public PayOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> Handle(PayOrderCommand request,CancellationToken cancellationToken)
        {
            return await _orderRepository.UpdateAsync(request.Order);
        }
    }
}
