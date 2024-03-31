using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan
{
    internal class Buoi4_Struct
    {
    }


    public struct Product
    {
        public string Name { get; set; } // read only
        public string Description { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }

        public Product(string _name, string _desc, int _productid, int _price)
        {
            Name = _name;
            Description = _desc;
            ProductId = _productid;
            Price = _price;
            // Syntax
            // logic
        }
    }
}
