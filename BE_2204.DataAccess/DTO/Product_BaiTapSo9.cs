using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2204.DataAccess.DTO
{
    public class Product_BaiTapSo9
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }

    public class BuyProductRequestData
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int DisCount { get; set; }

        public int TotalAmount { get; set; }

    }
}
