using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs
{
    public class BirdClass : Animal
    {
        public override string Eat()
        {
            return "ĂN SÂU";
        }

        public override string Sound()
        {
            return "CHIP CHIP";
        }
    }
}
