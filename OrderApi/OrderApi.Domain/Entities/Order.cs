using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Domain.Entities
{
    public class Order: Document
    {
      
        public Guid CustomerGuid { get; set; }
        public  OrderState OrderState  { get; set; }
        public string Addrress { get; set; }
        public string CustomerFullName { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
