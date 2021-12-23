using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.Data.Repository
{
    public interface IOrderRepository:IRepository<Order>
    {
        Task<List<Order>> GetPaidOrdersAsync(CancellationToken cancellationToken);
        Task<List<Order>> GetUnPaidOrdersAsync(CancellationToken cancellationToken);
        Task<Order> GetOrderByIdAsync(int Id, CancellationToken cancellationToken);
        Task<List<Order>> GetOrdersByCustomerGuidAsync(Guid CustomerId, CancellationToken cancellationToken);

        
    }
}
