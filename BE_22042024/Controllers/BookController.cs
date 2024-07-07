using BE_22042024.Filter;
using EBook.DataAccess.NetCore.DTO;
using EBook.DataAccess.NetCore.IServices;
using EBook.DataAccess.NetCore.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

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
        private readonly IDistributedCache _cache;
        public BookController(IUnitOfWork unitOfWork, IDistributedCache cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        [HttpPost("GetBooks")]
        [EShopAuthorize("LIST_BOOK", "VIEW")]
        public async Task<ActionResult> GetBooks(GetBooksRequuestData requuestData)
        {
            var model = new Books_GetAllResponseData();
            try
            {
                // Tạo Key cache

                var cacheKey = "API.BOOK.GETLIST";
                // Trying to get data from the Redis cache

                byte[] cachedData = await _cache.GetAsync(cacheKey);

                // Nếu tồn tại dữ liệu trog cache 
                if (cachedData != null)
                {
                    //Convert string sang object để trả về luôn không đi vào DB NỮA
                    var dataFromCache = Encoding.UTF8.GetString(cachedData);
                    model = JsonConvert.DeserializeObject<Books_GetAllResponseData>(dataFromCache);
                  
                    return Ok(model);
                }

                // CHƯA TỒN TẠI

                // VÀO DATABASE ĐỂ LẤY

                model = await _unitOfWork._bookRepository.GetBooks(new GetBooksRequuestData { BookName = "", CategoryID = 0 });


                // LẤY XONG THÌ LƯU VÀO CACHE 
                string cachedDataString = JsonConvert.SerializeObject(model); 
                var dataToCache = Encoding.UTF8.GetBytes(cachedDataString); 
                
                // Setting up the cache options
                DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5)) 
                    .SetSlidingExpiration(TimeSpan.FromMinutes(3));
                // Add the data into the cache
                

                await _cache.SetAsync(cacheKey, dataToCache, options);
                return Ok(model);
            }
            catch (Exception ex)
            {

                return Ok(model);
            }

            
          
        }
    }
}
