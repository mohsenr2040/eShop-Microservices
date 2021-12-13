﻿using Microsoft.EntityFrameworkCore;
using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Data.Database
{
    public class ProductContext:DbContext
    {
        public ProductContext()
        {
        }
        public ProductContext(DbContextOptions<ProductContext> option):base(option)
        {

        }
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Version", "1.0");
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Name).IsRequired();
                entity.Property(p => p.CategoryId).IsRequired();
                entity.HasQueryFilter(p => p.IsDeleted == false);
            }) ;
        }
    }
}
