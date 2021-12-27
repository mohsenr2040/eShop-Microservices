using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Messaging.Send.Models
{
    public class UpdatedProductPriceModel
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public int Price { get; set; }
    }
}
