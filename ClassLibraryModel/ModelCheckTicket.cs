using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class ModelCheckTicket
    {
        public int CheckId { get; set; }
        public int Eventid { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }

       
        public decimal Price { get; set; }
    }
}
