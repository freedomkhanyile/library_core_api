using System.ComponentModel.DataAnnotations;

namespace library.system.api.ViewModels.Book
{
    public class BookViewModel
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
