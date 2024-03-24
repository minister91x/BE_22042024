using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan
{
    public class FunctionDemo
    {
        // Access Modifiers : Public , private , protected ,internal 
        // Nếu hàm không trả về gì thể để kiểu dữ liệu trả về là Void
        //  int  , int b

        // Public : Bất kì chỗ nào thuôc Solution đều có thể Acccess
        // Private : Chỉ sử dụng được trong nôi bộ class và hàm đó được khai báo
        public int tinhTongHaiSo(int soThuNhat, int soThuHai)
        {
            var tong = soThuNhat + soThuHai;
            return tong;
        }

        public void binhPhuong(ref int thamSodauVao)
        {
            thamSodauVao = thamSodauVao * thamSodauVao;
        }

        public void ThamTri(int x)
        {
            x = x * x;
            Console.WriteLine("ThamTri :" + x);
        }

        public void ThamChieu(ref int x)
        {
            x = x * x;
            Console.WriteLine("ThamChieu :" + x);
        }

        public void ThamChieuUsingOut(out int x)
        {
            x = 150;
            Console.WriteLine("ThamChieu :" + x);
        }

        public int chiaHaiSo(int soThuNhat, int soThuHai)
        {
            var result = 0;
            try
            {
                result = soThuNhat / (soThuHai + 2);
            }
            catch(Exception ex)
            {

            }


            return result;
        }

        public  void checkUserInput(string s)
        {
            if (s.Length < 10)
            {
                Exception e = new DataTooLongExeption();
                throw e;    // lỗi văng ra
            }
            //Other code - no exeption
        }


    }
}
