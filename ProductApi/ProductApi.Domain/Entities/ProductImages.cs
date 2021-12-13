using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Domain.Entities
{
    public class ProductImages : BaseEntity
    {
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
        public string Src { get; set; }
    }
}
