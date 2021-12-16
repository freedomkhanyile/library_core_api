using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.system.infrustructure.Models
{
    public class Book : AuditEntity
    {
        [Required]
        public string ISBN { get; set; }

        public string BarCode { get; set; }
        [Required]
        public int Year { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Title { get; set; }

        public string InitialCondition { get; set; }

        [Required]
        public decimal OrderCost { get; set; }

        public string Publisher { get; set; }
    }
}
