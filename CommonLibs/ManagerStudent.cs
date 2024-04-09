using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs
{
    public class ManagerStudent : IStudent
    {
        List<Person_Class> students = new List<Person_Class>();

        public List<Person_Class> Student_GetAll()
        {
           return students;
        }

        public int Student_Insert(Person_Class student)
        {
            students.Add(student);
            return 1;
        }
    }
}
