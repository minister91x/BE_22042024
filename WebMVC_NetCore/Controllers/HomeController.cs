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

        public IActionResult Index()
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
    }
}