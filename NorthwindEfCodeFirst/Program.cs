﻿using NorthwindEfCodeFirst.Contexts;
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
       

            Console.ReadLine();

        }

        private static void OrderBy()
        {
            using (var northwindContext = new NorthwindContext())
            {
                List<Customer> result = (from c in northwindContext.Customers
                                         orderby c.Country.Length descending, c.ContactName ascending // Order by ile istediğin şekilde sıralarsın descending tersten sıralar , ascending düzden sıralar
                                         select c).ToList();
                foreach (var customer in result)
                {
                    Console.WriteLine("{0},{1}", customer.Country, customer.ContactName);
                }
            }
        }

        private static void GroupBy1()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             group c by new { c.Country, c.City }
                             into g
                             select new
                             {
                                 sehir = g.Key.City,
                                 ulke = g.Key.Country,
                                 adet = g.Count()
                             };
                foreach (var group in result)
                {
                    Console.WriteLine("Ulke : {0} , Şehir : {1} , Adet : {2}", group.ulke, group.sehir, group.adet);
                }
            }
        }

        private static void GroupBy()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             group c by c.Country
                             into g
                             select g;
                foreach (var group in result)
                {
                    Console.WriteLine(group.Key);//anahtar değerine göre değeri listelicek
                }
            }
        }

        private static void Projection3()
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

        private static void Projection2()
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

        private static void Projection()
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

        private static void Delete()
        {
            using (var northwindContext = new NorthwindContext())
            {
                Order order = northwindContext.Orders.Find(1);
                northwindContext.Orders.Remove(order);
                northwindContext.SaveChanges();
            }
        }

        private static void Add1()
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

        private static void Add()
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

        private static void Start()
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
