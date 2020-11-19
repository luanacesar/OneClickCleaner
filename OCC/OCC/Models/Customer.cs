using System;
using System.ComponentModel.DataAnnotations;


namespace OCC.Models
{
    public class Customer
    {
        public Customer()
        {
        }
        public long CustomerId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
