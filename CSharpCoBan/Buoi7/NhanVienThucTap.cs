using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.Buoi7
{
    public class NhanVienThucTap : NhanVien_Abstract
    {
       
        public  double HeSoLuong_ThucTap { get; set; } 

        public override void HienThiThongTin()
        {
            throw new NotImplementedException();
        }

        public override void NhapThongTin()
        {
            throw new NotImplementedException();
        }

        public override double TinhLuong()
        {
            return LuongCoBan * LuongCoBan;
        }
    }
}
