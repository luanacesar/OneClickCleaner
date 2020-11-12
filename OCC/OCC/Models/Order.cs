using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCC.Models
{
    public class Order
    {
        public long Id { get; set; }

        public long CustomerId { get; set; }

        public string Location { get; set; }
        public int Duration { get; set; }
        public int ShiftTime { get; set; }
        public string OrderPaymentState { get; set; }
        public long ServiceId { get; set; }
    }
}
