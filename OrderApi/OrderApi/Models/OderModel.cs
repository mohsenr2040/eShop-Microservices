
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class OderModel
    {
        public Guid CustomerGuid { get; set; } = Guid.NewGuid();
        public OrderState OrderState { get; set; } = OrderState.UnPaid;
        public string Addrress { get; set; }
        public string CustomerFullName { get; set; }
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeleteTime { get; set; }
        public virtual ICollection<OrderDetailsModel> OrderDetailsModels { get; set; }

    }
}
