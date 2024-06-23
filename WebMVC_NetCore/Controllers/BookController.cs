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
            return View();
        }

        public async Task<IActionResult> ListBookPartialView(GetBooksRequuestData requestData)
        {
            var list = new List<Book>();
            try
            
            {
                // Bước 1 : khai báo API URL

                var baseurl = _configuration["API_URL:URL"] ?? "";
                var url = "api/Book/GetBooks";
                
                // bƯỚC 2: tạo json data ( object sang JSON)
                var jsonData = JsonConvert.SerializeObject(requestData);
               
                // Bước 3 : gọi httpclient bên common để post lên api
                var result = await BE_2204.Common.HttpHelper.HttpSenPost(baseurl, url, jsonData);
                
                // Bước 4: nhận dữ liệu về 
                if (!string.IsNullOrEmpty(result))
                {
                    var response = JsonConvert.DeserializeObject<GetBookResponseData>(result);
                   if(response.result.Count > 0)
                    {
                        foreach (var item in response.result)
                        {
                            list.Add(new Book
                            {
                                BookName= item.bookName,
                                PublishDate = item.publishDate
                            });

                        }
                    }
                }

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
