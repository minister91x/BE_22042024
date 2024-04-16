using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2204.DataAccess.DTO
{
    public class PartTime : Employeer
    {
        public int HeSo_PartTime { get; set; }
        public PartTime(int _heso, string name, int _age)
        {
            HeSo_PartTime = _heso;
            Name = name;
            Age = _age;
        }
        public int TinhLuongPart()
        {
            return HeSo_PartTime * 2;
        }
    }
}
