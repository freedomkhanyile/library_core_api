using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.system.infrustructure.Models
{
    public class User : AuditEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }  
        [Required]
        public string Password { get; set; }
        public DateTime DOB { get; set; }

    }
}
