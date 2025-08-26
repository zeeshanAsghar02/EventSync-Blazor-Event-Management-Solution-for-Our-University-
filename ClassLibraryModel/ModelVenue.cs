using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class ModelVenue
    {
        public int VenueId { get; set; }
        public string? VenueName { get; set; }
        public string? Address { get; set; }
        public int Capacity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
