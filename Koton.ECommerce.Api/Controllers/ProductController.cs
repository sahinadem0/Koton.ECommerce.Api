using Koton.ECommerce.Business.Services.Abstract;
using Koton.ECommerce.Business.Services.Concrete;
using Koton.ECommerce.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Koton.ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var product = await _productService.GetProductsAsync();
            if (product.IsSuccess)
            {
                return Ok(product);
            }
            else
                return Unauthorized(product.Message);

        }

        // GET api/<ProductController>/5
        [HttpGet("{productId}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(productId);

                return product == null ? NotFound() : Ok(product);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // POST api/<ProductController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
