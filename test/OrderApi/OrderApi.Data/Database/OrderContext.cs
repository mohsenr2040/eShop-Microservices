using System;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using OrderApi.Domain;

namespace OrderApi.Data.Database
{
        public class OrderContext : IMongoOrderContext
        {
            //private readonly IMongoCollection<Order> Orders;
            //private readonly IMongoCollection<OrderDetail> OrderDetails;

            public OrderContext(IOrderServiceDatabaseSettings settings)
            {
                client = new MongoClient(settings.ConnectionString);
                database = client.GetDatabase(settings.DatabaseName);
                Orders = database.GetCollection<Order>(settings.OrdersCollectionName);
            }
            public IMongoCollection<Order> Orders { get; set; }
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
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

        //    modelBuilder.Entity<Order>(entity =>
        //    {
        //        entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

        //        entity.Property(e => e.CustomerFullName).IsRequired();
        //    });
        //}
    
}