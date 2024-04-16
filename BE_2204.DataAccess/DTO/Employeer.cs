using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2204.DataAccess.DTO
{
    public class Employeer : Person
    {
        public Employeer()
        {
            Console.WriteLine("Employeer classs");
        }
        public int HeSo { get; set; }

        public int TinhLuong()
        {
            return HeSo * 5;
        }
    }
}
