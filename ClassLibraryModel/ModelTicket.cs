using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class ModelTicket
    
    {
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
      
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}

