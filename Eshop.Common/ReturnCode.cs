﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Common
{
    public enum Enum_ReturnCode
    {
        Success = 1,
        DataInValid = -1,
        DuplicateData = -3,
        DataIsNull = -2
    }
}