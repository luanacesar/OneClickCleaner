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
        [RegularExpression("^[0-9]{7,8}$", ErrorMessage = "Write Valid Certificate (7 to 8 digits)")]
        public string Certificate { get; set; }
        
        [Required]
        public double BankAccount { get; set; }

        public bool Morning { get; set; }
        public bool Afternoon { get; set; }
        public bool Evening { get; set; }
        public bool Night { get; set; }
        public bool Weekends { get; set; }

    }
}

