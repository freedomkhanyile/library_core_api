using System.ComponentModel.DataAnnotations;

namespace Library.Core.Api.Data.Models
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

        public string Title { get; set; }

        public string InitialCondition { get; set; }

        [Required]
        public decimal OrderCost { get; set; }

        public string Publisher { get; set; }
    }
}
