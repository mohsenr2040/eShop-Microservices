using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Domain.Entities
{
    public class Category :BaseEntity
    {
        public string Name { get; set; }
        public virtual Category ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
        public virtual ICollection<CategoryImage> CategoryImage { get; set; }
    }
}
