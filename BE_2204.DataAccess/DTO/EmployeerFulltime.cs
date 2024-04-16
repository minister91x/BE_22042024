using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2204.DataAccess.DTO
{
    public class EmployeerFulltime : Employeer
    {
        public int HeSo_FullTime { get; set; }

        public EmployeerFulltime(int heSo_FullTime,string name,int _age)
        {
            HeSo_FullTime = heSo_FullTime;
            Name= name;
            Age = _age;
        }

        public int TinhLuongFullTime()
        {
            return HeSo_FullTime * 15;
        }
    }
}
