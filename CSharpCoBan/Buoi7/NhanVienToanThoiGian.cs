using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.Buoi7
{
    public class NhanVienToanThoiGian : NhanVien_Abstract
    {

        public double HeSoLuong_ChinhThuc { get; set; }

        public override void HienThiThongTin()
        {
            throw new NotImplementedException();
        }

        public override void NhapThongTin()
        {
            try
            {
                Console.WriteLine("Nhập tên");
                string idSP = Console.ReadLine();
                Console.Write("hệ số lương nhân viên ");
                HeSoLuong_ChinhThuc = Convert.ToDouble(Console.ReadLine());

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override double TinhLuong()
        {
            return LuongCoBan * HeSoLuong_ChinhThuc;
        }
    }
}
