using BE_2204.DataAccess.DAL;
using BE_2204.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2204.DataAccess.DALImpl
{
    public class ProductDALImpl : IProductDAL
    {
        List<Product> lstProduct = new List<Product>();

        public ReturnData Product_Delete(int ProductId)
        {
            var returnData = new ReturnData();
            try
            {
                // bước 1: Kiểm tra dữ liệu đầu vào hợp lệ không 
                if (ProductId <= 0)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Mã sản phẩm không tồn tại";
                    return returnData;
                }

                // Bước 2 : id này có tồn tại trên hệ thống không
                // cách 1
                var product1 = lstProduct.Where(s => s.ProductId == ProductId).FirstOrDefault();

                if(product1 == null || product1.ProductId <=0)
                {
                    returnData.ReturnCode = -2;
                    returnData.ReturnMsg = "Sản phẩm không tồn tại";
                    return returnData;// đến đây là trả về rồi ko chạy tiếp xuống dưới nữa
                }

                lstProduct.Remove(product1);

                // cách 2
                //var product2 = new Product();
                //if (lstProduct.Count > 0)
                //{
                //    foreach (var item in lstProduct)
                //    {
                //        if(item.ProductId== ProductId)
                //        {
                //            product2 = item;
                //            break;
                //        }
                //    }
                //}


                //if (product2 == null && product2.ProductId < 0)
                //{
                //    returnData.ReturnCode = -2;
                //    returnData.ReturnMsg = "Sản phẩm không tồn tại";
                //    return returnData;
                //}

                //lstProduct.Remove(product2);

                returnData.ReturnCode = 1;
                returnData.ReturnMsg = "Xóa sản phẩm thành công!";
                return returnData;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ReturnData Product_Delete(List<string> ProductIds)
        {
            throw new NotImplementedException();
        }
        public ReturnData Product_Insert(Product product)
        {
            var returnData = new ReturnData();
            try
            {
                // bước 1: Kiểm tra dữ liệu đầu vào hợp lệ không 
                if (product == null ||
                    string.IsNullOrEmpty(product.ProductName)
                    || product.Price <= 0)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                if (CommonLibs.ValidationData.CheckContainSpecialChar(product.ProductName))
                {
                    returnData.ReturnCode = -2;
                    returnData.ReturnMsg = "Tên sản phẩm không được chứa ký tự đặc biệt";
                    return returnData;
                }

                // Bước 2 : thực hiện thêm dữ liệu vào list

                lstProduct.Add(product);

                returnData.ReturnCode = 1;
                returnData.ReturnMsg = "Thêm sản phẩm thành công!";
                return returnData;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

     
        public List<Product> GetProducts()
        {
            return lstProduct;
        }

        
    }
}
