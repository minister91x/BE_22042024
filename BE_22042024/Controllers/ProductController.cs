using BE_22042024.Models;
using EBook.DataAccess.NetCore.DTO;
using EBook.DataAccess.NetCore.IServices;
using EBook.DataAccess.NetCore.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReturnData = BE_22042024.Models.ReturnData;

namespace BE_22042024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //readonly IProductServices _productServices;
        //public ProductController(IProductServices productServices)
        //{
        //    _productServices = productServices;
        //}

        public IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;

        public ProductController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [HttpPost("ProductGetList")]
        public async Task<ActionResult> ProductGetList(ProductGetListRequestData requestData)
        {
            var lstProduct = new List<Product>();
            try
            {
                var media_url = _configuration["URL:MEDIA_URL"] ?? "";
                lstProduct = await _unitOfWork._productServices.ProductGetList();
                if (lstProduct.Count > 0)
                {
                    foreach (var item in lstProduct)
                    {
                        item.ProductImage = media_url + item.ProductImage;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return Ok(lstProduct);
        }

        [HttpPost("ProductInsert")]
        public async Task<ActionResult> ProductInsert(ProductInsertUpdateRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                // bước 1: gọi media để upload ảnh 

                // Bước 1.1 : khai báo API URL

                var baseurl = _configuration["URL:API_URL"] ?? "";
                var url = "api/Media/Upload";

                // bƯỚC 1.2: tạo json data ( object sang JSON)

                // kiểm tra xem chữ ký có hợp lệ không ?
                var SecretKey = _configuration["Sercurity:SecretKey"] ?? "";

                var plantext = requestData.Base64Image + SecretKey;

                var Sign = BE_2204.Common.Sercurity.MD5(plantext);

                var requestUpload = new UploadRequestData
                {
                    Base64Image = requestData.Base64Image,
                    Sign = Sign
                };

                var jsonData = JsonConvert.SerializeObject(requestUpload);

                // Bước 1.3 : gọi httpclient bên common để post lên api
                var result = await BE_2204.Common.HttpHelper.HttpSenPost(baseurl, url, jsonData);

                // Bước 1.4: nhận dữ liệu về 
                var imageName = "";
                if (!string.IsNullOrEmpty(result))
                {
                    var rs = JsonConvert.DeserializeObject<ReturnData>(result);
                    if (rs != null && rs.ResponseCode > 0)
                    {
                        imageName = rs.Description;
                    }
                }


                // bước 2: có ảnh từ bước 1 rồi thì thực hiện lưu xuống db

                var productInsertReq = new ProductInsertUpdateRequestData
                {
                    Base64Image = imageName,
                    ProductName = "",
                };
                var insert = _unitOfWork._productServices.ProductInsertUpdate(productInsertReq);
                returnData.ResponseCode = 1;
                returnData.Description = "ok";
                return Ok(returnData);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
