using System;
using System.ComponentModel.DataAnnotations;

namespace library.system.api.ViewModels.Book
{
    public class BookCreateViewModel 
    {
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string BarCode { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string InitialCondition { get; set; }
        [Required]
        public decimal OrderCost { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public string CreateUserId { get; set; }
        [Required]
        public DateTime ModifyDate { get; set; }
        [Required]
        public string ModifyUserId { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}
