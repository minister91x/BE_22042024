using EBook.DataAccess.NetCore.DTO;
using EBook.DataAccess.NetCore.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_22042024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpPost("ProductGetList")]
        public async Task<ActionResult> ProductGetList()
        {
            var lstProduct = new List<Product>();
            try
            {
                lstProduct = await _productServices.ProductGetList();
            }
            catch (Exception ex)
            {

                throw;
            }

            return Ok(lstProduct);
        }
    }
}
