using CommonLibs.Common2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan
{
    internal class Buoi7
    {
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person()
        {

        }
        public Person(string name)
        {
            Name = name;
        }


        public int Run(int protein)
        {

            var internalclass = new Common2();
           // var functionName = internalclass.GetFuntionNameFromProtectedClass();
            if (protein == 0) { return 0; }
            return 10;
        }

    }
}
