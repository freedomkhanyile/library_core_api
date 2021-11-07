using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
         public string BookName { get; set; }
         [Required]
        public string ISBN { get; set; }
        public string Year { get; set; }
    }
}