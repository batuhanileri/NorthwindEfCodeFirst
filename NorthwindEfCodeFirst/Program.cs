using NorthwindEfCodeFirst.Contexts;
using NorthwindEfCodeFirst.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindEfCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            // One();
            // Two();
            // Three();
            // Four(); 
            // Five();
            // Six();
            // Seven();

            Console.ReadLine();

        }

        private static void Seven()
        {
            using (var northwindContext = new NorthwindContext())
            {
                List<Customer> result = (from c in northwindContext.Customers
                                         where c.City == "London"
                                         select c).ToList();
                foreach (var customer in result)
                {
                    Console.WriteLine("Contact Name : {0} , City:{1}", customer.ContactName, customer.City);
                }
            }
        }

        private static void Six()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             select new { c.ContactName, c.CompanyName };
                foreach (var customer in result)
                {
                    Console.WriteLine(customer);
                }
            }
        }

        private static void Five()
        {
            using (var northwindContext = new NorthwindContext())
            {
                List<Customer> result = (from c in northwindContext.Customers
                                         select c).ToList();
                foreach (var customer in result)
                {
                    Console.WriteLine(customer.ContactName);
                }
            }
        }

        private static void Four()
        {
            using (var northwindContext = new NorthwindContext())
            {
                Order order = northwindContext.Orders.Find(1);
                northwindContext.Orders.Remove(order);
                northwindContext.SaveChanges();
            }
        }

        private static void Three()
        {
            using (var northwindContext = new NorthwindContext())
            {
                Customer customer = northwindContext.Customers.Find("Batuhan");//primary keye göre buluyor 
                customer.Orders.Add(new Order
                {
                    OrderID = 1,
                    OrderDate = DateTime.Now,
                    ShipCity = "Ankara",
                    ShipCountry = "Türkiye"
                });
                northwindContext.SaveChanges();
            }
        }

        private static void Two()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var customer = new Customer
                {
                    CustomerID = "Batuhan",
                    City = "Bursa",
                    CompanyName = "batuhan.com",
                    ContactName = "Batuhan İleri",
                    Country = "Türkiye"
                };
                northwindContext.Customers.Add(customer);
                northwindContext.SaveChanges();
            }
        }

        private static void One()
        {
            using (var northwindContext = new NorthwindContext())
            {
                foreach (var item in northwindContext.Customers)
                {
                    Console.WriteLine("Customer Name : {0}", item.ContactName);
                }

            }
        }
    }
}
