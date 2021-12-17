using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using OrderApi.Data.Database;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Data.Context
{
    public class OrderContext:DbContext
    {
        //private readonly IMongoCollection<Order> Orders;
        //private readonly IMongoCollection<OrderDetail> OrderDetails;

        public OrderContext(DbContextOptions options, IOrderServiceDatabaseSettings settings) : base(options)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            Orders = database.GetCollection<Order>(settings.OrdersCollectionName);
            OrderDetails = database.GetCollection<OrderDetail>(settings.OrderDetailsCollectionName);
        }
        public IMongoCollection<Order> Orders;
        public IMongoCollection<OrderDetail> OrderDetails;
        //SaveChanges();
    }
}
