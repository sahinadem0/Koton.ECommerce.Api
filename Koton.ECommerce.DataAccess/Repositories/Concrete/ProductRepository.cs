using Dapper;
using Koton.ECommerce.Core.DTOs;
using Koton.ECommerce.DataAccess.Repositories.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.ECommerce.DataAccess.Repositories.Concrete
{
    public class ProductRepository : IProductRepository
    {
        public async Task<IEnumerable<GetProductDto>> GetProducts()
        {
            using (var connection = new SqlConnection("Server=DESKTOP-UIC5F07\\SQLEXPRESS;Database=kotonECommerce;Integrated Security=true;MultipleActiveResultSets=True;TrustServerCertificate=true;Application Name=Koton.ECommerce"))
            {
                // Retrieve all products.
                var products = await connection.QueryAsync<GetProductDto>("SELECT * FROM Products");

                return products;
            }
        }

        public async Task<GetProductDto> GetProductById(int id)
        {
            using (var connection = new SqlConnection("Server=DESKTOP-UIC5F07\\SQLEXPRESS;Database=kotonECommerce;Integrated Security=true;MultipleActiveResultSets=True;TrustServerCertificate=true;Application Name=Koton.ECommerce"))
            {
                // Retrieve the product with the specified id.
                var product = await connection.QueryFirstOrDefaultAsync<GetProductDto>("SELECT * FROM Products WHERE Id = @Id", new { Id = id });

                return product;
            }
        }

        public async Task<GetProductDto> AddProduct(CreateProductDto product)
        {
            using (var connection = new SqlConnection("Server=DESKTOP-UIC5F07\\SQLEXPRESS;Database=kotonECommerce;Integrated Security=true;MultipleActiveResultSets=True;TrustServerCertificate=true;Application Name=Koton.ECommerce"))
            {
                // Insert the new product into the database.
                var productId = await connection.ExecuteScalarAsync<int>("INSERT INTO Products (Name, Description, Price) VALUES (@Name, @Description, @Price); SELECT SCOPE_IDENTITY();", product);

                // Retrieve the newly created product.
                var createdProduct = await GetProductById(productId);

                return createdProduct;
            }
        }

        public async Task<GetProductDto> UpdateProduct(int id, UpdateProductDto product)
        {
            using (var connection = new SqlConnection("Server=DESKTOP-UIC5F07\\SQLEXPRESS;Database=kotonECommerce;Integrated Security=true;MultipleActiveResultSets=True;TrustServerCertificate=true;Application Name=Koton.ECommerce"))
            {
                // Update the product in the database.
                await connection.ExecuteAsync("UPDATE Products SET Name = @Name, Description = @Description, Price = @Price WHERE Id = @Id", new { Id = id, product.Name, product.Description, product.Price });

                // Retrieve the updated product.
                var updatedProduct = await GetProductById(id);

                return updatedProduct;
            }
        }

        public async Task DeleteProduct(int id)
        {
            using (var connection = new SqlConnection("Server=DESKTOP-UIC5F07\\SQLEXPRESS;Database=kotonECommerce;Integrated Security=true;MultipleActiveResultSets=True;TrustServerCertificate=true;Application Name=Koton.ECommerce"))
            {
                // Delete the product from the database.
                await connection.ExecuteAsync("DELETE FROM Products WHERE Id = @Id", new { Id = id });
            }
        }


    }
}
