using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Models
{
    public class UpdateProductModel
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
        public int CategoryId { get; set; }
        public DateTime InsertTime { get; set; } 
        public DateTime? UpdateTime { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } 
        public DateTime? DeleteTime { get; set; }
    }
}
