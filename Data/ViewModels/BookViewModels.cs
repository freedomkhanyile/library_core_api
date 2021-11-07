using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        [Display(Name = "Book Name")]
        [Required]
        public string BookName { get; set; }

        [Display(Name = "ISBN Number")]
        [Required]
        public string ISBN { get; set; }

        [Display(Name = "Year of release")]
        [Required]
        [
            Range(
                1700,
                int.MaxValue,
                ErrorMessage = "Year must be greater than 1700's")
        ]
        public string Year { get; set; }
    }

    public class CreateBookViewModel
    {
        public int BookId { get; set; }

        [Display(Name = "Book Name")]
        [Required]
        public string BookName { get; set; }

        [Display(Name = "ISBN Number")]
        [Required]
        public string ISBN { get; set; }

        [Display(Name = "Year of release")]
        [Required]
        [
            Range(
                1700,
                int.MaxValue,
                ErrorMessage = "Year must be greater than 1700's")
        ]
        public string Year { get; set; }

        public string CreatedBy { get; set; }
    }

    public class UpdateBookViewModel
    {
        [Required]
        public int BookId { get; set; }

        [Display(Name = "Book Name")]
        [Required]
        public string BookName { get; set; }

        [Display(Name = "ISBN Number")]
        [Required]
        public string ISBN { get; set; }

        [Display(Name = "Year of release")]
        [Required]
        [
            Range(
                1700,
                int.MaxValue,
                ErrorMessage = "Year must be greater than 1700's")
        ]
        public string Year { get; set; }
    }
    
      public class BookListViewModel
    {
        public List<BookViewModel> books { get; set; }

        public int Count { get; set; }
    }
}
