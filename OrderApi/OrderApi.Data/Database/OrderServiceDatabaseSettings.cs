using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Data.Database
{
    public class OrderServiceDatabaseSettings :IOrderServiceDatabaseSettings
    {
        public string ConnectionString { get; set; } 
        public string DatabaseName { get; set; } 
        public string OrdersCollectionName { get; set; } 
        public string OrderDetailsCollectionName { get; set; } 
    }
}
