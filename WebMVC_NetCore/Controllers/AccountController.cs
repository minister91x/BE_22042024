using EBook.DataAccess.NetCore.DTO;
using EBook.DataAccess.NetCore.Services;
using Microsoft.AspNetCore.Mvc;
using WebMVC_NetCore.Models;

namespace WebMVC_NetCore.Controllers
{
    public class AccountController : Controller
    {
        readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
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
                if (requestData == null || string.IsNullOrEmpty(requestData.email)
                    || string.IsNullOrEmpty(requestData.password))
                {
                    returnData.ReturnCode = -2;
                    returnData.ReturnMsg = "Dữ liệu đầu vào không được trống!";
                    return Json(returnData);
                }

                // chuyển mật khẩu ở dạng plantext -> mã hóa 
                // 12345 -> SSMG5a92ylYwR3dTvcnMjEn6gU90X1Ob
                var salt = _configuration["Sercurity:SALT_KEY"] ?? "";
                var passwordHash = BE_2204.Common.Sercurity.EncryptPassword(requestData.password, salt);

                requestData.password = passwordHash;

                var result = await new AccountServices().Account_Login(requestData);

                returnData.ReturnCode = result.ReturnCode;
                returnData.ReturnMsg = result.ReturnMsg;
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(returnData);
        }
    }
}
