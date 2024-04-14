using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.Buoi7
{
    public abstract class NhanVien_Abstract
    {
        public string HoTen { get; set; }
        public string MaNV { get; set; }
        public  double LuongCoBan { get; set; }
        public abstract double TinhLuong();

        public abstract void NhapThongTin();
        public abstract void HienThiThongTin();
    }
}
