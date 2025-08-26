using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class ModelBooking
    {
    
        public int BookingId { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

