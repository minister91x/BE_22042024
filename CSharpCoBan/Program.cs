using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan
{
    public class Program
    {

        public int Tong(int a, int b)
        {
            return a + b;
        }

        enum trangThaiDonHangEnums
        {
            DaDatHang = 1,
            DaThanhToan = 2,
            DaGiaoHang = 3,
            DaHuy = 4
        }
        static void Main(string[] args)
        {
            string myName = "My name is Quan";
            int a = 10;

            const int MyInt = 10000000;
            long _myLong = 1000000;

            var demo = new DemoClass();
            demo.DisPlay();

            // Đặt tên biến làm sao cho tường mình và mang tính chất gợi nhớ 
            // cameCase 
            // Pascal Case 
            // underScore _

            var myVarVariable = 1002;
            var myVarVariable2 = "string";

            //if (MyInt > 10)
            //{
            //    if (MyInt < 20)
            //    {
            //        if ()
            //            Console.WriteLine("myName : " + myName);
            //    }
            //}
            //else
            //{

            //}

            // CTRL+ K + C 
            // CTRL+ K + U 

            switch (myVarVariable)
            {
                case 1001:

                // nhiều logic bên trong
                case 1002:
                    Console.WriteLine("myVarVariable case 1001 or 1002 : " + myVarVariable); break;
                    break;

                case 100: Console.WriteLine("myVarVariable case 100 : " + myVarVariable); break;
                case 101: break;
                default: Console.WriteLine("default : "); break;
            }

            if (myVarVariable == 1002)
            {
                Console.WriteLine("OK");

            }
            else
            {
                Console.WriteLine("Fail");
            }

            var ketqua = myVarVariable == 1002 ? "OK" :
                myVarVariable2 == "string" ? "CO BANG" :
                _myLong == 10000 ? "ok" : "fail";

            Console.WriteLine("ketqua : " + ketqua);



            // Nhập từ bàn phím số tháng -> In ra xem tháng đó có bao nhiêu ngày 

            // CÁC THÁNG CÓ SỐ NGÀY = 31 NGÀY
            // 1 ,3 , 5 ,8 ,10 ,12
            // CÁC THÁNG CÓ SỐ NGÀY = 30 NGÀY
            // 4 ,6 ,9 ,11

            //var sum = MyInt * myVarVariable;

            //Console.WriteLine("myName : " + myName);
            //Console.WriteLine("sum : " + sum);


            //int inPut = 0;
            //Console.WriteLine("Mời nhập số :");
            //inPut = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("số ban vừa nhập là : " + inPut);

            // for + tab 2 lần

            //for (int i = 0; i < 10; i++)
            //{
            //    if (i == 2)
            //    {
            //        continue;
            //    }
            //    Console.WriteLine("Lớp C# Mr Quan: " + i );

            //}

            var index = 0;
            //while (index < 10)
            //{
            //    Console.WriteLine("Lớp C# Mr Quan: " + index);
            //    index++;
            //}

            do
            {
                Console.WriteLine("Lớp C# Mr Quan: " + index);
                index++;

            } while (index < 10);


            //sử dụng vòng lặp for trong C# để tính tổng của các số nhỏ hơn số được nhập từ bàn phìm:
            //ví dụ nhập số 10 : thì sẽ in ra tổng của 1 + 2 + ..+10do{
            int n = 0;
            do
            {

            } while (!int.TryParse("123", out n));

            //----------------------------------------------------------------
            // Buổi 2 : Foreach 

            int[] myArray = { 10, 20, 30, 60 };

            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine("item for: " + myArray[i]);
            }
            // xác định được điểm bắt đầu trong mảng

            foreach (int item in myArray)
            {
                Console.WriteLine("item foreach: " + item);
            }

            // foreach thì không cần chỉ định điểm bắt đầu 
            // tốc độ của for và foreach ? 

            ///--------------------------------------------------
            ///
            //int soThuNhat = 10;
            //Console.WriteLine("--------------------------------------------");
            //Console.WriteLine("soThuNhat=: " + soThuNhat);

            //var functionDemo = new FunctionDemo();
            //functionDemo.ThamTri(soThuNhat);

            //Console.WriteLine("soThuNhat=: " + soThuNhat);

            //functionDemo.ThamChieu(ref soThuNhat);

            //Console.WriteLine("soThuNhat=: " + soThuNhat);

            //int outValue;
            //functionDemo.ThamChieuUsingOut(out outValue);

            //Console.WriteLine("outValue=: " + outValue);

            //functionDemo.chiaHaiSo(10, 0);

            //functionDemo.checkUserInput("12");

            //------------------------------Buổi 4 ------------

            // Đặt tên hàm / biến phải mang tính chất gợi nhớ đến chức năng hoặc nhiệm vụ hàm / biến 


            // fomat code gõ : CTRL+ K +D
            // Cách 1 : 
            var strProduct = new Product("Xe Bus", "Xe điện", 1, 15000);
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Product Name =: " + strProduct.Name);
            Console.WriteLine("Product Description =: " + strProduct.Description);

            // Cách 2 
            var strProduct2 = new Product();
            strProduct2.Name = "F1";
            strProduct2.Description = "Xe đua công thức 1";

            Console.WriteLine("Product2 Name =: " + strProduct2.Name);
            Console.WriteLine("Product2 Description =: " + strProduct2.Description);

            var trangThaiDonHang = 1;

            if (trangThaiDonHang == 1)
            {
                // làm gì đo
            }

            var str = trangThaiDonHangEnums.DaDatHang;

            Console.WriteLine("Product2 Name =: " + str);
            // 
            if (trangThaiDonHang == (int)trangThaiDonHangEnums.DaDatHang)
            {
                // làm gì đo
            }
            if (trangThaiDonHang == (int)trangThaiDonHangEnums.DaThanhToan)
            {
                // làm gì đo
            }
            if (trangThaiDonHang == (int)trangThaiDonHangEnums.DaGiaoHang)
            {
                // làm gì đo
            }
            if (trangThaiDonHang == (int)trangThaiDonHangEnums.DaHuy)
            {
                // làm gì đo
            }

            List<Product> products = new List<Product>();
            string[] cars = { "Honda", "BMW", "Ford", "Mazda" };

            
            cars[3] = "Toyota";
            Console.WriteLine("item car[3] = " + cars[3]);
            foreach (var item in cars)
            {
                Console.WriteLine("item car =: " + item);
            }
            Console.ReadKey();
        }



    }
}
