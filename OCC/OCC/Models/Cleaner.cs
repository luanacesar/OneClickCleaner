using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCC.Models
{
    public class Cleaner
    {
        public long CleanerId { get; set; }

        public string FirstName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        public string Location { get; set; }

        public bool IsCleaner { get; set; }

        public string ExperienceLevel { get; set; }
        
        //[MinLength(7)]
        //[MaxLength(8)]
        [RegularExpression("^[0-9]{7,8}$", ErrorMessage = "Write Valid Certificate (7 to 8 digits)")]
        public string Certificate { get; set; }

        public long BankAccount { get; set; }

    }
}
