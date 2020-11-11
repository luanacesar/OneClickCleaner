using System;
namespace OCC.Models
{
    public class Customer
    {
        public Customer()
        {
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Emeil { get; set; }
        public string Phone { get; set; }
    }
}
