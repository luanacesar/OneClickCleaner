using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace OCC.Models
{
    public class Cleaner
    {
        public long CleanerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public bool IsCleaner { get; set; }
        [Required]
        public string ExperienceLevel { get; set; }
        [Required]
        public string Certificate { get; set; }
        [Required]
        public double BankAccount { get; set; }
        

    }
}

