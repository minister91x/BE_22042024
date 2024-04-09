using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs.Common2
{
    public class Common2 : ProtectedClass
    {
        public int TinhTich()
        {
            var common = new Common();
            return common.tichHaiSo(10, 2);
        }
    }
}
