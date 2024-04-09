﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs
{
    internal class Cat_Class : Animal
    {
        public override string Eat()
        {
            return "CÁ";
        }

        public override string Sound()
        {
            return "MEO MEO";
        }
    }
}
