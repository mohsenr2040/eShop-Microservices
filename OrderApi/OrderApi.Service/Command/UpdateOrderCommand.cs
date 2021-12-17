using MediatR;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Service.Command
{
     public class UpdateOrderCommand:IRequest
    {
        public List<Order> Orders { get; set; }
    }
}
