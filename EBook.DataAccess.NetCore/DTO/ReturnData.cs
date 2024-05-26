using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.DTO
{
    public class ReturnData
    {
        public int ReturnCode { get; set; }
        public string ReturnMsg { get; set; }
    }

    public class BookInsertReturnData : ReturnData
    {
        public Book book { get; set; }
    }

    public class ProductInsertReturnData : ReturnData
    {
        public Product product { get; set; }
    }
}
