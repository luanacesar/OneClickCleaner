using System;
using System.ComponentModel.DataAnnotations;

namespace OCC.Models
{
    public class Customer
    {
        public Customer()
        {
        }
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
