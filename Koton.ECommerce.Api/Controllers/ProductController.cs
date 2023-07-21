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

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto product)
        {
            var result = await _productService.AddProductAsync(product);
            if (result.IsSuccess)
            {
                return CreatedAtRoute("GetProductById", new { productId = result.Data.Id }, result.Data);
            }
            else
                return BadRequest(result.Message);
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, UpdateProductDto product)
        {
            var result = await _productService.UpdateProductAsync(productId, product);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var result = await _productService.DeleteProductAsync(productId);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }


    }
}
