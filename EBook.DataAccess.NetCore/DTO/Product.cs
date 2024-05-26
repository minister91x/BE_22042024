using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.DTO
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
       
    }
}
