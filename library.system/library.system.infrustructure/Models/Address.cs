using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.system.infrustructure.Models
{
    public class Address : AuditEntity
    {
        [Required]
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }

    }

    public enum AddressType
    {
        Postal,
        Physical,
        Work,
        Other
    }
}
