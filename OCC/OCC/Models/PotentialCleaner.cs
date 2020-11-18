using System;
using System.ComponentModel.DataAnnotations;

namespace OCC.Models
{
    public class PotentialCleaner
    {
        public PotentialCleaner()
        {
        }


        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public int CertificateNumber { get; set; }
       

    } 
}

