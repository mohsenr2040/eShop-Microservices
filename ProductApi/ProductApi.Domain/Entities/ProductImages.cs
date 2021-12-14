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
        public int ProductId_fk { get; set; }
        public string Src { get; set; }
    }
}
