using MediatR;
using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Service.Command
{
    public class CreateProductCommand:IRequest<Product>
    {
        public Product Product { get; set; }
    }
}
