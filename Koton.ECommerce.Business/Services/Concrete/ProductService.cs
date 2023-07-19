using Koton.ECommerce.Business.Services.Abstract;
using Koton.ECommerce.Core.Common;
using Koton.ECommerce.Core.DTOs;
using Koton.ECommerce.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.ECommerce.Business.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }



        public async Task<Result<IEnumerable<GetProductDto>>> GetProductsAsync()
        {
            try
            {
                var products = await _productRepository.GetProducts();

                if (products != null && products.Any())
                {
                    return new Result<IEnumerable<GetProductDto>>
                    {
                        IsSuccess = true,
                        Data = products,
                        Message = "Products retrieved successfully."
                    };
                }
                else
                {
                    return new Result<IEnumerable<GetProductDto>>
                    {
                        IsSuccess = false,
                        Message = "No products found."
                    };
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during product retrieval.
                return new Result<IEnumerable<GetProductDto>>
                {
                    IsSuccess = false,
                    Message = "An error occurred while retrieving products: " + ex.Message
                };
            }
        }

        public async Task<Result<GetProductDto>> GetProductByIdAsync(int id)
        {
            
            var product = await _productRepository.GetProductById(id);

            
            if (product == null)
            {
              
                return new Result<GetProductDto>
                {
                    IsSuccess = false,
                    Message = "An error occurred while retrieving products: "
                };
            }

            // The product was found.
            return new Result<GetProductDto>(true, "The product was found.", product);
        }
    }


}

