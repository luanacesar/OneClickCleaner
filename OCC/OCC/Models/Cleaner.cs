using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCC.Models
{
    public class Cleaner 
    {
        public long CleanerId { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public bool IsCleaner { get; set; }

        public string ExperienceLevel { get; set; }

        public string Certificate { get; set; }

        public long BankAccount { get; set; }

    }
}
