using BE_22042024.Filter;
using EBook.DataAccess.NetCore.DTO;
using EBook.DataAccess.NetCore.IServices;
using EBook.DataAccess.NetCore.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_22042024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //private IBookRepository _bookServices;
        //public BookController(IBookRepository bookServices)
        //{
        //    _bookServices = bookServices;
        //}

        //private IBookGenericRepository _bookGenericRepository;
        //public BookController(IBookGenericRepository bookGenericRepository)
        //{
        //    _bookGenericRepository = bookGenericRepository;
        //}

        public IUnitOfWork _unitOfWork;
        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("GetBooks")]
        [EShopAuthorize("LIST_BOOK","VIEW")]
        public async Task<ActionResult> GetBooks(GetBooksRequuestData requuestData)
        {
            // var list = _bookServices.GetBooks(requuestData);

            //var list = _bookGenericRepository.GetAll();

            var list = _unitOfWork._bookGenericRepository.GetAll();

            return Ok(list);
        }
    }
}
