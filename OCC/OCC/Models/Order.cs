using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCC.Models
{
    public class Order
    {
        public long OrderId { get; set; }

        public long CustomerId { get; set; }

        public long CleanerId { get; set; }

        public long ServiceId { get; set; }

        public string Location { get; set; }

        public int Duration { get; set; }

        

        //ShiftTime: Morning, Afternoon, Evening, Night
        public string ShiftTime { get; set; }

        public DateTime ServiceDay { get; set; }

        public string OrderPaymentState { get; set; }
        
    }
}
