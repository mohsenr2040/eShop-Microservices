using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Domain.Entities
{
    public class CategoryImage : BaseEntity
    {
        public string Src { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
