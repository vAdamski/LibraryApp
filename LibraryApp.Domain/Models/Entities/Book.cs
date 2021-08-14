using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain
{
    public class Book : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Title { get; set; }
        [Required, MaxLength(100)]
        public string Author { get; set; }
        [Required, MaxLength(50)]
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }
    }
}
