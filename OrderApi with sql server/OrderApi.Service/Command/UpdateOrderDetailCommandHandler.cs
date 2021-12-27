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
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public UpdateOrderDetailCommandHandler(IOrderDetailRepository  orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<Unit> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
             await _orderDetailRepository.UpdateRangeAsync(request.OrderDetails);
            return Unit.Value;
        }
    }
}
