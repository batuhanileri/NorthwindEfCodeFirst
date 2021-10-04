using NorthwindEfCodeFirstFluentApi.Entities.EfCodeFirstMappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace NorthwindEfCodeFirstFluentApi.Contexts
{
    public class NorthwindContext:DbContext
    {
        //public NorthwindContext():base("Name=ContextConnectionString")
        //{

        //}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        //Mappingleri ayağa kaldırmak için bu methodu kullanıyoruz
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrderMap());
        }

    }
}
