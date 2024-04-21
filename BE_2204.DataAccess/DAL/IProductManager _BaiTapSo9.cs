using BE_2204.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2204.DataAccess.DAL
{
    public interface IProductManager_BaiTapSo9
    {
        // chọn sản phẩm cần mua và số lượng 
        ReturnData BuyProduct(BuyProductRequestData requestData);
        List<Product_BaiTapSo9> GetListProduct();

        Product_BaiTapSo9 GetProductById(int PrductId);
    }
}
