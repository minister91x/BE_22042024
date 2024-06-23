using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.DTO
{
    public class GetBooksRequuestData
    {
        public string? BookName { get; set; }
        public int CategoryID { get; set; }

        public string? publishDateFrom { get; set; }
        public string? publishDateTo { get; set; }
    }
}
