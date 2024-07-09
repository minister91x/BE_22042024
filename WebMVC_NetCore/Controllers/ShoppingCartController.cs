using EBook.DataAccess.NetCore.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web;
using WebMVC_NetCore.Models;

namespace WebMVC_NetCore.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IConfiguration _configuration;
        public ShoppingCartController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ListShoppingCartPartial()
        {
            var list = new List<ShopingCartModels>();
            try
            {
                // lấy cookies ra 
                var cookie = Request.Cookies["MyShoppingCart"] != null ? Request.Cookies["MyShoppingCart"].ToString() : "";
                list = JsonConvert.DeserializeObject<List<ShopingCartModels>>(HttpUtility.UrlDecode(cookie));
            }
            catch (Exception ex)
            {

                throw;
            }
            return PartialView(list);
        }

        public async Task<JsonResult> CreatOrder(CreatOrderRequestData requestData)
        {
            var returnData = new EBook.DataAccess.NetCore.DTO.ReturnData();
            var listProductShopping = new List<ProductShopping>();
            try
            {
                var cookie = Request.Cookies["MyShoppingCart"] != null ? Request.Cookies["MyShoppingCart"].ToString() : "";
                var list = JsonConvert.DeserializeObject<List<ShopingCartModels>>(HttpUtility.UrlDecode(cookie));

                if (list.Count <= 0)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Lỗi không có thông tin giỏ hàng";
                    return Json(returnData);
                }

                var totalAmount = 0;
                foreach (var item in list)
                {
                    listProductShopping.Add(new ProductShopping
                    {
                        Price = item.Price,
                        ProductID = item.ProductID,
                        ProductName = item.ProductName,
                        Quantity = item.Quantity,
                        ProductImage= item.Image
                    });

                    totalAmount = item.Quantity * item.Price;
                }

                var createOrderReq = new OrdersCreateRequestData
                {
                    CustomerId = 1,
                    ShipingAddress = requestData.CustomerAddress,
                    products = listProductShopping,
                    TotalAmount = totalAmount,
                    
                };

                var token = Request.Cookies["MY_JWT_TOKEN"] != null ? Request.Cookies["MY_JWT_TOKEN"].ToString() : "";
                if (string.IsNullOrEmpty(token))
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Lỗi không có thông tin giỏ hàng";
                    return Json(returnData);
                }
                // Bước 1 : khai báo API URL

                var baseurl = _configuration["API_URL:URL"] ?? "";
                var url = "api/Product/CreateOrder";

                // bƯỚC 2: tạo json data ( object sang JSON)
                var jsonData = JsonConvert.SerializeObject(createOrderReq);

                // Bước 3 : gọi httpclient bên common để post lên api

                //bƯỚC 3.1 TRUYỀN TOKEN VỪA LẤY ĐƯỢC Ở BƯỚC ĐĂNG NHẬP ĐỂ ĐƯA SANG API

                var result = await BE_2204.Common.HttpHelper.HttpSenPostWithToken(baseurl, url, jsonData, token);

                // Bước 4: nhận dữ liệu về 

                if (!string.IsNullOrEmpty(result))
                {
                    var response = JsonConvert.DeserializeObject<Result>(result);


                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(returnData);
        }
    }
}
