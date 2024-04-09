using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs
{
    public abstract class Animal
    {
        public abstract string Eat();
        public abstract string Sound();

        public virtual int Run()
        {
            return 0;
        }
    }
}
