using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace NorthwindEfCodeFirstFluentApi.Entities.EfCodeFirstMappings
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            this.HasKey(t => t.OrderID);

            this.HasOptional(t =>t.Customer).WithMany(t=>t.Orders).HasForeignKey(d=>d.CustomerID);//1-n ilişki
        }
    }
}
