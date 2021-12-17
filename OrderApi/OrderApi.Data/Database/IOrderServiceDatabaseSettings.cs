using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Data.Database
{
    public interface IOrderServiceDatabaseSettings
    {
         string ConnectionString { get; set; } 
         string DatabaseName { get; set; } 
         string OrdersCollectionName { get; set; }
         string OrderDetailsCollectionName { get; set; } 
    }
}
