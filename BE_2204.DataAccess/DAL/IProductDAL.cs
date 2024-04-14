using BE_2204.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2204.DataAccess.DAL
{
    public interface IProductDAL
    {
        ReturnData Product_Insert(Product product);
        List<Product> GetProducts();

        ReturnData Product_Delete(int ProductId);
    }
}
