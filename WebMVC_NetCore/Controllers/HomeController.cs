using EBook.DataAccess.NetCore.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC_NetCore.Models;

namespace WebMVC_NetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int id)
        {
            var model = new List<BookModels>();

            // đưa dữ liệu vào model
            for (int i = 0; i < 5; i++)
            {
                model.Add(new BookModels
                {
                    BookID = i + 1,
                    BookName = "Sách số " + (i + 1)
                });
            }

            // Trả dữ liệu thông qua model về View
            return View(model);
            // thư mục views -> tên của thư mục trùng tên của controller (Home)
            // tìm tiếp file view nào có tên trùng với tên của Action (Index) có đuôi mở rộng là .cshtml
            // Views/Home/Index.cshtml 
        }

        public ActionResult Test()
        {
            var model = new List<BookModels>();

            // đưa dữ liệu vào model
            for (int i = 0; i < 5; i++)
            {
                model.Add(new BookModels
                {
                    BookID = i + 1,
                    BookName = "Sách số " + (i + 1)
                });
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult DemoLoadAjaxView()
        {
            var model = new List<BookModels>();
            model = GetBooks();

            return PartialView(model);
        }

        public async Task<JsonResult> SaveProduct(ProductInsertUpdateRequestData requestData)
        {
            var model = new BookInsertResponse();
            try
            {
                if (requestData == null
                    || string.IsNullOrEmpty(requestData.ProductName))
                {
                    model.ResponseCode = -1;
                    model.ResponseMessage = "Dữ liệu không được trống";
                    return Json(model);
                }

                var rs = await new EBook.DataAccess.NetCore.Services.ProductServices().ProductInsertUpdate(requestData);

               
                model.ResponseCode = rs.ReturnCode;
                model.ResponseMessage = rs.ReturnMsg;
                return Json(model);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private List<BookModels> GetBooks()
        {
            var model = new List<BookModels>();

            // đưa dữ liệu vào model
            for (int i = 0; i < 5; i++)
            {
                model.Add(new BookModels
                {
                    BookID = i + 1,
                    BookName = "Sách số " + (i + 1)
                });
            }

            return model;
        }
    }
}