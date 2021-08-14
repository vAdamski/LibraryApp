using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain
{
    public class Borrow : BaseEntity
    {
        [Required, IntegerValidator(MinValue = 0), ForeignKey("Reader")]
        public int ReaderId { get; set; }
        [Required, IntegerValidator(MinValue = 0), ForeignKey("Book")]
        public int BookId { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Comments { get; set; }
    }
}
