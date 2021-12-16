using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.system.infrustructure.Models
{
    public class Author : AuditEntity
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }    
    }
}
