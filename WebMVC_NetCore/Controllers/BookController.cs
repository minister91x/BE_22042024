using EBook.DataAccess.NetCore.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebMVC_NetCore.Controllers
{
    public class BookController : Controller
    {
        private IConfiguration _configuration;
        public BookController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var token = Request.Cookies["MY_JWT_TOKEN"] != null ? Request.Cookies["MY_JWT_TOKEN"].ToString() : "";
            if (string.IsNullOrEmpty(token))
            {
                return Redirect("/Account/Login");
            }
            return View();
        }

        public async Task<IActionResult> ListBookPartialView(GetBooksRequuestData requestData)
        {
            var list = new List<Book>();
            var messageFromServer = string.Empty;
            try

            {
                var token = Request.Cookies["MY_JWT_TOKEN"] != null ? Request.Cookies["MY_JWT_TOKEN"].ToString() : "";
                if (string.IsNullOrEmpty(token))
                {
                    messageFromServer = "Vui lòng đăng nhập";
                    return PartialView(list);
                }
                // Bước 1 : khai báo API URL

                var baseurl = _configuration["API_URL:URL"] ?? "";
                var url = "api/Book/GetBooks";

                // bƯỚC 2: tạo json data ( object sang JSON)
                var jsonData = JsonConvert.SerializeObject(requestData);

                // Bước 3 : gọi httpclient bên common để post lên api

                //bƯỚC 3.1 TRUYỀN TOKEN VỪA LẤY ĐƯỢC Ở BƯỚC ĐĂNG NHẬP ĐỂ ĐƯA SANG API

                var result = await BE_2204.Common.HttpHelper.HttpSenPostWithToken(baseurl, url, jsonData, token);

                // Bước 4: nhận dữ liệu về 

                if (!string.IsNullOrEmpty(result))
                {
                    var response = JsonConvert.DeserializeObject<Result>(result);

                    if (response == null)
                    {
                        messageFromServer = response.message;
                        ViewBag.ErrorCode = response.code;
                        ViewBag.ErrorMessage = messageFromServer;
                        return PartialView(list);

                        /// Redirect("/Account/Login");
                    }
                    if (response?.code <= 0)
                    {
                        messageFromServer = response.message;
                        ViewBag.ErrorMessage = messageFromServer;
                        return PartialView(list);
                    }

                    if (response?.list == null || response?.list.Count <= 0)
                    {
                        messageFromServer = "Không có dữ liệu.Vui lòng kiểm tra lại";
                        ViewBag.ErrorMessage = messageFromServer;
                        return PartialView(list);
                    }

                    foreach (var item in response?.list)
                    {
                        list.Add(new Book
                        {
                            BookName = item.bookName,
                            PublishDate = item.publishDate
                        });

                    }

                }

                ViewBag.ErrorMessage = messageFromServer;
                return PartialView(list);

            }
            catch (Exception ex)
            {
                return PartialView(list);
            }
            return PartialView(list);
        }
    }
}
