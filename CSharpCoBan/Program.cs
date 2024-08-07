﻿using BE_2204.DataAccess.DALImpl;
using BE_2204.DataAccess.DTO;
using CommonLibs;
using CSharpCoBan.Buoi7;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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

        enum Order
        {
            OrderStatus = (int)trangThaiDonHangEnums.DaDatHang
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
                case 7:
                case 8:
                case 9:
                case 10:
                    Console.WriteLine("31 ngày : " + myVarVariable); 
                    break;
                case 1:
                case 2:
                case 3:
                    Console.WriteLine("30 ngày: " + myVarVariable);
                    break;
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

            ///-----------------------------------Buổi 5 DATETIME ------------------------------
            ///

            DateTime myDatetime = new DateTime();
            var dateNow = DateTime.Now;

            Console.WriteLine("myDatetime= " + myDatetime);
            Console.WriteLine("dateNow= " + dateNow);

            var nextDay = DateTime.Now.AddDays(1);

            Console.WriteLine("nextDay= " + nextDay);

            var previousDay = DateTime.Now.AddDays(-1);

            Console.WriteLine("previousDay= " + previousDay);

            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Console.WriteLine("firstDayOfMonth= " + firstDayOfMonth);

            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var dayInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

            Console.WriteLine("lastDayOfMonth= " + lastDayOfMonth);

            Console.WriteLine("dayInMonth= " + dayInMonth);

            var timeSpan = new TimeSpan(1, 1, 0);

            var nextDayTimeSpan = DateTime.Now.Add(timeSpan);

            Console.WriteLine("nextDayTimeSpan= " + nextDayTimeSpan);

            var timeFomat = nextDayTimeSpan.ToString("MM/dd/yyyy HH:mm:ss");

            Console.WriteLine("timeFomat= " + timeFomat);

            var firstDate = DateTime.Now.AddDays(10);
            var secondDate = DateTime.Now.AddDays(10);

            var result = DateTime.Compare(firstDate, secondDate);
            Console.WriteLine("result= " + result);

            string date_string = "15/04/2024";

            var dateFromString = DateTime.ParseExact(date_string, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine("dateFromString= " + dateFromString.ToString("yyyy/MM/dd"));

            var subdate = DateTime.Now - new DateTime(2024, 04, 01);

            // Console.WriteLine("subdate= " + subdate.m);

            DateTime dateValue;
            if (!DateTime.TryParseExact(date_string, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out dateValue))
            {
                Console.WriteLine("Không phải định dạng ngày tháng");
            }
            else
            {
                Console.WriteLine("Đúng định dạng ngày tháng");
            }

            // Viết chương trình tính tuổi của mình 
            // Nhâp vào ngày sinh của mình và in ra màn hình xem mình sinh ra được bao nhiêu ngày rồi 
            DateTime aDateTime = DateTime.Now;

            // Thời điểm năm 2000
            DateTime y2K = new DateTime(2000, 1, 1);

            // Khoảng thời gian từ năm 2000 tới nay.
            //TimeSpan interval = aDateTime.Subtract(y2K);

            //Console.WriteLine("Interval from Y2K to Now: " + interval);

            //Console.WriteLine("Days: " + interval.Days);
            //Console.WriteLine("Hours: " + interval.Hours);
            //Console.WriteLine("Minutes: " + interval.Minutes);
            //Console.WriteLine("Seconds: " + interval.Seconds);

            ////---------------------------------Buổi 5 STRING--------------------------

            //string firstStr = "first_string,";
            //var secondStr = "second_string";

            //var compare = String.Compare(firstStr, secondStr);
            //Console.WriteLine("compare: " + compare);

            //var strReplace = firstStr.Replace('f', 'F');
            //Console.WriteLine("strReplace: " + strReplace);

            //var strSplit = firstStr.Split('_');

            //foreach (var item in strSplit)
            //{
            //    Console.WriteLine("item split: " + item);
            //}

            //var subStr = firstStr.Substring(0, firstStr.Length - 1);

            //Console.WriteLine("subStr: " + subStr);

            //var upper = firstStr.ToUpper();

            //Console.WriteLine("upper: " + upper);

            //var thirdstr = firstStr + secondStr;
            //Console.WriteLine("thirdstr: " + thirdstr);

            //StringBuilder builder = new StringBuilder(firstStr);
            //builder.Append(secondStr);


            //Console.WriteLine("builder: " + builder);

            ///----------------------------------Buổi 6--------------------------------
            ///

            //var generic_Int = new Buoi6GenericFunction<int>();

            //var tong_int = generic_Int.Tong(10, 20);

            //Console.WriteLine("tong_int =: " + tong_int);

            //var generic_long = new Buoi6GenericFunction<long>();

            //var tong_ilong = generic_long.Tong(10, 20);

            //Console.WriteLine("tong_int =: " + tong_int);

            //var generic_string = new Buoi6GenericFunction<string>();

            //var tong_string = generic_string.Tong("Lop BE2204 BACKEND NET ", " Buoi 6");

            //Console.WriteLine("tong_string =: " + tong_string);

            //Buoi6GenericFunction<Sinhvien> intArray = new Buoi6GenericFunction<Sinhvien>(5);
            //// setting values


            //for (int c = 0; c < 5; c++)
            //{
            //    var sinhvien = new Sinhvien();
            //    sinhvien.Ten = "Mr Quan" + c;
            //    intArray.setItem(c, sinhvien);
            //}


            //Console.WriteLine("Items in char array");
            //// retrieving the values
            //for (int c = 0; c < 5; c++)
            //{
            //    Console.Write(intArray.getItem(c).Ten + "\n");
            //}

            //Dictionary<string, string> _phoneBook = new Dictionary<string, string>()
            //{
            //    {"Trump", "0123.456.789" },
            //    {"Obama", "0987.654.321" },
            //};

            //foreach (KeyValuePair<string, string> entry in _phoneBook)
            //{
            //    Console.WriteLine($" -> {entry.Key} : {entry.Value}");
            //}

            //ArrayList myArrayList = new ArrayList();

            //myArrayList.Add(1);
            //myArrayList.Add("SOS");
            //myArrayList.Add(true);

            //foreach (var item in myArrayList)
            //{
            //    Console.WriteLine($" -> " + item);
            //}

            //Hashtable hashtable = new Hashtable();
            //hashtable.Add("NAME", "MR QUAN");
            //hashtable.Add("AGE", "200");
            //foreach (var key in hashtable.Keys)
            //{
            //    Console.WriteLine("Key: {0} ", key);
            //}
            //foreach (var key in hashtable.Values)
            //{
            //    Console.WriteLine("Values: {0} ", key);
            //}


            //SortedList sortedList = new SortedList();
            //sortedList.Add("FIRST", "1");
            //sortedList.Add("SECOND", "2");
            //foreach (var key in sortedList.Keys)
            //{
            //    Console.WriteLine("Key: {0} ", key);
            //}

            //for (int i = 0; i < sortedList.Count; i++)
            //{
            //    Console.WriteLine("Key: {0} ", sortedList["FIRST"]);
            //}


            //Stack myStack = new Stack();
            //myStack.Push("Hello");
            //myStack.Push("World");
            //myStack.Push("!");
            //Console.WriteLine("myStack");
            //Console.WriteLine("\tCount: {0}", myStack.Count);
            //Console.Write("\tValues:");
            //foreach (Object obj in myStack)
            //{
            //    Console.Write(" {0}", obj);
            //}

            //Queue myQ = new Queue();
            //myQ.Enqueue("Hello");
            //myQ.Enqueue("World");
            //myQ.Enqueue("!");
            //Console.WriteLine("myQ");
            //Console.WriteLine("\tCount: {0}", myQ.Count); Console.Write("\tValues:");

            //foreach (Object obj in myQ) Console.Write(" {0}", obj);

            //--------------------------------------Buổi 7---------------------

            var person = new Person_Class();

            person.Name = "";
            person.Id = 1;

            var person2 = new Person_Class(1, "MrQuan");


            var student = new ManagerStudent();
            var student_Input = new Person_Class
            {
                Id = 1,
                Name = "Mr Quan",
            };

            var student_Input2 = new Person_Class
            {
                Id = 1,
                Name = "Mr Quan NETCORE",
            };

            student.Student_Insert(student_Input);
            student.Student_Insert(student_Input2);

            var list = student.Student_GetAll();

            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine("item {0}", item.Name);
                }
            }

            ///---- Buổi 8-------------------------------------------

            var productManager = new BE_2204.DataAccess.DALImpl.ProductDALImpl();

            var product = new BE_2204.DataAccess.DTO.Product();
            product.ProductName = "@$!@$@!4abc123";

            var result_insert = productManager.Product_Insert(product);

            Console.WriteLine("ReturnCode:" + result_insert.ReturnCode);
            Console.WriteLine("ReturMes:" + result_insert.ReturnMsg);


            var employeer = new BE_2204.DataAccess.DTO.Employeer();

            employeer.GetAge();

            //var employeerFullTime = new BE_2204.DataAccess.DTO.EmployeerFulltime();

            //  var employeer2 = (BE_2204.DataAccess.DTO.Person)employeerFullTime;

            // var employeer3 = (BE_2204.DataAccess.DTO.EmployeerFulltime)employeer;


            /// person <- Employeer <- EmployeerFulltime // ok 
            ///        ->            -> // fail

            var nhanvien = new BE_2204.DataAccess.DTO.Employeer();

            //nhanvien.HeSo = 10;
            //nhanvien.TinhLuong();


            nhanvien = new BE_2204.DataAccess.DTO.EmployeerFulltime(100, "Mr FullTime", 30);
            Console.WriteLine("EmployeerFulltime:" + JsonConvert.SerializeObject(nhanvien));


            var fulltime = (BE_2204.DataAccess.DTO.EmployeerFulltime)nhanvien;
            Console.WriteLine("full time Name:" + fulltime.Name);
            Console.WriteLine("fulltime lương:" + fulltime.TinhLuongFullTime());

            nhanvien = new BE_2204.DataAccess.DTO.PartTime(75, "MR PartTime", 19);
            Console.WriteLine("PartTime:" + JsonConvert.SerializeObject(nhanvien));


            var part = (BE_2204.DataAccess.DTO.PartTime)nhanvien;
            Console.WriteLine("part time Name:" + part.Name);
            Console.WriteLine("part time lương:" + part.TinhLuongPart());


            /// Buooi 10 --------------------------------------------
            /// 


            var producManager = new ProductManager_BaiTapSo9();

            var requestData = new BuyProductRequestData
            {
                ProductId = 1,
                Quantity = 2,
                DisCount = 5,
                TotalAmount = 1
            };
            var resultbyProduct = producManager.BuyProduct(requestData);

            Console.WriteLine(resultbyProduct.ReturnMsg);

            Console.ReadKey();
        }



    }
}
