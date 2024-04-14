using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2204.DataAccess.DTO
{
    public  class Person
    {
        public Person()
        {
            Console.WriteLine("Person classs");
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int GetAge()
        {
            return Age;
        }
    }
}
