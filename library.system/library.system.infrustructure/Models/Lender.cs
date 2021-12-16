using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.system.infrustructure.Models
{
    public class Lender : AuditEntity
    {

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string CardNumber { get; set; }

        public virtual List<LenderAddress> Addresses { get; set; }
        public virtual List<BookingHistory> BookingHistories { get; set; }
    }

    public class LenderAddress : AuditEntity
    {
        public virtual Address Address { get; set; }

        public bool IsMainAddress { get; set; }

        public AddressType AddressType { get; set; }
    }
}
