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
        static void Main(string[] args)
        {
            string myName = "My name is Quan";



            const int MyInt = 100000;
            long _myLong = 1000000;

            // Đặt tên biến làm sao cho tường mình và mang tính chất gợi nhớ 
            // cameCase 
            // Pascal Case 
            // underScore _

            var myVarVariable = 100;
            var myVarVariable2 = "string";

            if (MyInt > 10 && MyInt < 1000001)
            {
                Console.WriteLine("myName : " + myName);
            }
            var sum = MyInt * myVarVariable;

            Console.WriteLine("myName : " + myName);
            Console.WriteLine("sum : " + sum);
          

            int inPut = 0;
            Console.WriteLine("Mời nhập số :");
            inPut = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("số ban vừa nhập là : " + inPut);

            Console.ReadKey();
        }



    }
}
