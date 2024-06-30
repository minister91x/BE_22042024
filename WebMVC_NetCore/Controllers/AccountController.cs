using EBook.DataAccess.NetCore.DTO;
using EBook.DataAccess.NetCore.IServices;
using EBook.DataAccess.NetCore.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebMVC_NetCore.Models;

namespace WebMVC_NetCore.Controllers
{
    public class AccountController : Controller
    {
        readonly IConfiguration _configuration;
        public AccountController(IConfiguration configuration)
        {
            // Dependency Contructor
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<JsonResult> Account_Login(Account_LoginRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                // Bước 1: Kiểm tra dữ liệu đầu vào 
                if (requestData == null || string.IsNullOrEmpty(requestData.username)
                    || string.IsNullOrEmpty(requestData.password))
                {
                    returnData.ReturnCode = -2;
                    returnData.ReturnMsg = "Dữ liệu đầu vào không được trống!";
                    return Json(returnData);
                }

                // Bước 2 : GỌI API ĐỂ LẤY TOKEN 
                // bƯỚC 2.1 kHAI BÁO URL CỦA API

                var baseurl = _configuration["API_URL:URL"] ?? "";
                var url = "api/Account/Login";

                //Bước 2.2 convert từ object requestData sang Json để đẩy lên API
                var jsonData = JsonConvert.SerializeObject(requestData);

                // Bước 2.3 dùng httpClient để đưa json lên URL của API
                var result = await BE_2204.Common.HttpHelper.HttpSenPost(baseurl, url, jsonData);

                if (string.IsNullOrEmpty(result))
                {
                    returnData.ReturnCode = -2;
                    returnData.ReturnMsg = "Lỗi";
                    return Json(returnData);
                }

                // Bước 2.4 : Convert từ json nhận được thành object 

                var rs = JsonConvert.DeserializeObject<ReturnData>(result);
                if (rs.ReturnCode <= 0)
                {
                    returnData.ReturnCode = rs.ReturnCode;
                    returnData.ReturnMsg = rs.ReturnMsg;
                    return Json(returnData);
                }


                returnData.ReturnCode = 1;
                returnData.ReturnMsg = "Đăng nhập thành công!";
                returnData.token = rs.token;

              //  Session
                return Json(returnData);
            }
            catch (Exception ex)
            {
                returnData.ReturnCode = -969;
                returnData.ReturnMsg = ex.Message ;
                return Json(returnData);
            }

            
        }
    }
}
