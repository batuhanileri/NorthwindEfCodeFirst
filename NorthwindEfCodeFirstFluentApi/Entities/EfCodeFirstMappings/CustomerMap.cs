using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace NorthwindEfCodeFirstFluentApi.Entities.EfCodeFirstMappings
{
    public class CustomerMap:EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.HasKey(t => t.CustomerID);
            this.Property(t => t.CustomerID).IsRequired().HasMaxLength(5);
            this.Property(t => t.CompanyName).IsRequired().HasMaxLength(40);
            this.Property(t => t.City).IsRequired().HasMaxLength(15);
            this.Property(t => t.ContactName).IsRequired().HasMaxLength(25);
            this.Property(t => t.Country).IsRequired().HasMaxLength(15);

            this.ToTable("Customers");

            this.Property(t => t.CustomerID).HasColumnName("CustomerID"); // Poco classtan , Domain classtan property adını silsen dahi veritabanına bu sekilde kaydedicek ve olası hatanın önüne geçilecek
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.ContactName).HasColumnName("ContactName");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
           
        }
    }
}
