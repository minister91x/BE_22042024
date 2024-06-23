using EBook.DataAccess.NetCore.DTO;
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

        [HttpPost("GetBooks")]
        public async Task<ActionResult> GetBooks(GetBooksRequuestData requuestData)
        {
            var list = _bookServices.GetBooks(requuestData);
            return Ok(list);
        }
    }
}
