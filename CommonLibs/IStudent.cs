using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs
{
    public interface IStudent
    {
        int Student_Insert(Person_Class student);
        List<Person_Class> Student_GetAll();
    }
}
