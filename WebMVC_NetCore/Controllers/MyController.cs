using EBook.DataAccess.NetCore.DTO;
using Microsoft.AspNetCore.Mvc;
using WebMVC_NetCore.Filter;

namespace WebMVC_NetCore.Controllers
{
    public class MyController : Controller
    {
        private IConfiguration _configuration;

        public MyController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [ActionName("idx")]
        [HttpGet]
        [HttpPost]
        public ActionResult Index()
        {
            var myconection = _configuration["URL:myUrl"] ?? "";
          
            var returndata = new ReturnData();
            return View(myconection);
        }

        [HttpPost]
        [MyCustomAuthentication("Test_Filter1124", "VIEW")]
        public JsonResult Test_Filter()
        {
            var returndata = new ReturnData();
            return Json(returndata);
        }
       
    }
}
