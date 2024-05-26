using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.DTO
{
    public class ProductAttribute
    {
        public int AttributeID { get; set; }
        public string AttributeName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int PriceSale { get; set; }
    }
}
