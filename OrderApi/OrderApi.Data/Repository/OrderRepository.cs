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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(IMongoOrderContext orderContext) : base(orderContext)
        {
            _dbCollection = _orderContext.GetCollection<Order>("Order");
        }
        public async Task<Order> GetOrderByIdAsync(string Id, CancellationToken cancellationToken)
        {
           return await _dbCollection.Find(o => o.Id == Id).FirstOrDefaultAsync(cancellationToken);
        }

       
        public async Task<List<Order>> GetOrdersByCustomerGuidAsync(Guid CustomerId, CancellationToken cancellationToken)
        {
            return await _dbCollection.Find(o => o.CustomerGuid == CustomerId).ToListAsync(cancellationToken);
        }

        public async Task<List<Order>> GetPaidOrdersAsync(CancellationToken cancellationToken)
        {
            return await _dbCollection.Find(o=>o.OrderState==OrderState.Paid).ToListAsync(cancellationToken);
        }

        public async Task<List<Order>> GetUnPaidOrdersAsync(CancellationToken cancellationToken)
        {
            return await _dbCollection.Find(o => o.OrderState == OrderState.UnPaid).ToListAsync(cancellationToken);

        }
    }
}
