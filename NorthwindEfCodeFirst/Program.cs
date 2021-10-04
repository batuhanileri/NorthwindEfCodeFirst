using NorthwindEfCodeFirst.Contexts;
using NorthwindEfCodeFirst.Entitites;
using System;

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
            Console.ReadLine();

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
