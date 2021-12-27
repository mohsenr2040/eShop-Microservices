using ProductApi.Domain.Entities;
using ProductApi.Messaging.Send.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Messaging.Send.Sender
{
    public interface IUpdateProductSender
    {
        void SendProduct(UpdatedProductPriceModel updatedProductPriceModel);
    }
}
