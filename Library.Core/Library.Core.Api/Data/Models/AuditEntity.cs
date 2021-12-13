using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Core.Api.Data.Models
{
    public abstract class AuditEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyUserId { get; set; }
        public int StatusId { get; set; }
    }
}