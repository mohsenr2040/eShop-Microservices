using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApi.Data.Repository
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<Product> GetProductByIdAsync(Guid Id, CancellationToken cancellationtoken);
    }
}
