using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.Data.Repository
{
     public interface IOrderDetailRepository :IRepository<OrderDetail>
    {
        Task<List<OrderDetail>> GetOrderDetailsByOrderIdAsync(string Id, CancellationToken cancellationToken);
    }
}
