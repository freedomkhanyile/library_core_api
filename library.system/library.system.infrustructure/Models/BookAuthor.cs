using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.system.infrustructure.Models
{
    public class BookAuthor: AuditEntity
    {
        public string BookId { get; set; }
        public virtual Book Book { get; set; }
        public int AuthorId { get; set; }  
        public virtual Author Author { get; set; }
        public string AuthorType { get; set; }

    }
}
