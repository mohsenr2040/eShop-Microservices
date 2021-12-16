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
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand, OrderDetail>
    {
        private readonly IOrderRepository _orderRepository;
        public UpdateOrderDetailCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderDetail> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            return await _orderRepository.UpdateAsync(request.OrderDetail);
        }
    }
}
