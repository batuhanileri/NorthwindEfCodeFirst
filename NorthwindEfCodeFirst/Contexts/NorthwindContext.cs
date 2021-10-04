using NorthwindEfCodeFirst.Entitites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace NorthwindEfCodeFirst.Contexts
{
    public class NorthwindContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
