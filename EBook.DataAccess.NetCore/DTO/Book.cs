using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.DTO
{
    public class Book
    {
        public int BookID { get; set; }
        public string? BookName { get; set; }
        public int AuthorID { get; set; }
        public DateTime PublishDate { get; set; }
        public int IsActive { get; set; }
        public int CreatedUser { get; set; }
    }
}
