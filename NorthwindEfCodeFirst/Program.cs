using NorthwindEfCodeFirst.Contexts;
using System;

namespace NorthwindEfCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var northwindContext=new NorthwindContext())
            {
                foreach (var item in northwindContext.Customers)
                {
                    Console.WriteLine("Customer Name : {0}",item.ContactName);
                }

            }
            Console.ReadLine();

        }
    }
}
