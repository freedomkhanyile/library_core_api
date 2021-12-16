using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.system.infrustructure.Models
{
    public class BookingHistory: AuditEntity
    {
        public int BookId { get; set; }
        public Book Book { get; set; }       
        public string CardNumber { get; set; }
        public bool Renewed { get; set; }
        public decimal Fee { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime CheckinDate { get; set; }
        public string CurrentCondition { get; set; }
    }
}
