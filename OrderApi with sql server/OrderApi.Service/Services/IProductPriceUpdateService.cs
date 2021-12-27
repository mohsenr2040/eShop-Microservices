using OrderApi.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Service.Services
{
    public interface IProductPriceUpdateService
    {
        void UpdateProductInOrderDetails(UpdateProductPriceModel updateProductPriceModel);
    }
}
