using Microsoft.EntityFrameworkCore;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;

namespace OrderApi.Data.Context
{
    public class OrderContext:DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options):base(options)
        {

        }
       public  DbSet<Order> Orders { get; set; }
       public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Version", "1.0");
            modelBuilder.Entity<Order>(entity => entity.HasQueryFilter(o => o.IsDeleted == false));
            modelBuilder.Entity<OrderDetail>(entity => entity.HasQueryFilter(d => d.IsDeleted == false));
        }
    }
}
