using System;

namespace NorthwindEfCodeFirstFluentApi
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }//Bir siparişin bir müşterisi olur
    }
}