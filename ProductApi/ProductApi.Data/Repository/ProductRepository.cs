using Microsoft.EntityFrameworkCore;
using ProductApi.Data.Database;
using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApi.Data.Repository
{
    public class ProductRepository :  Repository<Product>,IProductRepository
    {
        public ProductRepository(ProductContext productContext):base(productContext)
        {

        }
        public async Task<Product> GetProductByIdAsync(Guid Id, CancellationToken cancellationtoken)
        {
              return  await _context.Product.FirstOrDefaultAsync(p => p.ProductGuid == Id,cancellationtoken);
        }
    }
}
