
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class OderModel
    {
        public Guid CustomerGuid { get; set; }
        public OrderState OrderState { get; set; }
        public string Addrress { get; set; }
        public string CustomerFullName { get; set; }
    }
}
