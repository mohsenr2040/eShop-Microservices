using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Domain.Entities
{
    public class ProductFeatures : BaseEntity
    {
        public virtual Product Product { get; set; }
        public int ProductId_fk { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
