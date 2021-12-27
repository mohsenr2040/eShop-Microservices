using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Service.Models
{
    public class UpdateProductPriceModel
    {
        public int Id { get; set; }
        public int Price { get; set; }
    }
}
