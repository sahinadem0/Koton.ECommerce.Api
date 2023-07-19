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

        public async Task<Result<GetProductDto>> AddProductAsync(CreateProductDto product)
        {
            try
            {
                var createdProduct = await _productRepository.AddProduct(product);
                return new Result<GetProductDto>(true, "The product was added successfully.", createdProduct);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during product creation.
                return new Result<GetProductDto>(false, "An error occurred while adding the product: " + ex.Message);
            }
        }


        public async Task<Result<GetProductDto>> UpdateProductAsync(int id, UpdateProductDto product)
        {
            try
            {
                var updatedProduct = await _productRepository.UpdateProduct(id, product);
                return new Result<GetProductDto>(true, "The product was updated successfully.", updatedProduct);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during product update.
                return new Result<GetProductDto>(false, "An error occurred while updating the product: " + ex.Message);
            }
        }

        public async Task<Result<object>> DeleteProductAsync(int id)
        {
            try
            {
                await _productRepository.DeleteProduct(id);
                return new Result<object>(true, "The product was deleted successfully.", null);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during product deletion.
                return new Result<object>(false, "An error occurred while deleting the product: " + ex.Message, null);
            }
        }


    }


}

