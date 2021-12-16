using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.system.infrustructure.Models
{
    public abstract class AuditEntity
    {
        [Key]
        public int Id { get; set; }

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
