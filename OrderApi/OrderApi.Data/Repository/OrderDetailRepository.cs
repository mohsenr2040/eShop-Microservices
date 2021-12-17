using MongoDB.Driver;
using OrderApi.Data.Context;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.Data.Repository
{
    public class OrderDetailRepository:Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(OrderContext orderContext) : base(orderContext)
        {

        }
        public async Task<List<OrderDetail>> GetOrderDetailsByOrderIdAsync(string Id, CancellationToken cancellationToken)
        {
            return await _orderContext.OrderDetails.Find(o=>o.OrderId==Id).ToListAsync(cancellationToken);
        }

    }
}
