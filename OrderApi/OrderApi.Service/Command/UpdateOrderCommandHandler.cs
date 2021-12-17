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
    public class UpdateOrderCommandHandler:IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(UpdateOrderCommand requset,CancellationToken cancellationToken )
        {
             await _orderRepository.UpdateRangeAsync(requset.Orders);
            return Unit.Value;
        }
    }
}
