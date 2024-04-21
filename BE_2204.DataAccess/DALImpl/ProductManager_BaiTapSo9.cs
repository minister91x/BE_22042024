using BE_2204.DataAccess.DAL;
using BE_2204.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2204.DataAccess.DALImpl
{
    public class ProductManager_BaiTapSo9 : IProductManager_BaiTapSo9
    {
        List<Product_BaiTapSo9> listProduct = new List<Product_BaiTapSo9>();
        public ReturnData BuyProduct(BuyProductRequestData requestData)
        {
            var listProductOrder = new List<ProductOrder_BaiTapBuoi9>();
            var result = new ReturnData();
            try
            {
                // kiểm tra dữ liệu đầu vào ( productid <=0 || quantity<=0)
                if (requestData == null
                    || requestData.ProductId <= 0
                    || requestData.Quantity <= 0
                    || requestData.DisCount < 0
                    || requestData.TotalAmount <= 0)
                {

                    result.ReturnCode = (int)EnumReturnCode.DataInValid;
                    result.ReturnMsg = "Dữ liệu đầu vào không hợp lệ";
                    return result;
                }

                // Kiểm tra xem ProductId có tồn tại không ?

                var product = GetProductById(requestData.ProductId);

                if (product == null || product.ProductId <= 0)
                {
                    result.ReturnCode = (int)EnumReturnCode.DataInValid;
                    result.ReturnMsg = "Sản phẩm không tồn tại";
                    return result;
                }

                // kiểm số số lượng hàng còn không 

                if (product.Quantity < requestData.Quantity)
                {
                    result.ReturnCode = (int)EnumReturnCode.DataInValid;
                    result.ReturnMsg = "Sản phẩm hiện tại đang hết hàng";
                    return result;
                }

                // kiểm tổng tiền vs cái (số lượng * đơn giá + mã giảm giá (nếu có ) = TotalPrice

                var totalAmountByProduct = 0;

                totalAmountByProduct = requestData.Quantity * product.Price;

                // nếu có giảm giá thì tính lại tổng tiền
                if (requestData.DisCount > 0)
                {
                    totalAmountByProduct = totalAmountByProduct - ((totalAmountByProduct * requestData.DisCount) / 100);
                }

                if (requestData.TotalAmount != totalAmountByProduct)
                {
                    result.ReturnCode = (int)EnumReturnCode.DataInValid;
                    result.ReturnMsg = "Tông tiền không hợp lệ";
                    return result;
                }
                // thêm vào danh sách listProductOrder

                listProductOrder.Add(new ProductOrder_BaiTapBuoi9
                {
                    Discount = requestData.DisCount,
                    Price = product.Price,
                    ProductName = product.ProductName,
                    ProductId = product.ProductId,
                    Quantity = requestData.Quantity
                });

                // trả về kết quả 

                result.ReturnCode = (int)EnumReturnCode.SuccessFull;
                result.ReturnMsg = "Chúc mừng bạn mua hàng thành công !";
            }
            catch (Exception ex)
            {

                result.ReturnCode = (int)EnumReturnCode.Exception;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
            }

            return result;
        }

        public List<Product_BaiTapSo9> GetListProduct()
        {
            try
            {
                int id = 1;
                for (int i = 0; i < 5; i++)
                {
                    listProduct.Add(new Product_BaiTapSo9
                    {
                        ProductId = id,
                        ProductName = "ProductName_" + id,
                        Price = 10000 + id,
                        Quantity = 10
                    });
                    id++;
                }

                return listProduct;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Product_BaiTapSo9 GetProductById(int PrductId)
        {
            var product = new Product_BaiTapSo9();
            try
            {
                var listProduct = GetListProduct();
                if (listProduct.Count > 0)
                {
                    product = listProduct.Where(s => s.ProductId == PrductId).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return product;
        }
    }
}
