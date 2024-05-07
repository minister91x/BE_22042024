using EBook.DataAccess.NetCore.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_22042024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookServices _bookServices;
        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            var list = _bookServices.GetBooks();
            return Ok(list);
        }
    }
}
