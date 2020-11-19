using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCC.Models
{
    public class AvailabilityCleaner
    {
        public long AvailabilityCleanerId { get; set; }

        public long CleanerId { get; set; }

        public DateTime StartTime { get; set; }

        public string EndTime { get; set; }
    }
}
