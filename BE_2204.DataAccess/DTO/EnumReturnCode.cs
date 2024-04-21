using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2204.DataAccess.DTO
{
    public enum EnumReturnCode
    {
        SuccessFull = 1,
        Fail = -1,
        Exception = -969,
        DataInValid
    }
}
