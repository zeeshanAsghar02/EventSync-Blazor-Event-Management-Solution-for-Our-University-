using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class ModelEvent
    {
        public int EventId { get; set; }
        public string? EventName { get; set; }
        public int EventTypeId { get; set; }
        public int VenueId { get; set; }
    
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Description { get; set; }
        public int? OrganizerId { get; set; }
        
        public decimal? Price { get; set; }
        public int? TicketsBooked { get; set; }
    }
}
