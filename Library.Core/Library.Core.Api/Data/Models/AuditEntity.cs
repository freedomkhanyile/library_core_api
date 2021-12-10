using System;

namespace Library.Core.Api.Data.Models
{
    public abstract class AuditEntity
    {
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyUserId { get; set; }
        public int StatusId { get; set; }
    }
}