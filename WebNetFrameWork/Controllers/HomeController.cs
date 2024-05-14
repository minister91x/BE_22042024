using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNetFrameWork.Models;

namespace WebNetFrameWork.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Khởi tạo model
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}