using EBook.DataAccess.NetCore.DBContext;
using EBook.DataAccess.NetCore.DTO;
using EBook.DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.Services
{
    public class ProductServices : IProductServices
    {
        EBookDBContext _eBookDBContext = new EBookDBContext();
        public async Task<List<Product>> ProductGetList()
        {
            try
            {
                return _eBookDBContext.product.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ProductInsertReturnData> ProductInsertUpdate(ProductInsertUpdateRequestData requestData)
        {
            var returnData = new ProductInsertReturnData();
            var errItem = string.Empty;
            try
            {
                if (requestData == null
                    || requestData.CategoryId == 0
                    || string.IsNullOrEmpty(requestData.ProductName)
                    || string.IsNullOrEmpty(requestData.AttributeValues))
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Dữu liệu không hợp lệ";
                    return returnData;
                }

                // check ký tự dặc biêt, 
                //if (!CommonLibs.ValidationData.CheckContainSpecialChar(requestData.ProductName))
                //{
                //    returnData.ReturnCode = -1;
                //    returnData.ReturnMsg = "Tên sản phẩm không hợp lệ";
                //    return returnData;
                //}

                // check trùng 

                var product = _eBookDBContext.product.Where(s => s.ProductName == requestData.ProductName).FirstOrDefault();
                if (product != null || product.ProductID > 0)
                {
                    returnData.ReturnCode = -2;
                    returnData.ReturnMsg = "Tên sản phẩm đã tồn tại";
                    return returnData;
                }

                // thêm sản phẩm vào database 

                var productReq = new Product
                {
                    ProductName = requestData.ProductName,
                    CategoryId = requestData.CategoryId
                };

                _eBookDBContext.product.Add(productReq);

                // lưu thuộc tính 


                var attr_count = requestData.AttributeValues.Split('_').Length;

                for (int i = 0; i < attr_count; i++)
                {
                    var item = requestData.AttributeValues.Split('_')[i];

                    var attr_name = item.Split(',')[0];
                    var attr_quantity = item.Split(',')[1];

                    var attr_price = item.Split(',')[2];
                    var attr_priceSale = item.Split(',')[3];

                    // kiểm tra xem null 

                    if (string.IsNullOrEmpty(attr_name) )
                    {
                        errItem += "tên thuộc tính bị trống hoặc không hợp lệ ";
                        continue;
                    }

                    if (string.IsNullOrEmpty(attr_quantity) )
                    {
                        errItem += "thuộc tính số lượng bị trống";
                        continue;
                    }

                    if (string.IsNullOrEmpty(attr_price) )
                    {
                        errItem += " thuộc tính giá bị trống";
                        continue;
                    }

                    if (string.IsNullOrEmpty(attr_priceSale))
                    {
                        errItem += " thuộc tính giá sale bị trống";
                        continue;
                    }

                    var attr_Req = new ProductAttribute
                    {
                        AttributeName = attr_name,
                        Quantity = Convert.ToInt32(attr_quantity),
                        Price = Convert.ToInt32(attr_price),
                        PriceSale = Convert.ToInt32(attr_priceSale),
                    };

                    _eBookDBContext.Add(attr_Req);

                }

                _eBookDBContext.SaveChangesAsync();


                returnData.ReturnCode = 1;
                returnData.ReturnMsg = "Thêm sản phẩm thành công";
                return returnData;
            }
            catch (Exception ex)
            {

                returnData.ReturnCode = -969;
                returnData.ReturnMsg = "Hệ thống đang bận!";
                return returnData;
            }
        }
    }
}
