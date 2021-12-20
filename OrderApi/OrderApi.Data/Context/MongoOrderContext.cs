using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using OrderApi.Data.Database;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Data.Context
{
    public class MongoOrderContext
    {
        //private readonly IMongoCollection<Order> Orders;
        //private readonly IMongoCollection<OrderDetail> OrderDetails;

        public MongoOrderContext( IOrderServiceDatabaseSettings settings) 
        {
            client = new MongoClient(settings.ConnectionString);
            database = client.GetDatabase(settings.DatabaseName);
            //Orders = database.GetCollection<Order>(settings.OrdersCollectionName);
            //OrderDetails = database.GetCollection<OrderDetail>(settings.OrderDetailsCollectionName);
        }
        //public IMongoCollection<Order> Orders { get; set; }
        //public IMongoCollection<OrderDetail> OrderDetails { get; set; }
        private IMongoDatabase database { get; set; }
        private MongoClient client { get; set; }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return database.GetCollection<T>(name);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
           
        //}
    }
}
